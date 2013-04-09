using System;
using System.Html;

namespace Cayita.UI
{

	public abstract class InputBase:ElementBase
	{
		protected InputBase(){}

		public InputBase(Element parent,  string type)
		{
			CreateInput(parent, type);
		}

		protected void CreateInput(Element parent,  string type="text")
		{
			CreateElement("input", parent);
			if(!string.IsNullOrEmpty(type)) ((InputElement) Element()).Type=type;

		}

		public void PlaceHolder(string placeholder)
		{
			if(!string.IsNullOrEmpty(placeholder))
				Element().SetAttribute("placeholder", placeholder);
			else
				Element().RemoveAttribute("placeholder");
		}

		public string PlaceHolder()
		{
			object placeholder=	 Element().GetAttribute("placeholder");
			return placeholder==null? string.Empty:placeholder.ToString();
		}
			
		public void Required(bool required){
			
			if(required)
			{
				Element().SetAttribute("required", "true");
			}
			else
			{
				Element().RemoveAttribute("required");
			}
		}
		
		public bool Required(){
			object rq=	 Element().GetAttribute("required");
			return rq==null? false: rq.ToString()=="required" || rq.ToString()=="true"? true:false;
		}
		
		
		public void RelativeSize (string relativeSize)
		{
			AddClass(relativeSize);
		}

		public void GridSize (string gridSize)
		{
			AddClass(gridSize);
		}

		public void Value(string value)
		{
			Element().SetValue(value);
		}

		public string Value()
		{
			return Element().GetValue<string>();
		}


		public new InputElement Element()
		{
			return (InputElement)  base.Element() ;
		}
	}
}

