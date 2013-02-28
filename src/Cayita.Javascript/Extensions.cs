using System;
using System.Html;
using System.Collections.Generic;
using Cayita.Javascript.UI;
using System.Runtime.CompilerServices;
using jQueryApi;
using System.Diagnostics.CodeAnalysis;

namespace Cayita.Javascript
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	[ScriptName("Ext")]
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


		public static void LoadTo<T>(this FormElement form, T data) 
		{
			var o = (dynamic)data;
			var inputs = jQuery.Select ("[name]", form).GetElements();
			foreach(var input in inputs )
			{
				var ie = (InputElement)input;
				if(string.IsNullOrEmpty(ie.Name)) continue;
				try {
					o[ie.Name]= ie.GetValue();
				}
				catch(Exception)
				{}
			}
		}

		public static void Load<T>(this FormElement form, T data)
		{
			var d = (dynamic) data;
			var inputs = jQuery.Select ("[name]", form).GetElements();
			foreach(var input in inputs)
			{
				var ie = (InputElement)input;
				if(string.IsNullOrEmpty(ie.Name)) continue;
				ie.SetValue( (object) d[ie.Name] );
			}
		}


		public static T Find<T>(this FormElement form, [SyntaxValidation ("cssSelector")] string selector ) where T:class
		{
			return (form.JQuery(selector)[0]) as T;
		}

		public static T FindByName<T>(this FormElement form, string name ) where T:class
		{
			return (form.JQuery("[name="+name+"]")[0]) as T;
		}

		public static void CreateRow<T>(this TableElement table, T data, List<TableColumn<T>> columns, string recordIdProperty="Id" )
		{

			var r = new TableRow (default(Element), row =>  {
				row.SetAttribute("record-id", ((dynamic)data)[recordIdProperty]);
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

		public static void UpdateRow<T>(this TableElement table, T data, List<TableColumn<T>> columns, string recordIdProperty="Id")
		{
			var d = (dynamic) data;
			var row = table.JSelectRow((object) d[recordIdProperty]).Empty();
			foreach (var col in columns)
			{
				var c = col.Value(data);
				if (col.Hidden) c.Hide();
				row.Append( c);
			}
		}

		public static void RemoveRow<T>(this TableElement table, T data,  string recordIdProperty="Id")
		{
			var d = (dynamic) data;
			table.JSelectRow((object) d[recordIdProperty]).Remove();
		}

		public static void CreateHeader<T>(this TableElement table,  List<TableColumn<T>> columns)
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

		public static void CreateFooter<T>(this TableElement table,  List<TableColumn<T>> columns)
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


		public static void Load<T>(this TableElement table, IList<T> data,List<TableColumn<T>> columns, string recordIdProperty="Id", bool append=false )
		{
			Element body;
			if( table.tBodies.Length==0)
				body = new TableBody (table).Element ();
			else
			{
				body=table.tBodies[0];
				if(!append) body.JQuery().Empty();
			}
			
			foreach (var d in data) {
				new TableRow (body, row =>  {
					row.SetAttribute("record-id", ((dynamic)d)[recordIdProperty]);
					row.ClassName="rowlink";
					foreach(var col in columns)
					{
						var c = col.Value(d);
						if (col.Hidden) c.Hide();
						row.Append( c);
						if(col.AfterCellCreate!=null) col.AfterCellCreate(d, row);
					}
				});
			}
		}



	}
}
