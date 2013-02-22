using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using jQueryApi;

namespace Cayita.Javascript.UI
{
		
	[ScriptNamespace("Cayita.UI")]
	public abstract class ElementBase
	{
		static Dictionary<string,int> tags = new Dictionary<string,int>();
		Element element_;

		protected void  CreateElement(string tagName, Element parent)
		{

			element_= Document.CreateElement(tagName);
						
			element_.ID= CreateId(tagName);

			if(parent!=null) parent.Append(element_);
		}

		protected string CreateId(string tagName)
		{
			int id;
			tags.TryGetValue(tagName, out id);
			tags[tagName]=++id;
			
			return string.Format("cyt-{0}-{1}",tagName,id);
		}


		public string SelectorById(){
			return element_.SelectorById();
		}


		public void ClassName(string cssClass)
		{
			if(!string.IsNullOrEmpty(cssClass))
			{
				element_.ClassName= cssClass;
			}

		}

		public string ClassName()
		{
			return element_.ClassName;
		}

		public jQueryObject AddClass(string cssClass)
		{
			return jQuery.FromElement(element_).AddClass(cssClass);
		}

		public jQueryObject RemoveClass(string cssClass)
		{
			return jQuery.FromElement(element_).RemoveClass(cssClass);
		}


		public jQueryObject RemoveClass()
		{
			return jQuery.FromElement(element_).RemoveClass();
		}

		public Element Element()
		{
			return element_;
		}
					
		public  jQueryObject Show()
		{
			return element_.Show();
		}


		public  jQueryObject Hide()
		{
			return element_.Hide ();
		}
		
		public  jQueryObject SlideToggle()
		{
			return jQuery.FromElement(element_).SlideToggle();
		}

		public jQueryObject FadeIn()
		{
			return jQuery.FromElement(element_).FadeIn();
		}

		public jQueryObject FadeOut()
		{
			return jQuery.FromElement(element_).FadeOut();
		}

		public jQueryObject FadeToggle()
		{
			return jQuery.FromElement(element_).FadeToggle();
		}


		public jQueryObject JSelect()
		{
			return jQuery.FromElement(element_);
		}

		public jQueryObject Remove()
		{
			return jQuery.FromElement(element_).Remove();
		}

		public jQueryObject Empty()
		{
			return jQuery.FromElement(element_).Empty();
		}


		public void Name(string name)
		{
			if(!string.IsNullOrEmpty(name))
				element_.SetAttribute("name", name);
			else
				element_.RemoveAttribute("name");
		}
		
		public string Name()
		{
			object name= element_.GetAttribute("name");
			return name==null? string.Empty:name.ToString();
		}

		public void AppendTo(Element parent){
			parent.Append(element_);
		}

	}
	
}

