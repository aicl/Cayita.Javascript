using System;
using System.Html;
using jQueryApi;
using System.Collections.Generic;

namespace Cayita.UI
{
	public abstract class CayitaElement:IHasElement
	{

		static Dictionary<string,int> tags = new Dictionary<string,int>();

		protected readonly Element El;
		
		public CayitaElement(string tagName)
		{
			El = Document.CreateElement (tagName);
			El.ID = CreateId (tagName);
		}
		
		
		public  Element Element ()
		{
			return El;
		}
		
		public Style Style()
		{
			return El.Style; 
		}
		
		public void Style(Action<Style> style)
		{
			style (El.Style);
		}
		
		public jQueryObject JQuery()
		{
			return jQuery.FromElement (El);
		}
		
		public void JQuery( Action<jQueryObject> jquery)
		{
			jquery( jQuery.FromElement (El));
		}
		
		public void ClassName(string value)
		{
			El.ClassName = value;
		}
		
		public jQueryObject AddClass(string value)
		{
			return jQuery.FromElement (El).AddClass (value);
		}
		
		public jQueryObject RemoveClass(string value)
		{
			return jQuery.FromElement (El).RemoveClass (value);
		}
		
		public jQueryObject AddHtml(string value)
		{
			return jQuery.FromElement (El).AddHtml(value);
		}
		

		public jQueryObject Append(Element child)
		{
			return El.Append (child);
		}

		public jQueryObject Append(CayitaElement child)
		{
			return El.Append (child.El);
		}

		public jQueryObject AppendTo(Element parent)
		{
			return  parent.Append (El);
		}


		public jQueryObject AppendTo(CayitaElement parent)
		{
			return parent.El.Append( El);
		}

		string CreateId(string tagName)
		{
			int id;
			tags.TryGetValue(tagName, out id);
			tags[tagName]=++id;
			
			return string.Format("c-{0}-{1}",tagName,id);
		}
	}

}

