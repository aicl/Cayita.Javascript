using System;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{
	public static class Alert
	{

		public static string ErrorTemplate()
		{
			return "<div class='alert alert-block alert-error'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}
		
		public static jQueryObject Error(Element element, string message, bool before=true)
		{
			var jq = jQuery.Select (string.Format (ErrorTemplate (), message));
			return before ? jq.InsertBefore (element) : jq.InsertAfter (element);
		}
				
		//-------------------------------------------------------------------------------------
		
		public static string SuccessTemplate()
		{
			return "<div class='alert alert-block alert-success'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}
		
		public static jQueryObject Success(Element element, string message, bool before=true)
		{
			var jq = jQuery.Select (string.Format (SuccessTemplate (), message));
			return before ? jq.InsertBefore (element) : jq.InsertAfter (element);
		}


		//-------------------------------------------------------------------------------------
		
		public static string InfoTemplate()
		{
			return "<div class='alert alert-block alert-info'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}
		
		public static jQueryObject Info(Element element, string message, bool before=true)
		{
			var jq = jQuery.Select (string.Format (InfoTemplate (), message));
			return before ? jq.InsertBefore (element) : jq.InsertAfter (element);
		}
		
		//-------------------------------------------------------------------------------------


		public static string WarningTemplate()
		{
			return "<div class='alert alert-block'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}
		
		public static jQueryObject Warning(Element element, string message, bool before=true)
		{
			var jq= jQuery.Select (string.Format (WarningTemplate (), message));
			return before ? jq.InsertBefore (element) : jq.InsertAfter (element);
		}
		
		//-------------------------------------------------------------------------------------

		
		public static Div PageAlert(string message, string type="")
		{
			var div = new Div( de=>{
				de.ClassName=string.Format( "alert{0}", string.IsNullOrEmpty(type)?"":"alert-"+type);
				new Anchor(de, element=>{
					element.Href="#";
					element.ClassName="close";
					element.SetAttribute("data-dismiss","alert");
					element.Text("×");
				});
				de.Append(message);
			});
			div.AppendTo (Document.Body);
			return div;  
		}


	}
}

