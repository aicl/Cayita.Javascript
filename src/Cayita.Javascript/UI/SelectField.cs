using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.Javascript.Data;
using System.Linq;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class SelectedOption<T> where T: new ()
	{
		public SelectedOption ()
		{
			Record=new T();
		}
		public OptionElement Option {get;set;}
		public T Record {get;set;}
	}


	[ScriptNamespace("Cayita.UI")]
	public class SelectField<T>:SelectField where T: new()
	{
		Func<T,OptionElement> optionFunc;
		Store<T> store ;
		SelectElement se;
		SelectedOption<T> selectedoption;
		SelectedOption<T> defaultoption;

		public SelectField(Element parent, Action<SelectElement> element,
		                   Store<T> store, Func<T,OptionElement> optionFunc, SelectedOption<T> defaultOption=null)
		{

			ControlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				Label = Label.CreateControlLabel(cgDiv, "");
				Label.Hide();
				Controls = new Div( cgDiv,  ctDiv=>{
					Init(ctDiv);
					element(Element());
					Label.ForField( Element().ID);
					Init (store, optionFunc, defaultOption);
				});
			});
		}

		public SelectField(Element parent, Action<Element,SelectElement> element,
		                   Store<T> store, Func<T,OptionElement> optionFunc, SelectedOption<T> defaultOption=null)

		{
			ControlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				Label = Label.CreateControlLabel(cgDiv, "");
				Controls = Div.CreateControls( cgDiv, ctDiv=>{
					Init(ctDiv);
					element(Label.Element(), Element());
					Label.ForField( Element().ID);
					Init (store, optionFunc, defaultOption);
				});
				if( string.IsNullOrEmpty( Label.TextLabel()) ) Label.Hide();
			});									
		}

		void Init (Store<T> store, Func<T, OptionElement> optionFunc, SelectedOption<T> defaultOption)
		{
			this.store = store;
			this.optionFunc = optionFunc;
			se = Element ();
			OnOptionSelected = (sf, opt) =>  {
			};
			defaultoption = defaultOption ?? new SelectedOption<T> ();
			se.JQuery ().On ("change", evt =>  {
				var option = (OptionElement)se.JQuery ().Find ("option:selected") [0];
				SelectedOptionImp (option, true);
			});
			Render();
			store.OnStoreChanged += (st, dt) =>  {
				switch (dt.Action) {
				case StoreChangedAction.Created:
					se.CreateOption (dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Read:
					SelectOption();
					Render ();
					break;
				case StoreChangedAction.Updated:
					se.UpdateOption (dt.NewData, optionFunc, store.GetRecordIdProperty ());
					break;
				case StoreChangedAction.Destroyed:
					se.RemoveOption (dt.OldData, store.GetRecordIdProperty ());
					SelectOption();
					break;
				case StoreChangedAction.Patched:
					se.UpdateOption (dt.NewData, optionFunc, store.GetRecordIdProperty ());
					break;
				case StoreChangedAction.Added:
					se.CreateOption (dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Replaced:
					se.UpdateOption (dt.NewData, optionFunc, store.GetRecordIdProperty ());
					break;
				case StoreChangedAction.Inserted:
					se.CreateOption (dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Removed:
					se.RemoveOption (dt.OldData, store.GetRecordIdProperty ());
					SelectOption();
					break;
				case StoreChangedAction.Loaded:
					SelectOption();
					Render ();
					break;
				case StoreChangedAction.Cleared:
					se.Empty ();
					SelectOption();
					break;
				}
			};
		}


		public void Render()
		{
			bool append =false;
			if (defaultoption.Option!=null && string.IsNullOrEmpty(defaultoption.Option.Value))
			{
				append=true;
				se.CreateOption( defaultoption.Record, f=>{ 
					return  defaultoption.Option;
				});
			}
			se.Load(store, optionFunc, append);
			if(!string.IsNullOrEmpty(defaultoption.Option.Value))
				se.SelectOption(defaultoption.Option.Value);
		}

		public SelectedOption<T> GetSelectedOption()
		{
			return selectedoption;
		}

		public event Action<SelectField<T> ,SelectedOption<T>> OnOptionSelected;

		public void SelectOption ( object value, bool trigger = true)
		{
			var option =(OptionElement) se.SelectOption(value)[0];
			SelectedOptionImp( option, true);
		}

		public void SelectOption ( )
		{
			se.UnSelectOption();
			selectedoption = default(SelectedOption<T>);
			OnOptionSelected(this, selectedoption);
		}

		void SelectedOptionImp (OptionElement option, bool trigger=true)
		{
			var self= this;
			var recordId = option.Value;
			if(! string.IsNullOrEmpty(recordId))
			{
				var record = store.First (f =>((object)((dynamic) f)[self.store.GetRecordIdProperty()]).ToString() == option.Value);
				selectedoption= new SelectedOption<T>{ Option=option, Record= record};
			}
			else
			{
				selectedoption = default(SelectedOption<T>);
			}

			if(trigger) OnOptionSelected(this, selectedoption);
		}
	}

	[ScriptNamespace("Cayita.UI")]
	public class SelectField :HtmlSelect
	{
		
		protected  Div ControlGroup ;
		protected Label Label ;
		protected Div Controls ;

		protected SelectField(){}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElement, SelectElement>.
		/// </param>
		public SelectField(Element parent, Action<Element,SelectElement> field)
		{
			ControlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				Label = Label.CreateControlLabel(cgDiv, "");
				Controls = Div.CreateControls( cgDiv, ctDiv=>{
					Init(ctDiv);
					field(Label.Element(), Element());
					Label.ForField( Element().ID);
				});
				if( string.IsNullOrEmpty( Label.TextLabel()) ) Label.Hide();
			});  
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<SelectElement>
		/// </param>
		public SelectField(Element parent, Action<SelectElement> field)
		{
			ControlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				Label = Label.CreateControlLabel(cgDiv, "");
				Label.Hide();
				Controls = new Div( cgDiv,  ctDiv=>{
					Init(ctDiv);
					field(Element());
					Label.ForField( Element().ID);
				});
			});  
		}

		public Div GetControlGroup()
		{
			return ControlGroup;
		}
		
		public Div GetControls()
		{
			return Controls;
		}

		public Label GetLabel()
		{
			return Label;
		}

	}
}
