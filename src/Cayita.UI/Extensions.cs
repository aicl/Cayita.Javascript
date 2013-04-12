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
			var d = (dynamic) data;
			var old= cb.GetOption( (object) d[recordIdProperty]);
			cb.ReplaceChild(func(data), old[0]);
		}
		
		public static void RemoveOption<T>(this SelectElement cb, T data,  string recordIdProperty="Id" )
		{
			var d = (dynamic) data;
			cb.GetOption( (object) d[recordIdProperty]).Remove();
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

		public static void CreateRow<T>(this TableElement table, T data, List<TableColumn<T>> columns, string recordIdProperty="Id" )
		{
			var r = new TableRow ( row =>  {
				row.SetAttribute("record-id", ((dynamic)data)[recordIdProperty]);
				row.ClassName="rowlink";
				foreach(var col in columns)
				{
					var c = col.Value(data);
					if (col.Hidden) c.Hide();
					row.Append(c);
					if(col.AfterCellCreate!=null) col.AfterCellCreate(data, row);
				}
			});
			table.Append(r.Element());
		}
		
		public static void UpdateRow<T>(this TableElement table, T data, List<TableColumn<T>> columns, string recordIdProperty="Id")
		{
			var d = (dynamic) data;
			var row = table.JSelectRow((object) d[recordIdProperty]).Empty();
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
			table.JSelectRow((object) d[recordIdProperty]).Remove();
		}
		
		public static void CreateHeader<T>(this TableElement table,  List<TableColumn<T>> columns)
		{
			new Element<TableHeader> ()
				.Append (new TableRow (row=>{
					foreach(var col in columns){
						if(col.Header==null) continue;
						var c = col.Header;
						if (col.Hidden) c.Hide();
						row.Append(c);
					}
				}));

		}
		
		public static void CreateFooter<T>(this TableElement table,  List<TableColumn<T>> columns)
		{
			new Element<TableFooter> ()
				.Append (new TableRow (row=>{
					foreach(var col in columns)
					{
						if(col.Footer==null) continue;
						var c = col.Footer;
						if (col.Hidden) c.Hide();
						row.Append( c);
					}
				}));
		}
		
		
		public static void Load<T>(this TableElement table, IList<T> data,List<TableColumn<T>> columns, string recordIdProperty="Id", bool append=false )
		{
			Element body;
			if (table.tBodies.Length == 0) {
				body = new TableBody ().Element ();
				table.Append(body);
			}
			else
			{
				body=table.tBodies[0];
				if(!append) body.Empty();
			}
			var fbody = Document.CreateDocumentFragment();
			
			foreach (var d in data) {
				new TableRow ( row =>  {
					row.SetAttribute("record-id", ((dynamic)d)[recordIdProperty]);
					row.ClassName="rowlink";
					foreach(var col in columns)
					{
						var c = col.Value(d);
						if (col.Hidden) c.Hide();
						row.Append( c);
						if(col.AfterCellCreate!=null) col.AfterCellCreate(d, row);
					}
					fbody.Append(row);
				});
			}
			body.AppendChild (fbody);
		}


		//
		
		public static void AddItem(this ListElement parent, string href, string item)
		{
			new  Element<ListItem>()
				.Append( new Anchor( a=> { a.Href=href; a.Text(item);}) )
					.AppendTo(parent);
		}
		
		/// <summary>
		/// Adds a item.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="item">Item.</param>
		public static void AddItem(this ListElement parent, string item )
		{
			new  Element<ListItem>()
				.Append( new Anchor( a=> { a.Href="#"; a.Text(item);}) )
					.AppendTo(parent);
		}
		
		/// <summary>
		/// Adds a item.
		/// </summary>
		/// <param name="parent">Parent.</param>
		/// <param name="element">Action<Element,AnchorElement></param>
		public static void AddItem(this ListElement parent,
		                           Action<ListElement,AnchorElement> element)
		{
			var anchor = new Anchor().Href("#").Element();
			var il = new ListItem( i => i.Append(anchor) ).Element();
			parent.Append (il);
			element(il, anchor); 
		}
		
		
		public static void AddHeader(this ListElement parent, string item)
		{
			new ListItem(i=>{
				i.ClassName="nav-header";
				i.Text(item).AppendTo(parent);
			});
						
		}
		
		public static void  AddHDivider(this ListElement parent)
		{
			new ListItem(i=>{
				i.ClassName="nav-header";
				parent.Append(i);
			});
			
		}
		
		
		//
		
	}
}
