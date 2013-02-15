using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{

	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public abstract class InputBase:ElementBase
	{
		protected InputBase(){}

		public InputBase(Element parent, InputConfig config, string type)
		{
			CreateInput(parent, config, type);
		}

		protected void CreateInput(Element parent, InputConfig config, string type="text")
		{
			CreateElement("input", parent, config);
			if(!string.IsNullOrEmpty(type)) ((InputElement) Element()).Type=type;
			PlaceHolder(config.Placeholder);
			Required(config.Required);
			if (!string.IsNullOrEmpty(config.RelativeSize)) RelativeSize(config.RelativeSize);
			if (!string.IsNullOrEmpty(config.GridSize)) GridSize(config.GridSize);
			if(!string.IsNullOrEmpty(config.Value)) Value(config.Value);
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
			return Element().GetValue();
		}


		public new InputElement Element()
		{
			return (InputElement)  base.Element() ;
		}
	}
}

