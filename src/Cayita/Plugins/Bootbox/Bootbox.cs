using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Html;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("bootbox")]
	public static class Bootbox
	{

		public static void Alert(string message){
		}

		public static void Alert(string message, string label, Action callback=null){
		}

		public static void Alert(string message, Action callback){
		}


		public static void  Confirm (string message){
		}

		public static void  Confirm (string message, string cancel, string confirm, Action<bool> callback=null ){
		}

		public static void  Confirm (string message, Action<bool> callback ){
		}


		public static void Prompt(string message)
		{
		}

		public static void Prompt(string message, string cancel, string confirm,
		                          Action<string> callback=null, string defaultValue="")
		{
		}

		public static void Prompt(string message,  Action<string> callback )
		{
		}


		[InlineCode("Cayita.Plugins.showBootboxDialog({message},null,{options})")]
		public static void Dialog(string message, BootboxOptions options =null){}

		[InlineCode("Cayita.Plugins.showBootboxDialog({message},{handler},{options})")]
		public static void Dialog(string message, BootboxHandler handler, BootboxOptions options =null){}


		public static void Dialog(Element content, BootboxOptions options =null){
			Dialog (content.InnerHTML, options);
		}


		public static void Dialog(Element content, BootboxHandler handler, BootboxOptions options =null){
			Dialog (content.InnerHTML, handler, options);
		}


		public static void Dialog(string message, IEnumerable<BootboxHandler> handlers, BootboxOptions options=null){}


		public static void Animate(bool value){
		}

		public static void Backdrop(bool value){
		}

		public static void Classes(string value){
		}

		public static void SetIcons(object value){
		}

		public static void SetBtnClasses(object value){
		}

		public static void SetLocale(string value){
		}


		// (string locale, object value) => object {OK:"OK trans", ...}  == > BootboxObject => {OK:, CANCEL: CONFIRM:}
		public static void AddLocale(object value){
		}

/*
		bootbox.animate(boolean)
			Indicate whether dialogs should animate in and out.

				bootbox.backdrop(string)
				Set the dialog backdrop value—values as per Bootstrap's modals.

bootbox.classes(string)
Any custom classes to add to the dialog.

bootbox.setIcons(object)  // {OK:"ok-icon , CANCEL: 'cancel-icon', CONFIRM:'confirm-icon'}
Establish which icons to show for default OK, Cancel and Confirm buttons.

bootbox.setLocale(string)
Set the language for the default OK, Cancel and Confirm buttons. Values: en, fr, de, es, br, nl, ru, it.

bootbox.addLocale(object) : 
'en' : {
            OK      : 'OK',
            CANCEL  : 'Cancel',
            CONFIRM : 'OK'
        },
*/

	}
}

