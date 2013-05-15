using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.Data;
using System.Linq;

namespace Cayita.UI
{
	[Serializable]	
	public class SelectedOption<T> where T: new ()
	{
		public SelectedOption ()
		{
			Record=new T();
		}
		public OptionElement Option { get; set; }
		public T Record { get; set; }
	}

	public class SelectField<T>:SelectField where T: new()
	{
		Func<T,OptionElement> optionFunc;
		Store<T> store ;
		SelectElement se;
		SelectedOption<T> selectedoption;
		SelectedOption<T> defaultoption;

		public SelectField(Element parent, Action<SelectElement> field,
		                   Store<T> store, Func<T,OptionElement> optionFunc,
		                   SelectedOption<T> defaultOption=null)
			:base(parent, field)
		{
			Init (store, optionFunc, defaultOption);
		}

		public SelectField(Element parent, Action<LabelElement,SelectElement> element,
		                   Store<T> store, Func<T,OptionElement> optionFunc, 
		                   SelectedOption<T> defaultOption=null)
			:base(parent, element)

		{
			Init (store, optionFunc, defaultOption);									
		}

		void Init (Store<T> store, Func<T, OptionElement> optionFunc, SelectedOption<T> defaultOption)
		{
			this.store = store;
			this.optionFunc = optionFunc;
			se = base.SelectElement ();
			defaultoption = defaultOption ?? new SelectedOption<T> ();
			se.JQuery ().On ("change", evt =>  {
				var option = (OptionElement)se.JQuery ().Find ("option:selected") [0];
				SelectedOptionImp (option, true);
			});
			Render();
			store.StoreChanged += (st, dt) =>  {
				switch (dt.Action) {
				case StoreChangedAction.Created:
					se.CreateOption (dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Filtered:
				case StoreChangedAction.Loaded:
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

		public event Action<SelectField<T> ,SelectedOption<T>> OptionSelected = (sf, opt) => {};

		protected void  OnOptionSelected(SelectedOption<T> option)
		{
			OptionSelected (this, option);
		}

		public void SelectOption ( object value, bool trigger = true)
		{
			var option =(OptionElement) se.SelectOption(value)[0];
			SelectedOptionImp( option, true);
		}

		public void SelectOption ( )
		{
			se.UnSelectOption();
			selectedoption = default(SelectedOption<T>);
			OnOptionSelected(selectedoption);
		}

		void SelectedOptionImp (OptionElement option, bool trigger=true)
		{
			var recordId = option.Value;
			if(! string.IsNullOrEmpty(recordId))
			{
				var self = this;
				var record = store.First (f =>f.Get(self.store.GetRecordIdProperty()).ToString() == option.Value);
				selectedoption= new SelectedOption<T>{ Option=option, Record= record};
			}
			else
			{
				selectedoption = default(SelectedOption<T>);
			}

			if(trigger) OnOptionSelected(selectedoption);
		}
	}

	[ScriptNamespace("Cayita.UI")]
	public class SelectField :Div
	{

		LabelElement lb ;
		DivElement ctrls ;
		SelectElement se;

		public SelectField():base(default(Element))
		{
			Init ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElement, SelectElement>.
		/// </param>
		public SelectField(Element parent, Action<LabelElement,SelectElement> field):
			base(parent)
		{
			Init ();
			field.Invoke(lb, se);
			lb.For=se.ID;
			if( string.IsNullOrEmpty( lb.Text()) ) lb.Hide();

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<SelectElement>
		/// </param>
		public SelectField(Element parent, Action<SelectElement> field):base(parent)
		{
			Init ();
			field.Invoke( se);
			lb.For=se.ID;
			lb.Hide();		  
		}

		void Init()
		{
			var cg = Element ();
			cg.ClassName = "control-group";

			lb = new Label(cg, l=> l.ClassName="control-label").Element();

			ctrls = Div.CreateControls( cg, div=>{
				se = new InputSelect(div).Element();
			}).Element();

		}
				
		public DivElement Controls()
		{
			return ctrls;
		}

		public LabelElement Label()
		{
			return lb;
		}

		public SelectElement SelectElement()
		{
			return se;
		}

	}
}
