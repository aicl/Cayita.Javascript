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
	
			options = options ?? new PanelOptions ();

			var e = new Div ("well well-panel").As<Panel>();
			e.CreateId ();

			var headerBand = new Div ("well-panel-header");
			var closeIcon = new CssIcon (options.CloseIconClass);
			closeIcon.CreateId ();
			var collapseIcon = new CssIcon (options.CollapseIconClass);
			collapseIcon.CreateId ();
			var header = Atom ("ctxt");

			var contentBand = new Div ("well-panel-content");
			e.Body = new Div("well-panel-body");
			contentBand.Append(e.Body);

			if (options.Hidden)
				jQuery.FromElement (e).Hide ();

			jQuery.FromElement (headerBand).Append (closeIcon).Append (collapseIcon).Append(header);
			jQuery.FromElement (e).Append (headerBand).Append (contentBand);

			DefineAtomProperty (e, "options", new {value=options, writable=false});
			DefineAtomProperty (e, "closeIcon", new {value=closeIcon, writable=false});
			DefineAtomProperty (e, "collapseIcon", new {value=collapseIcon, writable=false});
			DefineAtomProperty (e, "header", new {value=header, writable=false});

			SetToAtomProperty (e, "isClosable", (Func<bool>)( () => options.Closable ));
			SetToAtomProperty (e, "closable", (Action<bool?>)(v => {
				options.Closable = v.HasValue?v.Value:true;
				closeIcon.Hidden= !options.Closable;
			}));

			SetToAtomProperty (e, "isCollapsible", (Func<bool>)( () => options.Collapsible ));
			SetToAtomProperty (e, "collapsible", (Action<bool?>)(v => {
				options.Collapsible = v.HasValue?v.Value:true;
				collapseIcon.Hidden= !options.Collapsible;
			}));


			SetToAtomProperty (e, "get_top", (Func<string>)( () => options.Top ));
			SetToAtomProperty (e, "set_top", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				options.Top=v;
				e.Style.Top = v;
			}));

			SetToAtomProperty (e, "get_left", (Func<string>)( () => options.Left ));
			SetToAtomProperty (e, "set_left", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				options.Left=v;
				e.Style.Left = v;
			}));

			SetToAtomProperty (e, "get_height", (Func<string>)( () => options.Height ));
			SetToAtomProperty (e, "set_height", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				options.Height=v;
				contentBand.Style.Height = options.Height;
				e.Style.Height = "auto";
			}));

			SetToAtomProperty (e, "get_width", (Func<string>)( () => options.Width ));
			SetToAtomProperty (e, "set_width", (Action<string>)( (v) =>{
				if(v.IsNullOrEmpty()) return;
				options.Width=v;
				e.Style.Width = options.Width;
				contentBand.Style.Width = "auto";
			}));

			SetToAtomProperty (e, "get_caption", (Func<string>)( () => options.Caption ));
			SetToAtomProperty (e, "set_caption", (Action<string>)(v => {
				options.Caption=v;
				header.InnerHTML= v.IsNullOrEmpty()? "": v;
			}));


			SetToAtomProperty (e, "show", (Action<bool?>)(show => {
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


			if (options.CloseIconHandler == null)
				options.CloseIconHandler = p => p.Close ();

			if (options.CollapseIconHandler == null)
				options.CollapseIconHandler = (p,cl) => p.Collapse ();


			SetToProperty (e,"add_closeIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => On(e, PanelCloseIconEventName, ev, "#"+closeIcon.ID)));

			SetToProperty (e,"remove_closeIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => Off (e,PanelCloseIconEventName, ev, "#"+closeIcon.ID)));


			SetToProperty (e,"add_collapseIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => On(e, PanelCollapseIconEventName, ev, "#"+collapseIcon.ID)));

			SetToProperty (e,"remove_collapseIconClicked", (Action<jQueryEventHandler>)
			                      ((ev) => Off (e,PanelCollapseIconEventName, ev, "#"+collapseIcon.ID)));

			SetToProperty(e,"collapse", (Action)(()=>{
				var collapsed = contentBand.Hidden;
				contentBand.Hidden=!collapsed;
				if (collapsed){
					collapseIcon.RemoveClass(options.ExpandIconClass);
					collapseIcon.AddClass(options.CollapseIconClass);
				} else {
					collapseIcon.RemoveClass(options.CollapseIconClass);
					collapseIcon.AddClass(options.ExpandIconClass);
					e.Style.Height="auto";
				}
			}));

			SetToProperty(e, "resizable", (Action<bool?>)(v=>{
			options.Resizable=v.HasValue?v.Value:true;
				if(options.Resizable){
					if(robject==null){
						robject = jQuery.FromElement(contentBand).Resizable ();
						robject.AlsoResize = e;
					}
				} else {
					if(robject!=null){
						robject.Destroy();
						robject=null;
					}
				}
			}));
			SetToProperty(e, "isResizable", (Func<bool>)( ()=> options.Resizable ) );

			SetToProperty(e, "setDraggable", (Action<bool?>)( v=>{
				options.Draggable=v.HasValue?v.Value:true;
				if(options.Draggable){
					if(dobject==null){
						dobject = jQuery.FromElement(e).Draggable ();
						dobject.Stack = "#"+e.ID;
						dobject.AddClasses = false;
						dobject.Containment = "parent";
						dobject.Distance = 10;
						dobject.Handle = headerBand;
					}

				} else {
					if(dobject!=null){
						dobject.Destroy();
						dobject=null;
					}
				}

			}));
			SetToProperty(e, "isDraggable", (Func<bool>)( ()=> options.Draggable ) );

			jQuery.FromElement (e).On ("click", "#"+closeIcon.ID, ev => {
				var j= jQuery.FromElement(ev.CurrentTarget);
				if(j.HasClass("disabled") ) return ;
				j.Trigger(PanelCloseIconEventName);

			})
				.On("dragstop", ev=>z=e.Style.ZIndex)
					.On("click", ev=>{
						e.Style.ZIndex=z++;
					})
					.On ("click", "#"+collapseIcon.ID, ev => {
						var j= jQuery.FromElement(ev.CurrentTarget);
						if(j.HasClass("disabled") ) return ;
						j.Trigger(PanelCollapseIconEventName);

					});

			e.CloseIconClicked+= (ev) => {
				options.CloseIconHandler(e);
			};

			e.CollapseIconClicked+= (ev) => {
				options.CollapseIconHandler(e, contentBand.Hidden);
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

