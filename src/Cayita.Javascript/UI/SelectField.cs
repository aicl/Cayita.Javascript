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
		public SelectedOption (){
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

		/// <summary>
		/// Initializes a new instance of the <see cref="Cayita.Javascript.UI.SelectField"/> class.
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		/// <param name='field'>
		/// Field<LabelElement, SelectElement>.
		/// </param>
		public SelectField(Element parent, Action<Element,SelectElement> field,
		                   Store<T> store, Func<T,OptionElement> optionFunc, SelectedOption<T> defaultOption=null)
			:base(parent, field)
		{

			OnOptionSelected=(sf, opt)=>{};
			this.store=store;
			se= Element();
			this.optionFunc=optionFunc;
			defaultoption= defaultOption;

			se.JSelect().On("change", evt=>{
				var option= (OptionElement) se.JSelect().Find("option:selected")[0];
				SelectedOptionImp(option, true);
			}); 
						
			Render();
			
			store.OnStoreChanged+=(st, dt)=>{
				switch(dt.Action)
				{
				case StoreChangedAction.Created:
					se.CreateOption(dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Read:
					se.Load(store, optionFunc);
					break;
				case StoreChangedAction.Updated:
					se.UpdateOption(dt.NewData, optionFunc, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Destroyed:
					se.RemoveOption(dt.OldData,  store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Patched:
					se.UpdateOption(dt.NewData, optionFunc,  store.GetRecordIdProperty() );
					break;
					
				case StoreChangedAction.Added:
					se.CreateOption(dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Replaced:
					se.UpdateOption(dt.NewData, optionFunc, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Inserted:
					se.CreateOption(dt.NewData, optionFunc);
					break;
				case StoreChangedAction.Removed:
					se.RemoveOption(dt.OldData, store.GetRecordIdProperty());
					break;
				case StoreChangedAction.Loaded:
					se.Load(store, optionFunc);
					break;
				case StoreChangedAction.Cleared:
					se.Empty();
					break;
				}
				
			};

		}

		public void Render()
		{
			se.Load<T>(store, optionFunc);
		}


		void LoadImpl()
		{

		}

		public SelectedOption<T> GetSelectedOption()
		{
			return selectedoption;
		}

		public event Action<SelectField<T> ,SelectedOption<T>> OnOptionSelected;

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
		
		Div controlGroup ;
		Label label ;
		Div controls ;


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
			controlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				label = Label.CreateControlLabel(cgDiv, "");
				controls = Div.CreateControls( cgDiv, ctDiv=>{
					Init(ctDiv);
					label.ForField( Element().ID);
					field(label.Element(), Element());
				});
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
			controlGroup = Div.CreateControlGroup(parent, cgDiv=>{
				label = Label.CreateControlLabel(default(Element), "");
				controls = new Div( cgDiv,  ctDiv=>{
					Init(ctDiv);
					label.ForField( Element().ID);
					field(Element());
				});
			});  
		}

		public Div GetControGroup()
		{
			return controlGroup;
		}
		
		public Div GetControls()
		{
			return controls;
		}

		public Label GetLabel()
		{
			return label;
		}

	}
}
