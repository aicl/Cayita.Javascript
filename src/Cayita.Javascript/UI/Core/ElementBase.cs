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
			GetMainElement().ClassName= cssClass;
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
			JQuery ().Append (content.GetMainElement ());
			return As<T> ();
		}
		
		public T Append(jQueryObject content)
		{
			JQuery().Append (content);
			return As<T> ();
		}
		
		
		public T ShowTab()
		{
			GetMainElement ().Show ();
			return As<T> ();
		}
		
		public T Hide()
		{
			GetMainElement ().Hide ();
			return As<T> ();
		}

		public T Show()
		{
			GetMainElement ().Show();
			return As<T> ();
		}

		public T SlideToggle()
		{
			GetMainElement().SlideToggle ();
			return As<T> ();
		}
		
		public T FadeIn()
		{
			GetMainElement ().FadeIn ();
			return As<T> ();
		}
		
		public T FadeOut()
		{
			GetMainElement ().FadeOut ();
			return As<T> ();
		}
		
		public T FadeToggle()
		{
			GetMainElement ().FadeToggle ();
			return As<T> ();
		}
		
		public T Remove()
		{
			GetMainElement().Remove();
			return As<T> ();
		}
		
		public T Empty()
		{
			GetMainElement().Empty();
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
		
		public T AppendTo(ElementBase parent){
			
			parent.GetMainElement().Append ( GetMainElement ());
			return As<T> ();
		}
		
		public T Text(string text)
		{
			GetMainElement ().Text (text);
			return As<T> ();
		}
		
		public string Text()
		{
			return GetMainElement ().Text ();
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

		public T Popover(PopoverOptions options)
		{
			new Popover (GetMainElement (), options);
			return As<T> ();
		}

		public T Popover( Action<PopoverOptions> config )
		{
			var options = new PopoverOptions ();
			config (options);
			return Popover (options);
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
			ID = GetMainElement ().ID;
			Style = GetMainElement().Style;
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
			return GetMainElement().SelectorById ();
		}
		
		
		public string ClassName()
		{
			return GetMainElement().ClassName;
		}
		
		
		public Element Element()
		{
			return element_;
		}
		
		
		public jQueryObject JQuery()
		{
			return jQuery.FromElement(GetMainElement());
		}
		
		public jQueryObject JQuery(string selector)
		{
			return jQuery.Select(selector, GetMainElement());
		}
		
		
		public bool IsVisible()
		{
			return jQuery.FromElement(GetMainElement()).Is(":visible");
		}
		
		public DraggableObject DraggableObject()
		{
			return jQuery.FromElement (GetMainElement()).Draggable ();
		}
		
		public ResizableObject ResizableObject()
		{
			return jQuery.FromElement (GetMainElement()).Resizable ();
		}
		
		public string GetId()
		{
			return GetMainElement().ID;
		}
		
		
		protected internal ElementBase Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			var e = new T ();
			jQuery.FromElement(element_).Append (e.element_);
			content (e);
			return this;
		}
		
		protected internal Element GetMainElement()
		{
			var self = (dynamic)this;
			var cgf = self ["get_controlGroup"];
			if (cgf!=null) 
			{
				var cg= self["get_controlGroup"]();
				return cg["element"]();
			}
			
			return Element ();
		}
		
		
		[ScriptSkip]
		public TElement As<TElement> () where TElement : ElementBase
		{
			return (TElement)((object)null);
		}
		
		
	}
	
	
}

