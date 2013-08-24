using System;
using jQueryApi;
using System.Html;
using jQueryApi.UI.Widgets;

namespace Cayita
{

	public static partial class UI
	{
		public static CheckField CheckField(string name,  string text, Action<Field<bool>> action, Atom parent)
		{
			var e= Field<bool> (()=> 
				UI.BooleanCheck("", name, text)	, action, parent
			).As<CheckField> ();


			return e;
		}


		public static TextAreaField TextAreaField(string name, string placeholder, Action<Field<string>> action, Atom parent)
		{
			return Field<string> (()=> UI.Input<string>("textarea",null, null,name,placeholder),
			                      action, parent).As<TextAreaField> ();

		}

		public static SelectField<T> SelectField<T>(string type, Action<Field<T>> action, Atom parent)
		{
			return Field<T> (()=> UI.SelectInput<T>(type),
			                      action, parent).As<SelectField<T>> ();

		}


		public static TextField TextField(string name, string placeholder, Action<Field<string>> action, Atom parent)
		{
			return Field<string> (()=> 
				UI.Input<string>("input","text",null,name,placeholder), action, parent
			).As<TextField> ();

		}

		public static PasswordField PasswordField(string name, string placeholder, Action<Field<string>> action, Atom parent)
		{
			return Field<string> (
				() => UI.Input<string> ("input", "password", null, name, placeholder), action, parent).As<PasswordField> ();

		}

		public static EmailField EmailField(string name, string placeholder, Action<Field<string>> action, Atom parent)
		{
			return Field<string> (
				() => UI.Input<string> ("input", "email", null, name, placeholder), action, parent).As<EmailField> ();

		}


		public static NumericField NumericField(string name, string placeholder, Action<Field<decimal>> action, Atom parent)
		{
			return Field<decimal> (()=>
				UI.NumericInput(name:name, placeholder:placeholder),action, parent
			).As<NumericField> ();

		}

		public static NullableNumericField NullableNumericField(string name, string placeholder,Action<Field<decimal?>> action, Atom parent)
		{
			return Field<decimal?> (
				()=> UI.NullableNumericInput(name:name, placeholder:placeholder),action, parent
			).As<NullableNumericField> ();
		}


		public static IntField IntField(string name, string placeholder, Action<Field<int>> action, Atom parent)
		{
			return Field<int> (
				() => UI.IntInput (name:name, placeholder: placeholder),action, parent
			).As<IntField> ();
		}

		public static NullableIntField NullableIntField(string name, string placeholder,Action<Field<int?>> action, Atom parent)
		{
			return Field<int?> (
				() => UI.NullableIntInput (name:name, placeholder: placeholder), action, parent
			).As<NullableIntField> ();
		}
	
		public static DateField DateField(DatePickerOptions options, string name, string placeholder,Action<DateField> action, Atom parent)
		{
			var e= Field<DateTime> (() => UI.DateInput (options)).As<DateField> ();
			e.SetToAtomProperty("get_picker", (Func<DatePickerObject>)(()=> e.Input.Picker));

			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);

			return e;
		}

		public static NullableDateField NullableDateField(DatePickerOptions options,string name, string placeholder,Action<NullableDateField> action, Atom parent)
		{
			var e = Field<DateTime?> (() => UI.NullableDateInput (options)).As<NullableDateField> ();
			e.SetToAtomProperty("get_picker", (Func<DatePickerObject>)(()=> e.Input.Picker));

			if (action != null)
				action (e);
			if (parent != null)
				parent.Append (e);

			return e;
		}



		public static Field<T> Field<T>(Func<Input<T>> factory, Action<Field<T>> action=null, Atom parent=null)
		{
			var e = UI.ControlGroup ().As<Field<T>> ();
			var cg = e.MainObject;
			var input = factory ();
			jQuery.FromElement (e.Controls).Append (input.ParentNode??input);

			UI.DefineProperty (cg, "input", new {value=(object)input, writable=false});

			UI.SetToProperty (cg, "appendAddon", (Action<Element>)( (c) => AppendAddon<T> (e, c)));
			UI.SetToProperty (cg, "appendStringAddon", (Action<string>)( (c) => AppendStringAddon<T> (e, c)));

			UI.SetToProperty (cg, "prependAddon", (Action<Element>)( (c) => PrependAddon<T> (e, c)));
			UI.SetToProperty (cg, "prependStringAddon", (Action<string>)( (c) => PrependStringAddon<T> (e, c)));

			e.SetToAtomProperty ("add_changed", (Action<jQueryEventHandler>)
			                     (ev => e.Input.Changed+= ev));

			e.SetToAtomProperty ("removed_changed", (Action<jQueryEventHandler>)
			                     (ev => e.Input.Changed-= ev));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}

		static void AppendAddon<T>(Field<T> field, Element atom){

			jQuery.FromElement(field.Controls).AddClass ("input-append");

			if( atom.TagName=="BUTTON"  )
			{
				jQuery.FromElement (field.Input).After (jQuery.FromElement(atom));
			}
			else
			{
				var sp = UI.Atom("span",null,"add-on" );
				jQuery.FromElement( sp).Append(atom);
				jQuery.FromElement (field.Input).After (jQuery.FromElement(sp));
			}

		}


		static void AppendStringAddon<T>(Field<T> field, string content)
		{
			jQuery.FromElement(field.Controls).AddClass ("input-append");
			var sp = UI.Atom("span",null,"add-on" );
			jQuery.FromElement (sp).Append (content);
			jQuery.FromElement (field.Input).After (jQuery.FromElement(sp));

		}


		static void PrependAddon<T>(Field<T> field, Element atom)
		{
			jQuery.FromElement(field.Controls).AddClass ("input-prepend");
			if( atom.TagName=="BUTTON"  )
			{
				jQuery.FromElement (field.Input).Before (jQuery.FromElement(atom));
			}
			else
			{
				var sp = UI.Atom("span",null,"add-on" );
				jQuery.FromElement( sp).Append(atom);
				jQuery.FromElement (field.Input).Before (jQuery.FromElement(sp));
			}
		}


		static void PrependStringAddon<T>(Field<T> field, string content)
		{
			jQuery.FromElement(field.Controls).AddClass ("input-prepend");
			var sp = UI.Atom("span",null,"add-on" );
			jQuery.FromElement( sp).Append(content);
			jQuery.FromElement (field.Input).Before (jQuery.FromElement(sp));
		}


		public static FileFieldBase CreateFileFieldBase(Func<FileInput> factory)
		{
			var e = UI.ControlGroup ().As<FileFieldBase> ();
			var cg = e.MainObject;
			var input = factory ();

			jQuery.FromElement(e.Controls).AddClass("fileupload fileupload-new");
			e.Controls.SetAttribute ("data-provides", "fileupload");

			var divInput = new Div ("input-append");
			var spanFile = new Span ("btn btn-file");

			var spanFileOpen = new Span ("fileupload-new");
			e.FileOpenIcon = new CssIcon ("icon-folder-open");
			jQuery.FromElement(spanFileOpen).Append (e.FileOpenIcon);

			var spanFileChange = new Span ("fileupload-exists");
			e.FileChangeIcon  = new CssIcon ("icon-folder-open");
			jQuery.FromElement(spanFileChange).Append (e.FileChangeIcon);

			jQuery.FromElement (spanFile).Append (spanFileOpen).Append (spanFileChange).Append (input);

			var anchorFileRemove = new Anchor ("btn fileupload-exists");
			anchorFileRemove.SetAttribute ("data-dismiss","fileupload");
			e.FileRemoveIcon = new CssIcon ("icon-remove");
			jQuery.FromElement(anchorFileRemove).Append (e.FileRemoveIcon);

			jQuery.FromElement (divInput).Append (spanFile).Append (anchorFileRemove);

			jQuery.FromElement(e.Controls).Append (divInput);

			UI.DefineProperty (cg, "input", new {value=(object)input, writable=false});

			UI.SetToProperty (cg, "appendAddon", (Action<Element>)( (c) => AppendAddon<string> (e, c)));
			UI.SetToProperty (cg, "appendStringAddon", (Action<string>)( (c) => AppendStringAddon<string> (e, c)));

			UI.SetToProperty (cg, "prependAddon", (Action<Element>)( (c) => PrependAddon<string> (e, c)));
			UI.SetToProperty (cg, "prependStringAddon", (Action<string>)( (c) => PrependStringAddon<string> (e, c)));


			UI.SetToProperty(cg, "set_fileOpenText", (Action<string>)((c)=> spanFileOpen.Text=c ));
			UI.SetToProperty(cg, "get_fileOpenText", (Func<string>)(()=> spanFileOpen.Text ));

			UI.SetToProperty(cg, "set_fileChangeText", (Action<string>)((c)=> spanFileChange.Text=c ));
			UI.SetToProperty(cg, "get_fileChangeText", (Func<string>)(()=> spanFileChange.Text ));

			UI.SetToProperty(cg, "set_FileRemoveText", (Action<string>)((c)=> anchorFileRemove.Text=c ));
			UI.SetToProperty(cg, "get_fileRemoveText", (Func<string>)(()=> anchorFileRemove.Text ));

			e.SetToAtomProperty ("add_changed", (Action<jQueryEventHandler>)
			                     (ev => e.Input.Changed+= ev));

			e.SetToAtomProperty ("removed_changed", (Action<jQueryEventHandler>)
			                     (ev => e.Input.Changed-= ev));

			return e;
		}

		public static FileField FileField(string name, string placeholder, Action<FileField> action, Atom parent)
		{
			var e = CreateFileFieldBase (()=> UI.FileInput(null,name,placeholder)).As<FileField>();
			var uneditable = new Div ("uneditable-input span3");

			jQuery.FromElement (uneditable).Append (new CssIcon("icon-file fileupload-exists"))
				.Append( new Span("fileupload-preview"));

			jQuery.Select(".btn-file", e.Controls).Before (uneditable);

			var cg = e.MainObject;
			UI.SetToProperty (cg,"$inputSize", "span3");
			UI.SetToProperty(cg, "get_inputSize", (Func<string>)( ()=>GetInputSize(e)));
			UI.SetToProperty(cg, "set_inputSize", (Action<string>)( (v)=>SetInputSize(e,v)));
			UI.SetToProperty (cg,"uneditable", uneditable);
			UI.SetToProperty (cg,"hidePreview",
			                      (Action<bool>)( (v)=> HideFileBox(e, v) ));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}


		public static ImgField ImgField(string name, string placeholder, Action<ImgField> action, Atom parent)
		{
			var e = CreateFileFieldBase (()=> UI.FileInput(null,name,placeholder)).As<ImgField>();
			e.Accept = "image/*";

			var thumbnail = new Div ("fileupload-new thumbnail");
			thumbnail.Style.CssText = "width:{0}; height:{1};".Fmt ("200px", "150px");

			var emptyImage = new Image ();
			emptyImage.Src = UI.EmptyImgSrc;
			jQuery.FromElement(thumbnail).Append (emptyImage);

			var thumbnailPreview= new Div ("fileupload-preview fileupload-exists thumbnail");
			thumbnailPreview.Style.CssText = "width:{0}; height:{1};".Fmt ("200px", "150px");

			jQuery.Select(".input-append", e.Controls).RemoveClass("input-append")
				.Before(thumbnail)
					.Before(thumbnailPreview);

			var cg = e.MainObject;
			UI.SetToProperty (cg,"emptyImg", emptyImage);
			UI.SetToProperty (cg,"thumbnail", thumbnail);
			UI.SetToProperty (cg,"thumbnailPreview", thumbnailPreview);
			UI.SetToProperty (cg,"hidePreview",
			                      (Action<bool>)( (v)=> HideImgBox(e, v) ));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}

		static void SetInputSize(FileField field, string value){
			jQuery.FromElement (field.Uneditable).RemoveClass ( "{0}".Fmt( field.InputSize )).AddClass (value);
			UI.SetToProperty (field.MainObject, "$inputSize", value);
		}

		static string GetInputSize(FileField field){

			return UI.GetFromProperty(field.MainObject, "$inputSize").ToString();
		}

		static void HideFileBox (FileField field, bool hide){
			var j = jQuery.FromElement (field.Uneditable);
			if (hide)
				j.Hide ();
			else
				j.Show ();
		}

		static void HideImgBox (ImgField field, bool hide){
			var j = jQuery.FromElement (field.Thumbnail);
			var q = jQuery.FromElement (field.ThumbnailPreview);
			if (hide) {
				j.Hide ();
				q.Hide ();
			} else {
				j.Show ();
				q.Show ();
			}
		}


	}
}
