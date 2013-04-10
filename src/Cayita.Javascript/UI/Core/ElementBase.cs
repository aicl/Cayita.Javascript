using System.Html;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using jQueryApi;
using jQueryApi.UI.Interactions;
using System;

namespace Cayita.UI
{
		
	public abstract class ElementBase
	{
		static Dictionary<string,int> tags = new Dictionary<string,int>();
		Element element_;

		protected void SetElement(Element element)
		{
			element_ = element;
		}

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


		public jQueryObject JQuery()
		{
			return jQuery.FromElement(element_);
		}

		public jQueryObject JQuery(string selector)
		{
			return jQuery.Select(selector, element_);
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

		public void AppendTo(Element parent=null){
			(parent??Document.Body).Append(element_);
		}

		public void AppendTo(DocumentFragment parent){
			parent.AppendChild(element_);
		}

		public bool IsVisible()
		{
			return jQuery.FromElement(element_).Is(":visible");
		}

		public DraggableObject Draggable()
		{
			return jQuery.FromElement (element_).Draggable ();
		}

		public ResizableObject Resizable()
		{
			return jQuery.FromElement (element_).Resizable ();
		}


		public ElementBase Append(string content) 
		{
			jQuery.FromElement (element_).Append (content);
			return this;
		}


		public  ElementBase Append(Element content)
		{
			jQuery.FromElement (element_).Append (content);
			return this ;
		}


		public ElementBase Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			var e = new T ();
			Append (e.element_);
			content (e);
			return this;
		}
	}
	
}

