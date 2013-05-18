using System;
using System.Html;
using Cayita.Plugins;

namespace Cayita.UI
{

	public class Form:FormBase<Form>
	{

		public Form(Element parent, Action<FormElement> element):base(parent,element)
		{
		}

		public Form (Element parent):base(parent)
		{
		}
	
		public Form ():base(default(Element))
		{
		}
	
		public Form(ElementBase parent):base(parent.GetMainElement())
		{
		}

	}
	
	public class FormBase<T>:ElementBase<T> where T:ElementBase
	{

		public event Action<FormBase<T>> DataChanged = f=> {};

		protected void OnDataChanged()
		{
			DataChanged (this);
		}

		ValidateOptions val = new ValidateOptions ();

		public FormBase(Element parent, Action<FormElement> element)
		{
			Init (parent);
			element.Invoke(Element());
		}


		public FormBase (Element parent=null)
		{
			Init (parent);
		}

		void Init(Element parent)
		{
			CreateElement("form", parent);

			Element ().OnChange (evt => {
				OnDataChanged();
			});
		}


		public new FormElement Element()
		{
			return (FormElement) base.Element();
		}

		public FormData FormData()
		{
			return new FormData(Element());
		}

		public T Validate ( )
		{
			Element ().Validate (val);
			return As<T>();
		}

		public T AddRule(Action<RuleFor, Message> rule)
		{
			val.AddRule (rule);
			return As<T>();
		}

		public T SetSubmitHanlder(Action<FormBase<T>> form)
		{
			val.SetSubmitHandler (f => form (this));
			return As<T>();
		}

		public ButtonElement FindSubmit()
		{
			return Element ().Find<ButtonElement> ("[type=submit]");
		}


		public T Reset()
		{
			Element ().Reset ();
			return As<T>();
		}

		public T Load<TData>(TData data)
		{
			Element ().Load<TData> (data); 
			return As<T>();
		}

		public TData LoadTo<TData>() where TData: new ()
		{
			return Element ().LoadTo<TData> ();
		}

		public bool HasChanged()
		{
			return Element ().HasChanged ();
		}

	}
}
