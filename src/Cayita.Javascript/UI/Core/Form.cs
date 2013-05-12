using System;
using System.Html;
using Cayita.Plugins;

namespace Cayita.UI
{
	
	public class Form:ElementBase<Form>
	{

		public event Action<Form> DataChanged = f=> {};

		protected void OnDataChanged()
		{
			DataChanged (this);
		}

		ValidateOptions val = new ValidateOptions ();

		public Form(Element parent, Action<FormElement> element)
		{
			Init (parent);
			element.Invoke(Element());
		}


		public Form (Element parent=null)
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

		public Form Validate ( )
		{
			Element ().Validate (val);
			return this;
		}

		public Form AddRule(Action<RuleFor, Message> rule)
		{
			val.AddRule (rule);
			return this;
		}

		public Form SetSubmitHanlder(Action<Form> form)
		{
			val.SetSubmitHandler (f => form (this));
			return this;
		}

		public ButtonElement FindSubmit()
		{
			return Element ().Find<ButtonElement> ("[type=submit]");
		}


		public Form Reset()
		{
			Element ().Reset ();
			return this;
		}

		public Form Load<T>(T data)
		{
			Element ().Load<T> (data); 
			return this;
		}

		public T LoadTo<T>() where T: new ()
		{
			return Element ().LoadTo<T> ();
		}

		public bool HasChanged()
		{
			return Element ().HasChanged ();
		}

	}
}
