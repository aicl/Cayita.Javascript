using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Html;
using jQueryApi;

namespace Cayita.UI
{
	public static class Bootbox
	{

		/// <summary>
		/// Alertbox
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="label">Custom button text. Default=OK.</param>
		/// <param name="callback">Callback invoked on dismissal. Default= null.</param>
		[InlineCode ("bootbox.alert({message}, {label}, {callback})")]
		public static void Alert(string message, string label="OK", Action callback=null){}


		/// <summary>
		/// Confirmbox
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="cancel">Custom cancel button text.</param>
		/// <param name="confirm">Custon confirm button text.</param>
		/// <param name="callback">Callback invoked on dismissal.</param>
		[InlineCode ("bootbox.confirm({message}, {cancel}, {confirm}, {callback})")]
		public static void Confirm(string message, string cancel="Cancel", string confirm="OK", Action<bool> callback=null)
		{}

		/// <summary>
		/// Promptbox
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="cancel">Custom cancel button text.</param>
		/// <param name="confirm">Custon confirm button text.</param>
		/// <param name="callback">Callback invoked on dismissal.</param>
		/// <param name="defaultValue">Default value.</param>
		[InlineCode("bootbox.prompt({message}, {cancel}, {confirm}, {callback}, {defaultValue})")]
		public static void Prompt(string message, string cancel="Cancel", string confirm="OK", Action<string> callback=null, string defaultValue="")
		{
		}

		[InlineCode("bootbox.dialog({message}, {buttons}, {options})")]
		static void DialogImpl (string message, DialogOptions options, IList<DialogButton> buttons )
		{
		}

		[InlineCode("bootbox.dialog({body}, {buttons}, {options})")]
		static void DialogImpl (jQueryObject body, DialogOptions options, IList<DialogButton> buttons )
		{
		}

		/// <summary>
		/// Dialogbox
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="options">Options.</param>
		/// <param name="buttons">Buttons.</param>
		//[InlineCode("bootbox.dialog({message}, {buttons}, {options})")]
		public static void Dialog (string message, DialogOptions options, IList<DialogButton> buttons=null )
		{
			DialogImpl (message, options, buttons ?? new List<DialogButton> ());
		}

		public static void Dialog (string message, Action<DialogOptions> options, Action<List<DialogButton>> buttons=null)
		{
			var opt = new DialogOptions ();
			if( options!=null)  options (opt);

			var bt = new List<DialogButton>();

			if (buttons != null) {

				buttons(bt);
			}
			DialogImpl (message, opt, bt);
		}

		public static void Dialog (Element body, Action<DialogOptions> options=null, Action<List<DialogButton>> buttons=null)
		{
			Dialog (body.JQuery(), options, buttons);
		}

		public static void Dialog (ElementBase body, Action<DialogOptions> options=null, Action<List<DialogButton>> buttons=null)
		{
			Dialog (body.JQuery(), options, buttons);
		}

		public static void Dialog (jQueryObject body, Action<DialogOptions> options=null, Action<List<DialogButton>> buttons=null)
		{
			var opt = new DialogOptions ();
			if (options != null)
				options (opt);
			
			var bt = new List<DialogButton>();
			if (buttons != null)				
				buttons (bt);

			DialogImpl (body, opt, bt);
		}

		public static void Dialog(string message, string caption="<br/>" )
		{
			DialogImpl (message, new DialogOptions{Header=caption} , new List<DialogButton>());
		}

		public static void Error(string message, string caption="Error")
		{
			DialogImpl (message, new DialogOptions{
				Header=string.Format("<p style=\"color:red;\"><i class=\"icon-minus-sign\" style=\"margin-top:8px;margin-right:8px;\"></i>{0}</p>",
				                     caption)
			}, new List<DialogButton>());
		}


	}

	/// <summary>
	/// Dialog options.
	/// </summary>

	[Serializable]
	public class DialogOptions
	{
		public DialogOptions()
		{
			Header = null;
			Classes = null;
			OnEscape = () => {};
		}

		public string Header { get; set; }
		public bool? Animate { get; set; }
		public string Classes { get; set; }
		public Action OnEscape { get; set; }

	}

	[Serializable]
	public class DialogButton
	{
		public DialogButton()
		{
			Callback = () => {};
		}
		public string Label { get; set; }
		public string Class { get; set; }
		public Action Callback { get; set; }
	}

}
/*
var _locale        = 'en',
        _defaultLocale = 'en',
        _animate       = true,
        _backdrop      = 'static',
        _defaultHref   = 'javascript:;',
        _classes       = '',
        _btnClasses    = {},
        _icons         = {},
         //last var should always be the public object we'll return 
that           = {};
*/