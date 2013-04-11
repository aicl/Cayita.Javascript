using System;
using System.Html;

namespace Cayita.UI
{
	public class Element<T>  where T: IHasElement, new ()
	{
		protected readonly Element El;
		T obj;
		
		public Element()
		{
			obj = new T ();
			El = obj.Element ();
		}
		
		
		public Element<T> Append<TChild>(TChild child) where TChild: IHasElement
		{
			El.Append(child.Element());
			return this;
		}
		
		
		public Element<T> Append<TChild>(Action<Element<TChild>> child) where TChild: IHasElement, new ()
		{
			var ch = new Element<TChild> ();
			child (ch);
			El.Append (ch.El); 
			return this;
		}
		
		public Element<T> Apply(Action<T> element)
		{
			element (obj);
			return this;
		}
		
		public Element<T> AppendTo(Element parent)
		{
			parent.Append (El);
			return this;
		}
		
	}
}

