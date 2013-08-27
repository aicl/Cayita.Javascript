using System;
using jQueryApi;
using System.Html;

namespace Cayita
{

	public static partial  class UI
	{

		public static DropdownTab DropdownTab(TabPanel parent , string text, string iconClass)
		{
			var o = UI.Cast<DropdownTab> (DropdownMenu(text,iconClass));

			o.SetToAtomProperty ("add", (Action<Tab>)((tab) => {
				o.Nav.Add(tab.Item);
				parent.Content.Append (tab.Body);
			}));

			var i = new HtmlListItem ("dropdown");
			jQuery.FromElement (i).Append (o).Append (o.Nav);
			parent.Links.Append (i);
			return o;
		}

		public static Tab Tab(string title, Element content, bool? disabled)
		{


			var a = UI.Cast<Tab> (new Anchor("", null, title));
			a.Body = new Div ("tab-pane");
			a.Body.CreateId ();
			a.Href = "#" + a.Body.ID;

			if(content!=null)
				jQuery.FromElement (a.Body).Append (content);

			a.SetAttribute("data-toggle", "tab");

			a.Item = new HtmlListItem();
			a.Item.SetAttribute("index", a.Body.ID);
			a.Item.Append(a);

			UI.SetToProperty(a, "get_caption", (Func<string>)(()=>a.Text));
			UI.SetToProperty(a, "set_caption", (Action<string>)(v=>a.Text=v));


			UI.SetToProperty(a, "is_disabled", (Func<bool>)(()=>a.Item.ClassList.Contains("disabled")));
			UI.SetToProperty(a, "disable", (Action<bool?>)((v)=>{
				if(!v.HasValue || v.Value){
					a.ClassList.Add("disabled");
					a.Item.ClassList.Add("disabled");
				}
				else{
					a.ClassList.Remove("disabled");
					a.Item.ClassList.Remove("disabled");
				}
			}));

			if (disabled.HasValue && disabled.Value)
				a.Disabled = true;

			a.ClickHandler = p => jQuery.FromElement (a).Execute ("tab", "show");

			return a;
		}


		public static TabPanelOptions TabPanelOptions(bool? bordered, string tabsPosition, string navType, bool? stacked )
		{
			TabPanelOptions po = UI.Cast<TabPanelOptions>( new {} );
			po.Bordered = bordered.HasValue ? bordered.Value : false;
			po.TabsPosition = tabsPosition.IsNullOrEmpty () ? "top" : tabsPosition;
			po.NavType = navType.IsNullOrEmpty () ? "tabs" : navType;
			po.Stacked = stacked.HasValue ? stacked.Value : false;
			return  po;
		}

		public static TabPanel TabPanel(TabPanelOptions options, Action<TabPanel> action)
		{
			options = options ?? new TabPanelOptions ();

			var e = new Div (
				("tabbable{0}{1}").Fmt(
				options.Bordered ? " tabbable-bordered" : "",
				" tabs-" + options.TabsPosition)
				).As<TabPanel>();

			e.Links = new HtmlList (string.Format ("nav nav-{0}{1}", options.NavType, options.Stacked ? " nav-stacked" : ""));
			e.Content = new Div ("tab-content");
				

			var getTab = (Func<object,Tab>)(t => {
				var tp = Script.TypeOf (t);
				if (tp == "number")
					return jQuery.Select("a[data-toggle='tab']",e.Links ).GetElement(int.Parse(t.ToString())).As<Tab>();
				if (tp == "object")
					return UI.Cast<Tab> (t);
				return null;
			});


			if (options.TabsPosition != "below") {
				jQuery.FromElement(e).Append (e.Links).Append(e.Content);
			} else {
				jQuery.FromElement(e).Append (e.Content).Append(e.Links);

			}


			e.SetToAtomProperty("addDropdownTab", (Func<string,string,DropdownTab>)( (t,i)=>
				new DropdownTab(e,t,i)
			));


			e.SetToAtomProperty ("add", (Action<Tab>)((tab) => {
				e.Links.Append(tab.Item);
				e.Content.Append (tab.Body);

			}));


			e.SetToAtomProperty ("addTab", (Action<Action<Tab>>)((act) => {
				var tab = new Tab();
				act(tab);
				e.Links.Append(tab.Item);
				e.Content.Append (tab.Body);

			}));


			e.SetToAtomProperty ("getTab", (Func<int,Tab>)((index) => 
				 jQuery.Select("a[data-toggle='tab']", e.Links).GetElement(index).As<Tab>()				                        
			));

			e.SetToAtomProperty ("remove", (Action<object>)((t) => {
				Tab tab =  getTab(t);
				if(tab==null) return ;
				jQuery.FromElement(tab.Body).Remove();
				jQuery.FromElement(tab.Item).Remove();
			}));

			e.SetToAtomProperty ("show", (Action<object>)(t => {
				Tab tab = getTab (t);
				if (tab == null)
					return;
				jQuery.FromElement (tab).Execute ("tab", "show");
			}));

			e.SetToAtomProperty ("disable", (Action<object, bool?>)((t,v) => {
				Tab tab = getTab(t);
				if(tab==null) return ;
				tab.Disabled= v.HasValue?v.Value:true;

			}));

			UI.SetToProperty (e, "add_tabShow", (Action<jQueryEventHandler>)
			                      ((ev) => UI.On (e, "show", ev, "a[data-toggle='tab']")));

			UI.SetToProperty (e,"remove_tabShow", (Action<jQueryEventHandler>)
			                      ((ev) => UI.Off (e,"show", ev, "a[data-toggle='tab']")));


			UI.SetToProperty (e, "add_tabShown", (Action<jQueryEventHandler>)
			                      ((ev) => UI.On (e, "shown", ev, "a[data-toggle='tab']")));

			UI.SetToProperty (e,"remove_tabShown", (Action<jQueryEventHandler>)
			                      ((ev) => UI.Off (e,"shown", ev, "a[data-toggle='tab']")));


			UI.SetToProperty (e, "add_tabClicked", (Action<jQueryEventHandler>)
			                      ((ev) => UI.On (e, "click", ev, "a[data-toggle='tab']")));

			UI.SetToProperty (e,"remove_tabClicked", (Action<jQueryEventHandler>)
			                      ((ev) => UI.Off (e,"clik", ev, "a[data-toggle='tab']")));


			jQuery.FromElement (e).On ("click","a[data-toggle='tab']", ev => {
				ev.PreventDefault();
				if(ev.CurrentTarget.ClassList.Contains ("disabled") ) return ;
				ev.CurrentTarget.As<Tab>().ClickHandler(ev.CurrentTarget.As<Tab>() );
			});


			if(action!=null) action(e);

			return e;
		}

	}
}

