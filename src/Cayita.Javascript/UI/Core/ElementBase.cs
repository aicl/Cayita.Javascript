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

		public T Append(jQueryObject content)
		{
			JQuery().Append (content);
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

		public T Text(string text)
		{
			Element ().Text (text);
			return As<T> ();
		}

		public string Text()
		{
			return Element ().Text ();
		}

		public T IconClass(string iconClass)
		{
			var i=JQuery ("i");
			if (i.Length == 0) {
				var ie =  Document.CreateElement("i");
				Append(ie);
				i= jQuery.FromElement(ie);
			}
			i.AddClass (iconClass??"");
			return As<T> ();
		}


	}

	public abstract class ElementBase
	{
		static Dictionary<string,int> tags = new Dictionary<string,int>();
		Element element_;


		public Style Style {
			get ;
			private set;
		}

		public string ID {
			get;
			private set;
		}

		protected void SetElement(Element element)
		{
			element_ = element;
		}

		protected void  CreateElement(string tagName, Element parent)
		{

			element_= Document.CreateElement(tagName);
			element_.ID= CreateId(tagName);
			if(parent!=null) parent.Append(element_);
			ID = element_.ID;
			Style = element_.Style;

		}

		protected string CreateId(string tagName)
		{
			int id;
			tags.TryGetValue(tagName, out id);
			tags[tagName]=++id;
			return string.Format("c-{0}-{1}",tagName,id);
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

		public string GetId()
		{
			return element_.ID;
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

