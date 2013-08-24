using System;
using jQueryApi;
using System.Html;
using jQueryApi.UI.Interactions;

namespace Cayita
{

	public static partial class UI
	{
		public static string DefaultCloseIconClass = "icon-remove-circle";
		public static string DefaultCollapseIconClass = "icon-circle-arrow-up";
		public static string DefaultExpandIconClass = "icon-circle-arrow-down";
		public static string PanelCloseIconEventName = "close-icon.click";
		public static string PanelCollapseIconEventName = "collapse-icon.click";
		static short z=0;

		public static PanelOptions PanelOptions()
		{
			return Cast<PanelOptions> (new {
				closeIconClass= DefaultCloseIconClass,
				collapseIconClass= DefaultCollapseIconClass,
				expandIconClass= DefaultExpandIconClass,
				resizable= true,
				draggable= true,
				closable= true,
				collapsible= true
			});

		}
		//---------------------------------------------------------------------------------------------


		public static  Panel Panel(PanelOptions options=null)
		{

			DraggableObject  dobject=null;
			ResizableObject robject=null;
	

			var e = new Div ("well well-panel").As<Panel>();
			e.CreateId ();
			e._options = options ?? new PanelOptions ();

			e._headerband = new Div ("well-panel-header");
			e.CloseIcon= new CssIcon (e._options.CloseIconClass);
			e.CloseIcon.CreateId ();
			e.CollapseIcon = new CssIcon (e._options.CollapseIconClass);
			e.CollapseIcon.CreateId ();
			e.Header= Atom ("ctxt");

			e._contentband= new Div ("well-panel-content");
			e.Body = new Div("well-panel-body");
			e._contentband.Append(e.Body);

			if (e._options.Hidden)
				jQuery.FromElement (e).Hide ();

			jQuery.FromElement (e._headerband).Append (e.CloseIcon).Append (e.CollapseIcon).Append(e.Header);
			jQuery.FromElement (e).Append (e._headerband).Append (e._contentband);


			SetToAtomProperty (e, "is_closable", (Func<bool>)( () => e._options.Closable ));
			SetToAtomProperty (e, "closable", (Action<bool?>)(v => {
				e._options.Closable = v.HasValue?v.Value:true;
				e.CloseIcon.Hidden= !e._options.Closable;
			}));

			SetToAtomProperty (e, "is_collapsible", (Func<bool>)( () =>e._options.Collapsible ));
			SetToAtomProperty (e, "collapsible", (Action<bool?>)(v => {
				e._options.Collapsible = v.HasValue?v.Value:true;
				e.CollapseIcon.Hidden= !e._options.Collapsible;
			}));


			SetToAtomProperty (e, "get_top", (Func<string>)( () => e._options.Top ));
			SetToAtomProperty (e, "set_top", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				e._options.Top=v;
				e.Style.Top = v;
			}));

			SetToAtomProperty (e, "get_left", (Func<string>)( () => e._options.Left ));
			SetToAtomProperty (e, "set_left", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				e._options.Left=v;
				e.Style.Left = v;
			}));

			SetToAtomProperty (e, "get_height", (Func<string>)( () => e._options.Height ));
			SetToAtomProperty (e, "set_height", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				e._options.Height=v;
				e._contentband.Style.Height = v;
				e.Style.Height = "auto";
			}));

			SetToAtomProperty (e, "get_width", (Func<string>)( () => e._options.Width ));
			SetToAtomProperty (e, "set_width", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				e._options.Width=v;
				e.Style.Width = v;
				e._contentband.Style.Width = "auto";
			}));

			SetToAtomProperty (e, "get_caption", (Func<string>)( () => e._options.Caption ));
			SetToAtomProperty (e, "set_caption", (Action<string>)(v => {
				e._options.Caption=v;
				e.Header.InnerHTML= v.IsNullOrEmpty()? "": v;
			}));


			SetToAtomProperty (e, "do_show", (Action<bool?>)(show => {
				if(e.ParentNode==null) jQuery.FromElement(Document.Body).Append(e);
				if(!show.HasValue ||  show.Value)
					jQuery.FromElement(e).Show();
				else
					jQuery.FromElement(e).Hide();

			}));

			SetToAtomProperty(e, "close", (Action)( ()=> jQuery.FromElement(e).Remove()));

			SetToAtomProperty (e, "add", (Func<Element,Panel>)((c) =>{
				jQuery.FromElement (e.Body).Append (c);
				return e;
			}));


			if (e._options.CloseIconHandler == null)
				e._options.CloseIconHandler = p => p.Close ();

			if (e._options.CollapseIconHandler == null)
				e._options.CollapseIconHandler = (p,cl) => p.Collapse ();


			SetToProperty (e,"add_closeIconClicked", (Action<jQueryEventHandler>)

			               ((ev) => {
				On(e, PanelCloseIconEventName, ev, "#"+e.CloseIcon.ID);}));

			SetToProperty (e,"remove_closeIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => Off (e,PanelCloseIconEventName, ev, "#"+e.CloseIcon.ID)));


			SetToProperty (e,"add_collapseIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => On(e, PanelCollapseIconEventName, ev, "#"+e.CollapseIcon.ID)));

			SetToProperty (e,"remove_collapseIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => Off (e,PanelCollapseIconEventName, ev, "#"+e.CollapseIcon.ID)));

			SetToProperty(e,"collapse", (Action)(()=>{
				var collapsed = e._contentband.Hidden;
				e._contentband.Hidden=!collapsed;
				if (collapsed){
					e.CollapseIcon.RemoveClass(options.ExpandIconClass);
					e.CollapseIcon.AddClass(options.CollapseIconClass);
				} else {
					e.CollapseIcon.RemoveClass(options.CollapseIconClass);
					e.CollapseIcon.AddClass(options.ExpandIconClass);
					e.Style.Height="auto";
				}
			}));

			SetToProperty(e, "resizable", (Action<bool?>)(v=>{
			options.Resizable=v.HasValue?v.Value:true;
				if(e._options.Resizable){
					if(robject==null){
						robject = jQuery.FromElement(e._contentband).Resizable ();
						robject.AlsoResize = e;
					}
				} else {
					if(robject!=null){
						robject.Destroy();
						robject=null;
					}
				}
			}));
			SetToProperty(e, "is_resizable", (Func<bool>)( ()=> options.Resizable ) );

			SetToProperty(e, "do_draggable", (Action<bool?>)( v=>{
				e._options.Draggable=v.HasValue?v.Value:true;
				if(options.Draggable){
					if(dobject==null){
						dobject = jQuery.FromElement(e).Draggable ();
						dobject.Stack = "#"+e.ID;
						dobject.AddClasses = false;
						dobject.Containment = "parent";
						dobject.Distance = 10;
						dobject.Handle = e._headerband;
					}

				} else {
					if(dobject!=null){
						dobject.Destroy();
						dobject=null;
					}
				}

			}));
			SetToProperty(e, "is_draggable", (Func<bool>)( ()=> options.Draggable ) );


			e.SetToAtomProperty("get_closeIconHandler", (Func<Action<Panel>>)(()=> e._options.CloseIconHandler ));
			e.SetToAtomProperty("set_closeIconHandler", (Action<Action<Panel>>)((v)=> e._options.CloseIconHandler=v ));

			e.SetToAtomProperty("get_collapseIconHandler", (Func<Action<Panel,bool>>)(()=> e._options.CollapseIconHandler ));
			e.SetToAtomProperty("set_CollapseIconHandler", (Action<Action<Panel,bool>>)((v)=> e._options.CollapseIconHandler=v ));

			jQuery.FromElement (e).On ("click", "#"+e.CloseIcon.ID, ev => {
				var j= jQuery.FromElement(ev.CurrentTarget);
				if(j.HasClass("disabled") ) return ;
				j.Trigger(PanelCloseIconEventName);

			})
				.On("dragstop", ev=>z=e.Style.ZIndex)
					.On("click", ev=>{
						e.Style.ZIndex=z++;
					})
					.On ("click", "#"+e.CollapseIcon.ID, ev => {
						var j= jQuery.FromElement(ev.CurrentTarget);
						if(j.HasClass("disabled") ) return ;
						j.Trigger(PanelCollapseIconEventName);

					});

			e.CloseIconClicked+= (ev) => {
				e._options.CloseIconHandler(e);
			};

			e.CollapseIconClicked+= (ev) => {
				e._options.CollapseIconHandler(e, e._contentband.Hidden);
			};

			e.Resizable = options.Resizable;
			e.Draggable = options.Draggable;
			e.Closable=options.Closable;
			e.Collapsible = options.Collapsible;
			e.Caption = options.Caption;

			if (options.Overlay) {
				e.Style.Position = "fixed";
			}

			e.Height = options.Height;
			e.Width = options.Width;

			e.Left = options.Left;
			e.Top = options.Top;


			return e;
		}
	}
}

