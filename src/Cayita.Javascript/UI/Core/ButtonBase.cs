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

		public event  Action<ButtonBase<T>,jQueryEvent> Clicked = (b,e) => {};

		protected void OnClicked(jQueryEvent evt)
		{
			Clicked (this, evt);
		}

		public void LoadingText(string value)
		{
			Element().LoadingText(value);
		}

		public  jQueryObject ShowLoadingText()
		{
			return Element().ShowLoadingText();
		}

		public  jQueryObject ResetLoadingText()
		{
			return Element().ResetLoadingText();
		}

		public  jQueryObject Toggle()
		{
			return Element().Toggle(); 
		}

		public new ButtonElement Element()
		{
			return (ButtonElement)base.Element();
		}
	}
}

