using System;
using jQueryApi;
using System.Html;
using System.Collections.Generic;

namespace Cayita
{

	public static partial class UI
	{

		public static TableCellAtom TableCellAtom(string rowId=null)
		{
			var e = Atom ("td").As<TableCellAtom>();
			if (!rowId.IsNullOrEmpty ())
				e.SetAttribute ("tr", rowId);

			e.SetToAtomProperty ("get_value", (Func<object>)(() => jQuery.FromElement (e).GetText ()));
			e.SetToAtomProperty ("set_value", (Action<object>)((v) => jQuery.FromElement (e).Text ((v??"").ToString())));

			e.SetToAtomProperty("set_getValueFn", (Action<Func<Element,object>>)(
				func=> e.SetToAtomProperty( "GetValue", (Func<object>)( ()=> func(e) ))));

			e.SetToAtomProperty ("set_setValueFn", (Action<Action<Element,object>>)(
				func => e.SetToAtomProperty ("setValue", (Action<object>)((v) => func (e, v)))));

			return e;

		}

		public static TableRowAtom TableRowAtom(string tableId=null) {
			var e =Atom ("tr").As<TableRowAtom>();
			e.CreateId ();
			if (!tableId.IsNullOrEmpty ())
				e.SetAttribute ("tb", tableId);

			e.SetToAtomProperty ("get_recordId", (Func<string>)(() => (e.GetAttribute ("record-id") ?? "").ToString ()));
			e.SetToAtomProperty ("set_recordId", (Action<string>)((v) => e.SetAttribute ("record-id", v)));

			e.SetToAtomProperty ("insertCell", (Func<int?,TableCellAtom>)(i => {
				if( !i.HasValue) i=-1;
				TableCellAtom rf = i.Value<0? e.GetLastCell(): e.GetCellByIndex(i.Value);

				var r = TableCellAtom(e.ID);
				if(rf==null)
					jQuery.FromElement(rf).Before(r);
				else
					e.Append(r);
				return r;

			}));

			e.SetToAtomProperty ("getFirstCell", (Func<TableCellAtom>)(
				(() => jQuery.Select ("td[tr={0}]:first".Fmt(e.ID), e).GetElement (0).As<TableCellAtom> ())));

			e.SetToAtomProperty ("getLastCell", (Func<TableCellAtom>)(
				(() => jQuery.Select ("td[tr={0}]:last".Fmt(e.ID), e).GetElement (0).As<TableCellAtom> ())));

			e.SetToAtomProperty ("getCellByIndex", (Func<int,TableCellAtom>)
			                     ((i) => jQuery.Select ("td[tr={0}]".Fmt(e.ID), e).Eq(i).GetElement (0).As<TableCellAtom> ()));


			e.SetToAtomProperty("addCell", (Action<TableCellAtom>)(c=>{
				c.SetAttribute("tr", e.ID);
				e.Append(c);
			}));

			return e;
		}


		public  static TableColumn<T> TableColumn<T>(string index,string header, 
		                                                   Action<T,TableCellAtom> val, bool? autoHeader )
			where T:new ()
		{
		var o = Cast<TableColumn<T>> (new { 
				header=default(string), 
				value=default(object), 
				footer= default(object), 
				hidden=false,
				afterCellCreated=default(object)
			});

			if(!index.IsNullOrEmpty()){
				if (string.IsNullOrEmpty (header) && (!autoHeader.HasValue || autoHeader.Value)) 
					header = index;

				if (!string.IsNullOrEmpty (header))
					o.Header = new  TableCellAtom { Value=header };

				if (val == null) 
					val = (t,c ) => c.Value = t.Get (index);

				o.Value = t => {
					var cell = new TableCellAtom ();
					val.Invoke (t,cell );
					return cell;
				};
			}
			return o;
		}


		public static List<TableColumn<T>> BuildColumns<T>(bool? autoHeader) where T: new ()
		{
			List<TableColumn<T>> cols = new List<TableColumn<T>> ();
			var o = new T ();
			var props= o.GetProperties ();
			foreach (var p in props) {
				cols.Add (TableColumn<T>(p,p,null, autoHeader));
			}
			return cols;
		}


		public static TableAtom TableAtom(){
			var t = Atom ("table",null, "table table-striped table-hover table-condensed").As<TableAtom>();
			t.CreateId ();
			t.TabIndex = -1;
			t.SetAttribute ("data-provides","rowlink");
			t.Body = Atom("tbody");
			t.Body.SetAttribute ("main", "main");
			t.Append (t.Body);

			t.SetToAtomProperty ("getRowByIndex", (Func<int,TableRowAtom>)
			                     ((i) => jQuery.Select ("tbody[main] tr[tb={0}]".Fmt(t.ID), t).Eq(i).GetElement (0).As<TableRowAtom> ()));

			t.SetToAtomProperty ("getLastRow", (Func<TableRowAtom>)
			                     (() => jQuery.Select ("tbody[main] tr[tb={0}]:last".Fmt(t.ID), t).GetElement (0).As<TableRowAtom> ()));

			t.SetToAtomProperty ("getFirstRow", (Func<TableRowAtom>)(
				() => jQuery.Select ("tbody[main] tr[tb={0}]:first".Fmt(t.ID), t).GetElement (0).As<TableRowAtom> ()));

			t.SetToAtomProperty("insertRow", (Func<int?,TableRowAtom>)( i=>{
				if( !i.HasValue) i=-1;
				TableRowAtom rf = i.Value<0? t.GetLastRow(): t.GetRowByIndex(i.Value);
			
				var r = TableRowAtom(t.ID);
				if(rf==null)
					jQuery.FromElement(rf).Before(r);
				else
					t.Body.Append(r);
				return r;
			}));

			t.SetToAtomProperty ("getRows", (Func<TableRowAtom[]>)(
				() => Cast<TableRowAtom[]> (jQuery.Select ("tbody[main] tr[tb={0}]".Fmt(t.ID), t).GetElements())));

			return t;
		}


		public static Table<T> Table<T>(List<TableColumn<T>> columns, string idProperty) 
			where T: Record, new ()
		{

			var e = Cast<Table<T>> (TableAtom ());

			e.Head = new TableHead ();
			e.Foot = new TableFoot ();
			jQuery.FromElement (e.Body).Before (e.Head).Before (e.Foot);

			Func<object,TableRowAtom> getRow =
				(d) => jQuery.Select ("tbody[main] tr[tb={0}][record-id={1}]".Fmt(e.ID,d.Get(e.IdProperty)),e).GetElement(0).As<TableRowAtom>();

			e.IdProperty =  idProperty.IsNullOrEmpty() ?"Id": idProperty;

			e.Columns = columns ?? BuildColumns<T> (true);


			e.SetToAtomProperty ("getRowById", (Func<object,TableRowAtom>)(
				(id) => jQuery.Select ("tbody[main] tr[tb={0}][record-id={1}]".Fmt(e.ID,id), e).GetElement (0).As<TableRowAtom> ()));


			e.SetToAtomProperty("addRow", (Action<T>)( d=>{
				var row = TableRowAtom(e.ID);
				row.RecordId=d.Get(e.IdProperty).ToString();
				row.ClassName="rowlink";
				foreach(var col in e.Columns){
					var c = col.Value(d);
					if (col.Hidden) c.Hidden=true;
					row.AddCell(c);
					if(col.AfterCellCreated!=null) col.AfterCellCreated(d, row);
				}
				e.Body.Append(row);
			}));


			e.SetToAtomProperty ("updateRow", (Action<T>)(d => {
				var row = getRow(d);
				row.Empty();
				foreach (var col in e.Columns)
				{
					var c = col.Value(d);
					if (col.Hidden) c.Hidden=true;
					row.AddCell(c);
					if(col.AfterCellCreated!=null) col.AfterCellCreated(d, row);
				}
			}));

			e.SetToAtomProperty ("removeRow", (Action<T>)(d => {
				getRow(d).Remove();
			}));


			e.SetToAtomProperty ("removeRowById", (Action<object>)(id => {
				e.GetRowById(id).Remove();
			}));

			e.SetToAtomProperty ("load", (Action<IList<T>,bool?>)( (list,append) => {

				if(!append.HasValue || !append.Value) e.Body.Empty();

				var fbody = Document.CreateDocumentFragment();

				foreach (var d in list) {
					var row = TableRowAtom (e.ID);
					row.RecordId= d.Get(e.IdProperty).ToString();
					row.ClassName="rowlink";
					foreach(var col in e.Columns)
					{
						var c = col.Value(d);
						if (col.Hidden) c.Hidden=true;
						row.AddCell( c);
						if(col.AfterCellCreated!=null) col.AfterCellCreated(d, row);
					}
					fbody.AppendChild(row);
				}
				e.Body.AppendChild (fbody);
			}));

			var h = new TableRowAtom();
			var f = new TableRowAtom();
			foreach (var col in  e.Columns) {
				if(col.Header!=null) {
					var c = col.Header;
					if (col.Hidden)
						c.Hidden = true;
					h.Append( c);
				}

				if(col.Footer!=null) {
					var c = col.Footer;
					if (col.Hidden)
						c.Hidden = true;
					f.Append( c);
				}
			}

			if (h.Cells.Length > 0)
				e.Head.Append (h);

			if (f.Cells.Length > 0)
				e.Foot.Append (f);

			return e;
		}


		public static TableBand CreateTableBand(string tagName)
		{
			return Atom (tagName).As<TableBand> ();
		}

		public static TableHead TableHead(){
			return CreateTableBand ("thead").As<TableHead> ();
		}

		public static TableFoot TableFoot(){
			return CreateTableBand ("tfoot").As<TableFoot> ();
		}

	}
}