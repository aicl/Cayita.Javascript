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
			return Field<bool> (()=> 
				UI.BooleanCheck("", name, text)	, action, parent
			).As<CheckField> ();
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
			e.Input = factory ();

			jQuery.FromElement (e.Controls).Append (e.Input.ParentNode??e.Input);


			UI.SetToProperty (e, "appendAddon", (Action<Element>)( (c) => AppendAddon<T> (e, c)));
			UI.SetToProperty (e, "appendStringAddon", (Action<string>)( (c) => AppendStringAddon<T> (e, c)));

			UI.SetToProperty (e, "prependAddon", (Action<Element>)( (c) => PrependAddon<T> (e, c)));
			UI.SetToProperty (e, "prependStringAddon", (Action<string>)( (c) => PrependStringAddon<T> (e, c)));

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
			e.Input = factory ();

			jQuery.FromElement(e.Controls).AddClass("fileupload fileupload-new");
			e.Controls.SetAttribute ("data-provides", "fileupload");

			e._divinput = new Div ("input-append");
			e._spanfile = new Span ("btn btn-file");

			e._spanfileopen = new Span ("fileupload-new");
			e.FileOpenIcon = new CssIcon ("icon-folder-open");
			jQuery.FromElement(e._spanfileopen).Append (e.FileOpenIcon);

			var spanFileChange = new Span ("fileupload-exists");
			e.FileChangeIcon  = new CssIcon ("icon-folder-open");
			jQuery.FromElement(spanFileChange).Append (e.FileChangeIcon);

			jQuery.FromElement (e._spanfile).Append (e._spanfileopen).Append (spanFileChange).Append (e.Input);

			var anchorFileRemove = new Anchor ("btn fileupload-exists");
			anchorFileRemove.SetAttribute ("data-dismiss","fileupload");
			e.FileRemoveIcon = new CssIcon ("icon-remove");
			jQuery.FromElement(anchorFileRemove).Append (e.FileRemoveIcon);

			jQuery.FromElement (e._divinput).Append (e._spanfile).Append (anchorFileRemove);

			jQuery.FromElement(e.Controls).Append (e._divinput);


			UI.SetToProperty (e, "appendAddon", (Action<Element>)( (c) => AppendAddon<string> (e, c)));
			UI.SetToProperty (e, "appendStringAddon", (Action<string>)( (c) => AppendStringAddon<string> (e, c)));

			UI.SetToProperty (e, "prependAddon", (Action<Element>)( (c) => PrependAddon<string> (e, c)));
			UI.SetToProperty (e, "prependStringAddon", (Action<string>)( (c) => PrependStringAddon<string> (e, c)));


			UI.SetToProperty(e, "set_fileOpenText", (Action<string>)((c)=> e._spanfileopen.Text=c ));
			UI.SetToProperty(e, "get_fileOpenText", (Func<string>)(()=> e._spanfileopen.Text ));

			UI.SetToProperty(e, "set_fileChangeText", (Action<string>)((c)=> spanFileChange.Text=c ));
			UI.SetToProperty(e, "get_fileChangeText", (Func<string>)(()=> spanFileChange.Text ));

			UI.SetToProperty(e, "set_FileRemoveText", (Action<string>)((c)=> anchorFileRemove.Text=c ));
			UI.SetToProperty(e, "get_fileRemoveText", (Func<string>)(()=> anchorFileRemove.Text ));

			e.SetToAtomProperty ("add_changed", (Action<jQueryEventHandler>)
			                     (ev => e.Input.Changed+= ev));

			e.SetToAtomProperty ("removed_changed", (Action<jQueryEventHandler>)
			                     (ev => e.Input.Changed-= ev));

			return e;
		}

		public static FileField FileField(string name, string placeholder, Action<FileField> action, Atom parent)
		{
			var e = CreateFileFieldBase (()=> UI.FileInput(null,name,placeholder)).As<FileField>();
			e._uneditable= new Div ("uneditable-input span3");
			e._inputSize = "span3";

			jQuery.FromElement (e._uneditable).Append (new CssIcon("icon-file fileupload-exists"))
				.Append( new Span("fileupload-preview"));

			jQuery.Select(".btn-file", e.Controls).Before (e._uneditable);


			UI.SetToProperty(e, "get_inputSize", (Func<string>)( ()=>GetInputSize(e)));
			UI.SetToProperty(e, "set_inputSize", (Action<string>)( (v)=>SetInputSize(e,v)));

			UI.SetToProperty (e,"hidePreview",
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

			e.Thumbnail= new Div ("fileupload-new thumbnail");
			e.Thumbnail.Style.CssText = "width:{0}; height:{1};".Fmt ("200px", "150px");

			e.EmptyImg = new Image ();
			e.EmptyImg.Src = UI.EmptyImgSrc;
			jQuery.FromElement(e.Thumbnail).Append (e.EmptyImg);

			e.ThumbnailPreview= new Div ("fileupload-preview fileupload-exists thumbnail");
			e.ThumbnailPreview.Style.CssText = "width:{0}; height:{1};".Fmt ("200px", "150px");

			jQuery.Select(".input-append", e.Controls).RemoveClass("input-append")
				.Before(e.Thumbnail)
					.Before(e.ThumbnailPreview);

			UI.SetToProperty (e,"hidePreview",
			                      (Action<bool>)( (v)=> HideImgBox(e, v) ));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}

		static void SetInputSize(FileField field, string value){
			jQuery.FromElement (field._uneditable).RemoveClass ( "{0}".Fmt( field.InputSize )).AddClass (value);
			field._inputSize = value;
		}

		static string GetInputSize(FileField field){
			return field._inputSize;

		}

		static void HideFileBox (FileField field, bool hide){
			var j = jQuery.FromElement (field._uneditable);
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
