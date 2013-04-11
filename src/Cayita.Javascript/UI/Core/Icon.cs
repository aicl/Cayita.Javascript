using System;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{

	public class Element<T>  where T: IHasElement, new ()
	{
		Element el;
		T obj;

		public Element()
		{
			obj = new T ();
			el = obj.Element ();
		}


		public Element<T> Append<TChild>(TChild child) where TChild: IHasElement
		{
			el.Append(child.Element());
			return this;
		}


		public Element<T> Append<TChild>(Action<Element<TChild>> child) where TChild: IHasElement, new ()
		{
			var ch = new Element<TChild> ();
			child (ch);
			el.Append (ch.el); 
			return this;
		}

		public Element<T> Apply(Action<T> element)
		{
			element (obj);
			return this;
		}

		public Element<T> AppendTo(Element parent)
		{
			parent.Append (el);
			return this;
		}

	}

	public interface IHasElement
	{
		Element Element ();
	}


	public abstract class CayitaElement:IHasElement
	{
		Element e;

		public CayitaElement(string tagName)
		{
			e = Document.CreateElement (tagName);
			Firebug.Console.Log (" CayitaElement e, tagname", e, tagName);
		}

		protected Element GetElement (){
			return e;
		}

		public Element Element ()
		{
			return e;
		}

		public Style Style()
		{
			return e.Style; 
		}

		public void Style(Action<Style> style)
		{
			style (e.Style);
		}

		public jQueryObject JQuery()
		{
			return jQuery.FromElement (e);
		}

		public void JQuery( Action<jQueryObject> jquery)
		{
			jquery( jQuery.FromElement (e));
		}

		public void ClassName(string value)
		{
			e.ClassName = value;
		}

		public jQueryObject AddClass(string value)
		{
			return jQuery.FromElement (e).AddClass (value);
		}

		public jQueryObject RemoveClass(string value)
		{
			return jQuery.FromElement (e).RemoveClass (value);
		}

		public jQueryObject AddHtml(string value)
		{
			return jQuery.FromElement (e).AddHtml(value);
		}


	}

	public class MyDiv:CayitaElement
	{

		public MyDiv ():base("div")
		{
			Firebug.Console.Log ("Div base.Element", base.Element ());
		}

		public string SomeMethod()
		{
			Firebug.Console.Log("MyDiv SomeMethod");
			return "X";
		}

		public new DivElement Element()
		{
			return GetElement().As<DivElement> ();
		}


	}

	public class MySpan:CayitaElement
	{


		public MySpan():base("span")
		{
		}

		public MySpan(Action<MySpan> span):this()
		{
			span (this);
		}

		public MySpan Text(string value)
		{
			base.Element().InnerHTML = value;
			return this;
		}
	
	}

	public  class MyInput:CayitaElement
	{


		public MyInput():base("input")
		{

		}

		public MyInput(Action<MyInput> input):this()
		{
			input (this);
		}

		public new  InputElement Element()
		{
			return GetElement ().As<InputElement> ();
		}
	}


	public class MyInputText:MyInput
	{
		public MyInputText():base()
		{
			Element ().Type = "text";
		}

		public MyInputText(Action<MyInputText> input):this()
		{
			input (this);
		}

		public new TextElement Element()
		{
			return GetElement ().As<TextElement> ();
		}

	}


	public class MyTest
	{
		public MyTest()
		{

			var div = new Element<MyDiv> ().Append (new MySpan (s=>{
				s.Text("Hola Munod 0");
				s.Style(st=> { st.Color="white"; st.BackgroundColor="black";});
			}))
				.Apply (d => {
					d.Style(st=>{ st.BorderColor="red"; st.BackgroundColor="blue"; });
					d.SomeMethod(); 
				});
			
			Firebug.Console.Log ("div", div);

			var div1 = new Element<MyDiv> ().Append (new MySpan ().Text("HELLO WORLD") )
				.Apply (d => {
					d.Style(st=>{ st.BorderColor="red"; st.BackgroundColor="blue"; });
					d.SomeMethod();
				});

			Firebug.Console.Log ("div1", div1);

			var div2 = new Element<MyDiv> ()
				.Append<MySpan> (c => {
					c.Apply( e=> {e.Text("hola mundo").Style(st=>st.Color="green"); });
				});

			Firebug.Console.Log ("div2", div2);

			var div3 = new Element<MyDiv> ()
				.Append<MySpan> (c => {
					c.Apply(e=>e.Text("hola mundo"));
				})
					.Append<MySpan>(e =>{
						e.Apply(m=>{m.Text("hello word").Style().Color="orange";});
					})
					.Append( new MyInput( t=>{
						t.Element().Name="NOMBRE";
						t.AddClass("input-class");
						t.Element().Value="Un valor INicia";
					}));
			
			Firebug.Console.Log ("div3", div3);

			div3.AppendTo (Document.Body);
		}
	}



	public class Icon:ElementBase
	{

		public Icon()
		{
			CreateElement("i",null);
		}

		public Icon(Element parent,  Action<Element> element)
		{
			CreateElement("i", parent);
			element(Element());
		}

		public Icon( Element parent)
		{
			CreateElement("i", parent);
		}

		public new Icon Append<T>(Action<T> content) where T: ElementBase, new()
		{ 
			base.Append<T> (content);
			return this;
		}

		public Icon Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}

		public new Icon ClassName(string className)
		{
			Element ().ClassName = className;
			return this;
		}

		public new Icon RemoveClass(string className)
		{
			JQuery ().RemoveClass (className);
			return this;
		}

		public new Icon AddClass(string className)
		{
			JQuery ().AddClass (className);
			return this;
		}

	}
}

