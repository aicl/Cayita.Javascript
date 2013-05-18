using System;
using System.Html;
using System.Collections.Generic;
using Cayita.UI;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Diagnostics.CodeAnalysis;

namespace Cayita.UI
{
	[Serializable]
	[IgnoreNamespace]
	public static  class Extensions
	{
		public static void Load<T>(this SelectElement cb,  IList<T> data, Func<T, OptionElement> func, bool append=false )
		{
			if(!append) cb.Empty();
			foreach( var d in data){
				cb.Append(func(d));
			}
		}

		public static void CreateOption<T>(this SelectElement cb, T data, Func<T, OptionElement> func)
		{
			cb.Append(func(data));
		}

		public static void UpdateOption<T>(this SelectElement cb, T data, Func<T, OptionElement> func, string recordIdProperty="Id" )
		{
			var old = cb.GetOption (data.Get (recordIdProperty));
			cb.ReplaceChild (func (data), old [0]);
		}

		public static void RemoveOption<T>(this SelectElement cb, T data,  string recordIdProperty="Id" )
		{
			cb.GetOption (data.Get (recordIdProperty)).Remove ();
		}

		[InlineCode("cayita.fn.loadTo({form},{data})")]
		public static void LoadTo<T>(this FormElement form, T data) 
		{
		}


		public static T LoadTo<T>(this FormElement form)  where T:new()
		{
			T data = new T();
			LoadTo(form, data);
			return data;
		}

		[InlineCode("cayita.fn.loadForm({form},{data})")]
		public static void Load<T>(this FormElement form, T data)
		{
		}

		[InlineCode("cayita.fn.clearForm({form})")]
		public static void Clear(this FormElement form)
		{
		}

		public static T Find<T>(this FormElement form, [SyntaxValidation ("cssSelector")] string selector ) where T:Element
		{
			return (form.JQuery(selector)[0]).As<T>() ;
		}

		public static T FindByName<T>(this FormElement form, string name ) where T:Element
		{
			return (form.JQuery("[name="+name+"]")[0]).As<T>();
		}

		public static T FindById<T>(this FormElement form, string id ) where T:Element
		{
			return (form.JQuery("[id="+id+"]")[0]).As<T>();
		}

		public static void CreateRow<T>(this TableElement table, T data, List<TableColumn<T>> columns, string recordIdProperty="Id" ) where T:new()
		{

			var r = new TableRow (default(Element), row =>  {
				row.SetAttribute("record-id", data.Get(recordIdProperty));
				row.ClassName="rowlink";
				foreach(var col in columns)
				{
					var c = col.Value(data);
					if (col.Hidden) c.Hide();
					row.Append( c);
					if(col.AfterCellCreate!=null) col.AfterCellCreate(data, row);
				}
			});
			table.Append(r.Element());
		}

		public static void UpdateRow<T>(this TableElement table, T data, List<TableColumn<T>> columns, string recordIdProperty="Id")  where T:new()
		{
			var row = table.GetRow(data.Get(recordIdProperty)).Empty();
			foreach (var col in columns)
			{
				var c = col.Value(data);
				if (col.Hidden) c.Hide();
				row.Append( c);
				if(col.AfterCellCreate!=null) col.AfterCellCreate(data, row.GetElement(0).As<TableRowElement>());
			}
		}

		public static void RemoveRow<T>(this TableElement table, T data,  string recordIdProperty="Id")
		{
			var d = (dynamic) data;
			table.GetRow((object) d[recordIdProperty]).Remove();
		}

		public static void CreateHeader<T>(this TableElement table,  List<TableColumn<T>> columns)  where T:new()
		{
			new TableHeader(table, th=>{
				new TableRow (th, row =>  {
					foreach(var col in columns)
					{
						if(col.Header==null) continue;
						var c = col.Header;
						if (col.Hidden) c.Hide();
						row.Append( c);
					}
				});
			});
		}

		public static void CreateFooter<T>(this TableElement table,  List<TableColumn<T>> columns)  where T:new()
		{
			new TableFooter(table, tf=>{
				new TableRow (tf, row =>  {
					foreach(var col in columns)
					{
						if(col.Footer==null) continue;
						var c = col.Footer;
						if (col.Hidden) c.Hide();
						row.Append( c);
					}
				});
			});
		}


		public static void Load<T>(this TableElement table, IList<T> data,List<TableColumn<T>> columns, string recordIdProperty="Id", bool append=false )  where T:new()
		{
			Element body;
			if( table.tBodies.Length==0)
				body = new TableBody (table).Element ();
			else
			{
				body=table.tBodies[0];
				if(!append) body.Empty();
			}
			var fbody = Document.CreateDocumentFragment();

			foreach (var d in data) {
				new TableRow (null, row =>  {
					row.SetAttribute("record-id", d.Get(recordIdProperty));
					row.ClassName="rowlink";
					foreach(var col in columns)
					{
						var c = col.Value(d);
						if (col.Hidden) c.Hide();
						row.Append( c);
						if(col.AfterCellCreate!=null) col.AfterCellCreate(d, row);
					}
				}).AppendTo(fbody);
			}
			body.AppendChild (fbody);
		}

		//
				
		/// <summary>
		/// Adds a item.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="item">Item.</param>
		public static void AddItem(this ListElement parent, string item )
		{
			var il = new ListItem(parent);
			new Anchor(il.Element(), a=>{
				a.Href= "#";
				a.Text(item);
			});
		}


		/// <summary>
		/// Adds the item.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="item">Item.</param>
		/// <param name="action">Action<jQueryEvent></para>.</param>
		public static void AddItem(this ListElement parent, string item, Action<jQueryEvent> action)
		{
			var il = new ListItem(parent);
			new Anchor(il.Element(), a=>{
				a.Href= "#";
				a.Text(item);
				a.OnClick(evt=> action(evt) );
			});

		}

		/// <summary>
		/// Adds a item.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="element">Action<Element,AnchorElement></param>
		public static void AddItem(this ListElement parent,
		                           Action<ListItemElement,AnchorElement> element)
		{
			var il = new ListItem(parent);
			var anchor = new Anchor(il.Element(), a=>{
				a.Href= "#";
			});
			element(il.Element(), anchor.Element()); 
		}


		public static void AddHeader(this ListElement parent, string item)
		{
			new ListItem(parent, l=>{
				l.ClassName="nav-header";
				l.Text(item);
			});
			
		}
		
		public static void  AddHDivider(this ListElement parent)
		{
			new ListItem(parent, l=>{
				l.ClassName="divider";
			});
			
		}

		public static void AddItem(this ListElement parent, string item, DropDownMenu menu)
		{
			var il = new ListItem(parent);
			il.ClassName ("dropdown");
			new Anchor(il.Element(), a=>{
				a.Href= "#";
				a.TabIndex=-1;
				a.ClassName="dropdown-toggle";
				a.SetAttribute("role","button");
				a.SetAttribute("data-toggle","dropdown");
				a.Text(item);
				a.Append(string.Format("<b class=\"caret{0}\"></b>",!parent.JQuery().HasClass("nav-list")?"":" pull-right"));
			});
			il.Append(menu);
		}

		public static void AddItem(this ListElement parent,  DropDownSubmenu submenu)
		{
			parent.Append (submenu);
		}

		//


		public static jQueryXmlHttpRequest Send (this FormData fd, string url)
		{
			return jQuery.Ajax ( new jQueryAjaxOptions{
				Url=url,
				Type="POST",
				Data= fd.AsTypeOption(),
				ProcessData=false,
				ContentType=""
			});
		}


		public static jQueryObject Text(this Element element, string value)
		{
			var ctxt=element.JQuery ("ctxt");
			if (ctxt.Length == 0) {
				var txt =  Document.CreateElement("ctxt");
				element.Append(txt);
				ctxt= jQuery.FromElement(txt);
			}
			return ctxt.Html (value??"");
		}
		
		
		public static string Text(this Element element)
		{
			return element.JQuery ("ctxt").GetText ();
		}


		//[InlineCode("$({parent}.element()).append({child})")]
		public static jQueryObject AppendTo(this jQueryObject child, ElementBase parent) 
		{
			return parent.GetMainElement ().Append (child);
		}

		//[InlineCode("$({parent}).append({child}.element())")]
		public static jQueryObject Append(this Element parent, ElementBase child) 
		{
			return parent.Append (child.GetMainElement ());
		}


	}
}
