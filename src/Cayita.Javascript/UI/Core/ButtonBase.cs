using System;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{

	public abstract class ButtonBase<T>:ElementBase<T> where T:ElementBase
	{
		protected ButtonBase(){}
				
		protected void CreateButton(Element parent,  string type)
		{
			CreateElement("button", parent);
			var el = Element ();
			if(!string.IsNullOrEmpty(type))  el.Type=type;
			el.ClassName="btn";

			el.OnClick (evt => OnClicked (evt));

		}

		public event  Action<T,jQueryEvent> Clicked = (b,e) => {};

		protected void OnClicked(jQueryEvent evt)
		{
			Clicked (this.As<T>(), evt);
		}

		public T LoadingText(string value)
		{
			Element().LoadingText(value);
			return this.As<T>();
		}

		public  T ShowLoadingText()
		{
			Element().ShowLoadingText();
			return this.As<T>();
		}

		public  T ResetLoadingText()
		{
			Element().ResetLoadingText();
			return this.As<T>();
		}

		public  T Toggle()
		{
			Element().Toggle(); 
			return this.As<T>();
		}

		public new ButtonElement Element()
		{
			return (ButtonElement)base.Element();
		}
	}
}

