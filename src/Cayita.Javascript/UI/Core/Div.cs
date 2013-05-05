using System;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{

	public class Div:ElementBase<Div>
	{

		public Div (Action<DivElement> element)
		{
			CreateElement ("div", null);
			element.Invoke (Element ());
		}


		public Div (Element parent,  Action<DivElement> element)
		{
			CreateElement ("div", parent);
			element.Invoke (Element ());
		}

		public Div (Element parent=null)
		{
			CreateElement ("div", parent);

		}

		public new DivElement Element()
		{
			return (DivElement)base.Element ();
		}

		public static Div CreateControlGroup(Element parent){
			return new Div(parent, div=>{
				div.ClassName="control-group";
			});
		}

		public static Div CreateControlGroup(Element parent,Action<DivElement> element ){
			var d= new Div(parent, div=>{
				div.ClassName="control-group";
			});
			element(d.Element());
			return d;
		}


		public static Div CreateControls(Element parent){
			return new Div(parent, div=>{
				div.ClassName="controls";
			});
		}

		public static Div CreateControls(Element parent,Action<DivElement> element )
		{
			var d= new Div(parent, div=>{
				div.ClassName="controls";
			});
			element(d.Element());
			return d;
		}


		public static Div CreateContainer(Element parent){
			return new Div(parent, div=>{
				div.ClassName="container";
			});
		}
		
		public static Div CreateContainer(Element parent,Action<DivElement> element )
		{
			var d= new Div(parent, div=>{
				div.ClassName="container";
			});
			element(d.Element());
			return d;
		}

		public static Div CreateContainerFluid(Element parent){
			return new Div(parent, div=>{
				div.ClassName="container-fluid";
			});
		}
		
		public static Div CreateContainerFluid(Element parent,Action<DivElement> element )
		{
			var d= new Div(parent, div=>{
				div.ClassName="container-fluid";
			});
			element(d.Element());
			return d;
		}


		public static Div CreateRow(Element parent){
			return new Div(parent, div=>{
				div.ClassName="row";
			});
		}
		
		public static Div CreateRow(Element parent,Action<DivElement> element )
		{
			var d= new Div(parent, div=>{
				div.ClassName="row";
			});
			element(d.Element());
			return d;
		}

		public static Div CreateRowFluid(Element parent){
			return new Div(parent, div=>{
				div.ClassName="row-fluid";
			});
		}
		
		public static Div CreateRowFluid(Element parent,Action<DivElement> element )
		{
			var d= new Div(parent, div=>{
				div.ClassName="row-fluid";
			});
			element(d.Element());
			return d;
		}
	

		public new Div Append<T>(Action<T> content) where T: ElementBase<T>, new()
		{ 
			base.Append<T> (content);
			return this;
		}
		
		public Div Style(Action<Style> style)
		{
			style (Element ().Style);
			return this;
		}
				


	}
}