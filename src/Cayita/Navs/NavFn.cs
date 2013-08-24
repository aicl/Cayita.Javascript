using System;
using jQueryApi;
using System.Html;
using System.Text;
using System.Collections.Generic;

namespace Cayita
{

	public static partial  class UI
	{
		public static string ItemSelector = "li[value]";
		public static Func<string,string> SelectFn = v => "li[value={0}]".Fmt (v);
		public static string SelectEventName = "item.select";
		public static string BrandEventName = "brand.click";
		public static string BrandSelector = ".brand";

		public static NavBar NavBar(){

			var e = new Div ("navbar").As<NavBar> ();

			var ar = new Anchor ("btn btn-navbar");
			ar.SetAttribute ("data-toggle", "collapse");


			for(int i =0; i<3; i++){
				var sp = new Span ("icon-bar");
				jQuery.FromElement(ar).Append (sp);
			}

			var collapse = new Div ("nav-collapse collapse");
			ar.SetAttribute ("data-target", "#"+collapse.CreateId() );

			var nav = Nav ();
			collapse.Append (nav);

			var cf = new Div ("container-fluid");
			jQuery.FromElement(cf).Append (ar).Append (collapse);

			var nbi = new Div ("navbar-inner");
			jQuery.FromElement(nbi).Append (cf);

			jQuery.FromElement (e).Append (nbi);


			nav.SetToAtomProperty ("$brand", null);

			nav.SetToAtomProperty ("get_brandText", (Func<string>)(()=>{
				if (e.Brand==null) return "";
				return e.Brand.Text;
			}));

			nav.SetToAtomProperty ("set_brandText", (Action<string>)(v => {

				var fli= jQuery.Select (BrandSelector, cf);

				if (fli.Length == 0){ 
					e.Brand=new Anchor("brand",text:v);
					jQuery.FromElement (collapse).Before ( e.Brand );
				}
				else
					e.Brand.Text=v;

			}));

			nav.SetToAtomProperty ("add_brandClicked", (Action<jQueryEventHandler>)((ev) =>
			    On (cf, BrandEventName, ev, BrandSelector)));

			nav.SetToAtomProperty ("remove_brandClicked", (Action<jQueryEventHandler>)((ev) =>
			    Off(cf, BrandEventName , ev, BrandSelector)));


			nav.SetToAtomProperty("isInverse",
			                      (Func<bool>)( ()=>  jQuery.FromElement(e).HasClass("navbar-inverse")));

			nav.SetToAtomProperty("inverse",(Action<bool?>)( v=> {
				if(!v.HasValue || v.Value)
					jQuery.FromElement(e).AddClass("navbar-inverse");
				else
					jQuery.FromElement(e).RemoveClass("navbar-inverse");
			}));

			e.DefineAtomProperty ("nav", new {value=nav, writable=false});

			e.DefineAtomProperty("get_text", (Func<string>)( ()=> e.BrandText ));
			e.DefineAtomProperty ("set_text",(Action<string>)((v) => e.BrandText = v));

			collapse.SetToAtomProperty ("addElement", (Action<Element>)(collapse.Append));

			e.DefineAtomProperty ("collapse", new {value=collapse, writable=false});

			jQuery.FromElement (cf).On ("click", BrandSelector, ev => {
				ev.PreventDefault();

				var j= jQuery.FromElement(ev.CurrentTarget);
				if(j.HasClass("disabled") ) return ;
				j.Trigger(BrandEventName);

			});
					
			return e;
		}


		public static NavList NavList(Atom parent =null)
		{
			var e = new Div ("well sidebar-nav").As<NavList>();

			var nav = Nav ("nav-list");
			jQuery.FromElement (e).Append (nav);

			nav.SetToAtomProperty ("get_header", (Func<string>)(() => e.GetFromAtomProperty ("$header").ToString () ?? ""));
			nav.SetToAtomProperty ("set_header", (Action<string>)((v) => {
				e.SetToAtomProperty ("$header", v);
				var fli= jQuery.Select ("li:first", e.Nav);

				if (fli.Length == 0) {
					jQuery.FromElement (e.Nav).Append (new HtmlListItem("nav-header", v));
				} else if (fli.HasClass ("nav-header")) 
					fli.Html (BuildText (v));
				else {
					fli.Before (new HtmlListItem ("nav-header", v));
				}
			}));

			e.DefineAtomProperty ("nav", new {value=nav, writable=false});

			e.SetToAtomProperty("get_text", (Func<string>)(()=> e.Header) );
			e.SetToAtomProperty("set_text", (Action<string>)((v)=> e.Header=v) );

			if (parent != null)
				parent.Append (e);

			return e;
		}


		public static NavItem NavItem(string value, string text, jQueryEventHandler handler, bool disable, string iconClassName)
		{
			var i = new HtmlListItem ().As<NavItem>();
			i.SetAttribute ("value", value);

			if (disable)
				jQuery.FromElement (i).AddClass ("disabled");

			var icon = new CssIcon (iconClassName);
			var anchor = new Anchor ();
			jQuery.FromElement (anchor).Append (icon);
			anchor.Text = text??value;

			jQuery.FromElement (i).Append (anchor);


			DefineAtomProperty (i, "$icon", new {value=icon, writable=false});
			DefineAtomProperty (i, "$anchor", new {value=anchor, writable=false});
			DefineAtomProperty (i, "handler", new {value=handler, writable=true});

			SetToAtomProperty (i, "get_text", (Func<string>)(() => i.Anchor.Text));
			SetToAtomProperty (i, "set_text", (Action<string>)((v) => i.Anchor.Text=v));

			SetToAtomProperty (i, "get_value", (Func<string>)(() => i.GetAttribute ("value").ToString () ?? "" ));
			SetToAtomProperty (i, "set_value", (Action<string>)((v) => i.SetAttribute ("value", v) ));

			SetToAtomProperty (i, "get_iconClass", (Func<string>)(() => i.Icon.ClassName));
			SetToAtomProperty (i, "set_iconClass", (Action<string>)((v) => i.Icon.ClassName = v));

			SetToAtomProperty (i, "isDisabled", (Func<bool>)(() =>
			             jQuery.FromElement (i).HasClass ("disabled")));

			SetToAtomProperty (i, "disable",(Action<bool>)((d) =>{
				if(d)jQuery.FromElement (i).AddClass ("disabled");
				else jQuery.FromElement (i).RemoveClass ("disabled");
			}));

			i.Clicked += ev=>{
				if( i.Disabled ) return;
				var h = i.Handler;
				if (h!=null) h(ev);
			};

			return i;

		}


		public static Nav Nav(string navType=null)
		{
			var l = CreateNavBase (navType);

			jQuery.FromElement (l).On ("click", ItemSelector, e => {
				e.PreventDefault();

				var j= jQuery.FromElement(e.CurrentTarget);
				if(j.HasClass("disabled") ) return ;

				jQuery.Select("li",e.GetDelegateTarget()).RemoveClass("active");
				j.AddClass("active");
				j.Trigger(SelectEventName);

			});
			return l;
		}


		public static Nav CreateNavBase(string navType=null)
		{
			var l = new HtmlList ("nav{0}".Fmt (navType.IsNullOrEmpty()?"":" "+navType)).As<Nav>();

			l.SetToAtomProperty("addDropdownMenu", (Action<DropdownMenu> )(m=>{
				var i = new HtmlListItem();
				m.AddTo(i);
				if(l.ClassList.Contains("nav-list")) jQuery.Select(".caret",m).AddClass("pull-right");
				l.Append(i);
			}));

			l.SetToAtomProperty("addDropdownSubmenu", (Action<DropdownSubmenu> )(m=>{
				var i = new HtmlListItem();
				m.AddTo(i);
				l.Append(i);
			}));

			l.SetToAtomProperty ("addItem", (Action<HtmlListItem>)((i) => jQuery.FromElement (l).Append (i)));

			l.SetToAtomProperty ("removeItem", (Action<string>)
			                     ((v) => jQuery.Select (SelectFn(v), l).Remove ()));

			l.SetToAtomProperty ("removeAll", (Action)(() => jQuery.FromElement (l).Empty ()));

			l.SetToAtomProperty ("disableItem", (Action<string,bool?>)((v,d) => {
				var j = jQuery.Select (SelectFn(v), l);
				if (!d.HasValue || d.Value)
					j.AddClass ("disabled");
				else
					j.RemoveClass ("disabled");
			}));

			l.SetToAtomProperty ("disableAll", (Action<bool?>)((d) => {
				var j = jQuery.Select (ItemSelector, l);
				if (!d.HasValue || d.Value)
					j.AddClass ("disabled");
				else
					j.RemoveClass ("disabled");
			}));

			l.SetToAtomProperty ("addValue", (Action<string,string,jQueryEventHandler,bool,string>)
			                     ((v,t,h,d,i) => l.Add (new NavItem(v, t, h, d, i))));

			l.SetToAtomProperty ("addDivider", (Action<string>)((v) => l.Add (new HtmlListItem(v))));

			l.SetToAtomProperty ("loadList", (Action<IEnumerable<string>>)((list) => {
				StringBuilder s = new StringBuilder ();
				int v = 0;
				foreach (var d in list) {
					s.Append (new NavItem( (v++).ToString(), d).OuterHTML);
				}
				jQuery.FromElement (l).Append (s.ToString());
			}));

			l.SetToAtomProperty ("loadNavItemList", (Action<IEnumerable<NavItem>>)((lst) => {
				StringBuilder s = new StringBuilder ();
				foreach (var d in lst) {
					s.Append (d.OuterHTML);
				}
				jQuery.FromElement (l).Append (s.ToString());
			}));

			l.SetToAtomProperty ("loadData", (Action<IEnumerable<object>,Func<object,NavItem>>)((lst,fn) => {
				StringBuilder s = new StringBuilder ();
				foreach (var d in lst) {
					s.Append (fn(d).OuterHTML);
				}
				jQuery.FromElement (l).Append (s.ToString());
			}));


			l.SetToAtomProperty ("getItem", (Func<string, NavItem>)(v => {
				var j = jQuery.Select (SelectFn(v), l);
				if(j.Length== 0) return null;
				return j.GetElement(0).As<NavItem>();
			}));

			l.SetToAtomProperty ("selectItem", (Action<string>)(v => {
				var j = jQuery.Select (SelectFn(v), l);
				if(j.Length==0 || j.HasClass("disabled")) return;
				j.Trigger(SelectEventName);
			}));

			l.SetToAtomProperty ("add_selected", (Action<jQueryEventHandler>)
			                     (ev => On(l, SelectEventName , ev, ItemSelector)));

			l.SetToAtomProperty ("remove_selected", (Action<jQueryEventHandler>)
			                     (ev => Off (l,SelectEventName, ev, ItemSelector)));

			return l;
		}

	}
}

