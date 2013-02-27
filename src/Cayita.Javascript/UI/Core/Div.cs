using System;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita.Javascript.UI
{
	
	[ScriptNamespace("Cayita.UI")]
	public class Div:ElementBase
	{
		public Div (Element parent,  Action<DivElement> element)
		{
			CreateElement("div", parent);
			element(Element()); 
		}

		public Div (Element parent)
		{
			CreateElement("div", parent);

		}

		public new DivElement Element()
		{
			return (DivElement) base.Element();
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
	

		public static Div CreateAlert(Element parent, string message, string type)
		{
			var div = new Div(parent, de=>{
				de.ClassName= "alert alert-"+type;
				new Anchor(de, element=>{
					element.Href="#";
					element.ClassName="close";
					element.SetAttribute("data-dismiss","alert");
					element.InnerText="×";
					
				});
				de.JQuery().Append(message);
			});
			return div;  
		}

		//-------------------------------------------------------------------------------------

		public static string AlertErrorTemplate()
		{
			return "<div class='alert alert-block alert-error'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}

		public static jQueryObject CreateAlertErrorBefore(Element element, string message)
		{
			return jQuery.Select(string.Format(Div.AlertErrorTemplate(), message)).InsertBefore(element);
		}

		public static jQueryObject CreateAlertErrorAfter(Element element, string message)
		{
			return jQuery.Select(string.Format(Div.AlertErrorTemplate(), message)).InsertAfter(element);
		}

		//-------------------------------------------------------------------------------------

		public static string AlertSuccessTemplate()
		{
			return "<div class='alert alert-block alert-success'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}
		
		public static jQueryObject CreateAlertSuccessBefore(Element element, string message)
		{
			return jQuery.Select(string.Format(Div.AlertSuccessTemplate(), message)).InsertBefore(element);
		}
		
		public static jQueryObject CreateAlertSuccessAfter(Element element, string message)
		{
			return jQuery.Select(string.Format(Div.AlertSuccessTemplate(), message)).InsertAfter(element);
		}

		//-------------------------------------------------------------------------------------

		public static string AlertInfoTemplate()
		{
			return "<div class='alert alert-block alert-info'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}
		
		public static jQueryObject CreateAlertInfoBefore(Element element, string message)
		{
			return jQuery.Select(string.Format(Div.AlertInfoTemplate(), message)).InsertBefore(element);
		}
		
		public static jQueryObject CreateAlertInfoAfter(Element element, string message)
		{
			return jQuery.Select(string.Format(Div.AlertInfoTemplate(), message)).InsertAfter(element);
		}
		
		//-------------------------------------------------------------------------------------


		public static Div CreatePageAlertError(Element element, string message)
		{
			var div = new Div(element, de=>{
				de.ClassName="page-alert";
				Div.CreateAlert(de, message,"error");
			});
			return div;
		}

	}
}