using System.Html;
using System.Collections.Generic;
using jQueryApi;
using jQueryApi.UI.Interactions;
using System;
using System.Runtime.CompilerServices;

namespace Cayita.UI
{
	public abstract class ElementBase<T>:ElementBase where T: ElementBase
	{
		public T ClassName(string cssClass)
		{
			base.Element().ClassName= cssClass;
			return As<T> ();
		}

		public T AddClass(string cssClass)
		{
			JQuery().AddClass(cssClass);
			return As<T> ();
		}

		public T RemoveClass()
		{
			JQuery().RemoveClass();
			return As<T> ();
		}


		public T RemoveClass(string cssClass)
		{
			JQuery().RemoveClass(cssClass);
			return As<T> ();
		}

		public T Disable(bool disable) 
		{
			base.Element ().Disabled = disable;
			return As<T> ();
		}

		public T Append(string content) 
		{
			JQuery().Append (content);
			return As<T> ();
		}
				
		public T Append(Element content)
		{
			JQuery().Append (content);
			return As<T> ();
		}
		
		public T Append(ElementBase content)
		{
			JQuery().Append (content.Element());
			return As<T> ();
		}

		public T Show()
		{
			Element ().Show ();
			return As<T> ();
		}

		public T Hide()
		{
			Element ().Hide ();
			return As<T> ();
		}
		
		public T SlideToggle()
		{
			Element ().SlideToggle ();
			return As<T> ();
		}
		
		public T FadeIn()
		{
			Element ().FadeIn ();
			return As<T> ();
		}
		
		public T FadeOut()
		{
			Element ().FadeOut ();
			return As<T> ();
		}
		
		public T FadeToggle()
		{
			Element ().FadeToggle ();
			return As<T> ();
		}

		public T Remove()
		{
			Element().Remove();
			return As<T> ();
		}
		
		public T Empty()
		{
			Element().Empty();
			return As<T> ();
		}

		public T AppendTo(Element parent=null){
			(parent??Document.Body).Append(Element());
			return As<T> ();
		}
		
		public T AppendTo(DocumentFragment parent){
			parent.AppendChild(Element());
			return As<T> ();
		}

	}

		
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


		public string SelectorById()
		{
			return element_.SelectorById ();
		}


		public string ClassName()
		{
			return element_.ClassName;
		}


		public Element Element()
		{
			return element_;
		}
					

		public jQueryObject JQuery()
		{
			return jQuery.FromElement(element_);
		}

		public jQueryObject JQuery(string selector)
		{
			return jQuery.Select(selector, element_);
		}


		public bool IsVisible()
		{
			return jQuery.FromElement(element_).Is(":visible");
		}

		public DraggableObject DraggableObject()
		{
			return jQuery.FromElement (element_).Draggable ();
		}

		public ResizableObject ResizableObject()
		{
			return jQuery.FromElement (element_).Resizable ();
		}


		protected internal ElementBase Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			var e = new T ();
			jQuery.FromElement(element_).Append (e.element_);
			content (e);
			return this;
		}

		[ScriptSkip]
		public TElement As<TElement> () where TElement : ElementBase
		{
			return (TElement)((object)null);
		}


	}


}

