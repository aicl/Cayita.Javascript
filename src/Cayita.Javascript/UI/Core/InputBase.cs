using System;
using System.Html;

namespace Cayita.UI
{

	public abstract class InputBase<T>:ElementBase<T> where T:ElementBase
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

		public T PlaceHolder(string placeholder)
		{
			if(!string.IsNullOrEmpty(placeholder))
				Element().SetAttribute("placeholder", placeholder);
			else
				Element().RemoveAttribute("placeholder");
			return this.As<T>();
		}

		public string PlaceHolder()
		{
			object placeholder=	 Element().GetAttribute("placeholder");
			return placeholder==null? string.Empty:placeholder.ToString();
		}
			
		public T Required(bool required){
			
			if(required)
			{
				Element().SetAttribute("required", "true");
			}
			else
			{
				Element().RemoveAttribute("required");
			}
			return this.As<T>();
		}
		
		public bool Required(){
			object rq=	 Element().GetAttribute("required");
			return rq==null? false: rq.ToString()=="required" || rq.ToString()=="true"? true:false;
		}
		
		
		public T RelativeSize (string relativeSize)
		{
			AddClass(relativeSize);
			return this.As<T>();
		}

		public T GridSize (string gridSize)
		{
			AddClass(gridSize);
			return this.As<T>();
		}

		public T Value(string value)
		{
			Element().SetValue(value); 
			return this.As<T>();
		}

		public string Value()
		{
			return Element().GetValue<string>();
		}

		public new InputElement Element()
		{
			return (InputElement)  base.Element() ;
		}


		public T Name(string name)
		{
			Element ().Name = name;
			return this.As<T>();
		}
		
		public string Name()
		{
			return Element ().Name;
		}

	}
}

