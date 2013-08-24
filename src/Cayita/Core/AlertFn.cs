using System;
using System.Html;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[PreserveMemberCase]
	public static class AlertFn
	{

		public static Func<string,string> ErrorTmpl= m=> 
			"<div class='alert alert-block alert-error'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>".
				Fmt(m);


		public static Func<string,string> SuccessTmpl= m=>
			"<div class='alert alert-block alert-success'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>"
				.Fmt(m);


		public static Func<string,string> InfoTmpl= m=>
			"<div class='alert alert-block alert-success'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>"
				.Fmt(m);

		public static Func<string,string> WarningTmpl= m=>
			"<div class='alert alert-block alert-success'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>"
				.Fmt(m);

		public static Func<string,string,string> PageAlertTmpl= (m,t)=>
			"<div class='alert{0}'><a class='close' data-dismiss='alert' href='#'>×</a>{1}</div>".Fmt(
				string.IsNullOrEmpty(t)?"":" alert-"+t, m);

		public static int PageAlertZIndex=1040;

		public static string ErrorTemplate()
		{
			return "<div class='alert alert-block alert-error'><a class='close' data-dismiss='alert' href='#'>×</a>{0}</div>";
		}

		public static void Error(Element element, string message, bool before=false, int delay=0)
		{
			Imp (element, message, before, delay, ErrorTmpl);
		}

		public static void Success(Element element, string message, bool before=false, int delay=0)
		{
			Imp (element, message, before, delay, SuccessTmpl);
		}


		public static void Info(Element element, string message, bool before=false, int delay=0)
		{
			Imp (element, message, before, delay, InfoTmpl);
		}


		public static void Warning(Element element, string message, bool before=false , int delay=0)
		{
			Imp (element, message, before, delay, WarningTmpl);
		}


		public static void PageAlert(Element parent, string message, string type="", int delay=0)
		{

			var jq = jQuery.Select ( PageAlertTmpl (message, type));


			var j = jQuery.Select (".page-alert", parent);

			if (j.Length == 0) {
				j = jQuery.Select ("<div class='page-alert' style='z-index:{0};position:fixed;'></div>".Fmt(PageAlertZIndex));
				jQuery.FromElement (parent).Append (j);
			}

			j.Append (jq);

			if (delay > 0)
				((Action)(() => jq.Remove ())).RunAfter (delay);

		}

		static void Imp( Element element, string message, bool before, int delay, Func<string,string> tmplFn)
		{
			var jq = jQuery.Select (tmplFn(message));
			if (before)
				jq.InsertBefore (element);
			else
				jq.InsertAfter (element);

			if (delay > 0)
				((Action)(()=> jq.Remove())).RunAfter (delay);
		}
	}
}
