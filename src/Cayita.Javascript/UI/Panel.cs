using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi.UI.Interactions;
using jQueryApi;

namespace Cayita.UI
{
	public class Panel:ElementBase<Panel>
	{
		PanelConfig pc;

		Element captionElement;
		Icon closeIcon;
		Icon collapseIcon;
		DraggableObject  dobject;
		ResizableObject robject;

		protected Div Header { get; set; }
		public Div Body { get; protected set;}

		public Panel()
		{
			Init (new PanelConfig ());
		}

		public Panel ( Action<PanelConfig> config )
		{
			var p = new PanelConfig ();
			config.Invoke (p); 
			Init (p);
		}

		public Panel ( PanelConfig config )
		{
			Init (config);
		}

		void Init( PanelConfig config)
		{
			CreateElement ("div", null);
			var el = Element ();
			el.ClassName="c-panel";
			Header = new Div (el).ClassName ("c-panel-header");
			Body = new Div (el).ClassName ("c-panel-content");

			var self = this;
			pc = config;
						
			if (pc.CloseIconHandler == null)
				pc.CloseIconHandler = p => p.Close ();

			if(pc.CollapseIconHandler==null)
				pc.CollapseIconHandler= (p,collapsed)=> p.Collapse();


			var hd = Header.Element ();
			closeIcon =new Icon (hd, icon => {

				icon.ClassName=pc.CloseIconClass;
				
				icon.OnClick(evt=>{
					evt.PreventDefault();
					pc.CloseIconHandler(self);
				});
				if(!pc.Closable) icon.Hide();

			});

			collapseIcon = new Icon (hd, icon => {

				icon.ClassName = pc.CollapseIconClass;
				icon.OnClick (evt => {
					evt.PreventDefault ();
					pc.CollapseIconHandler (self, !Body.IsVisible());
				});
				if (!pc.Collapsible)
					icon.Hide ();

			});

			captionElement = pc.Caption.Header (6);
			
			hd.Append (captionElement);

			JQuery ().CSS ("left", pc.Left)
				.CSS ("top", pc.Top);
			Body.JQuery().CSS ("width", pc.Width)
					.CSS ("height", pc.Height);

			JQuery().CSS("z-index", "0");

			InitDraggable ();

			if (!pc.Draggable)
				dobject.Destroy ();

			InitResizable ();

			if (!pc.Resizable)
				robject.Destroy ();

			JQuery ().Click (evt => {
				var zI= JQuery().GetCSS("z-index");
				var hZ =int.Parse(zI);
				Element hE= Element();
				jQuery.Select(".c-panel").Each( (index, element)=>{
					var cZ= int.Parse( jQuery.FromElement(element).GetCSS("z-index") );
					if(cZ>hZ){
						hE= element;
						hZ=cZ;
					}
				});
				jQuery.FromElement(hE).CSS("z-index", zI);
				JQuery().CSS("z-index", hZ>0 ? hZ.ToString():"1");
			});

			if (pc.Overlay)
				JQuery ().CSS ("position", "fixed");

		}

		public Panel Caption(string text)
		{
			pc.Caption = text;
			captionElement.Text (text);
			return this;
		}

		public Panel Render(Element parent=null)
		{
			AppendTo (parent);
			return this;
		}

		public Panel Overlay(bool value)
		{
			pc.Overlay = value;
			if (value)
				JQuery ().CSS ("position", "fixed");
			else
				JQuery ().CSS ("position", "relative");
			return this;

		}


		public Panel Closable(bool value)
		{
			pc.Closable = value;
			if (value)
				closeIcon.JQuery ().Show ();
			else
				closeIcon.JQuery ().Hide ();
			return this;
		}

		public Panel Collapsible(bool value)
		{
			pc.Collapsible = value;
			if (value)
				collapseIcon.JQuery ().Show ();
			else
				collapseIcon.JQuery ().Hide ();
			return this;
		}


		public Panel Draggable(bool value)
		{
			pc.Draggable = value;
			if (value) {
				InitDraggable ();
			} else
				dobject.Destroy ();
			return this;
		}

		public Panel Resizable(bool value)
		{
			pc.Resizable = value;
			if (value) {
				InitResizable();
			} else
				robject.Destroy ();
			return this;
		}




		/// <summary>
		/// Called whent Close method is invoked
		/// </summary>
		/// <param name="value">Value.</param>
		public Panel ClosedHandler(Action<Panel> value)
		{
			Closed += value;
			return this;
		}
		/// <summary>
		/// Called when Collapse method is invoked
		/// </summary>
		/// <param name="value">Value (Panel,bool) </param>
		public Panel CollapsedHandler(Action<Panel,bool> value)
		{
			Collapsed += value;
			return this;
		}

		public Panel CloseIconHandler(Action<Panel> value )
		{
			pc.CloseIconHandler = value;
			return this;
		}

		public Panel CollapseIconHandler(Action<Panel,bool> value )
		{
			pc.CollapseIconHandler = value;
			return this;
		}

		public Panel CloseIconClass(string value)
		{
			pc.CloseIconClass = value;
			closeIcon.ClassName (value);
			return this;
		}

		public Panel CollapseIconClass(string value)
		{
			pc.CollapseIconClass = value;
			if(Body.IsVisible()) collapseIcon.ClassName (value);
			return this;
		}

		public Panel ExpandIconClass(string value)
		{
			pc.ExpandIconClass = value;
			if(Body.IsVisible()) collapseIcon.ClassName (value);
			return this;
		}


		public Panel Left(string value)
		{
			pc.Top = value;
			JQuery ().CSS ("left", value);
			return this;
		}

		public Panel Top(string value)
		{
			pc.Top = value;
			JQuery ().CSS ("top", value);
			return this;
		}

		public Panel Width(string value)
		{
			pc.Width = value;
			JQuery ().CSS ("width", value);
			return this;
		}

		public Panel Height(string value)
		{
			pc.Height = value;
			Body.JQuery ().CSS ("height", value);
			return this;
		}


		public Panel Collapse()
		{
			var collapsed = !Body.IsVisible ();

			OnCollapsed (collapsed);

			Body.JQuery ().Toggle ();

			collapseIcon.ClassName (!collapsed ? pc.CollapseIconClass : pc.ExpandIconClass);
			return this;
		}



		/// <summary>
		/// Toggle panel (show/hide)
		/// </summary>
		public Panel Toggle()
		{
			var visible = IsVisible ();

			OnToggled (visible);
			
			JQuery ().Toggle ();
			return this;
		}


		public void Close()
		{
			OnClosed ();
			Remove ();
		}

		public new Panel Append (string content)
		{
			Body.Append (content);
			return this;
		}

		public new Panel Append (Element content)
		{
			Body.Append (content);
			return this;
		}

		public Panel Append<T> (ElementBase<T> content) where T: ElementBase
		
		{
			Body.Append (content.Element());
			return this;
		}


		public new DivElement Element()
		{
			return base.Element ().As<DivElement> ();
		}

		/// <summary>
		/// Occurs when Close method is invoked
		/// </summary>
		public event Action<Panel> Closed = (p) => {};

		protected virtual void OnClosed ()
		{
			Closed (this);
		}

		/// <summary>
		/// Occurs when Collapse method is invoked (Panel, Collapsed).
		/// </summary>
		public event Action<Panel,bool> Collapsed = (p,s) => {};

		protected virtual void OnCollapsed ( bool collapsed)
		{
			Collapsed (this,collapsed);
		}

		/// <summary>
		/// Occurs when Toggle method is invoked => (Panel, Visible)
		/// </summary>
		public event Action<Panel,bool> Toggled = (p,s) => {};

		protected virtual void OnToggled (bool toggled)
		{
			Toggled (this, toggled);
		}

		void InitDraggable()
		{
			dobject = JQuery ().Draggable ();
			dobject.Stack = ".c-panel";
			dobject.AddClasses = false;
			dobject.Containment = "parent";
			dobject.Distance = 10;
			dobject.Handle = Header.Element();
		}


		void InitResizable()
		{
			robject = Body.JQuery ().Resizable ();
			robject.AlsoResize = JQuery ();

		}

	}

	[Serializable]
	[ScriptNamespace("Cayita.UI")]
	public class PanelConfig
	{
		public PanelConfig()
		{
			CloseIconClass = "icon-remove-circle";
			CollapseIconClass = "icon-circle-arrow-up";
			ExpandIconClass = "icon-circle-arrow-down";
			Caption = "";

			Overlay = false;
			Resizable = true;
			Draggable = true;
			Closable = true;
			Collapsible = true;

			Left = "";
			Top = "";
			Width = "";
			Height = "";

		}


		public bool Overlay { get; set; }

		public bool Resizable{ get; set; }

		public bool Draggable{ get; set; }

		public bool Closable{ get; set; }

		public bool Collapsible{ get; set; }

		public string Left{ get; set; }

		public string Top{ get; set; }

		public string Width{ get; set; }

		public string Height{ get; set; }

		public string Caption { get; set; }

		public string CloseIconClass { get; set; }

		public string CollapseIconClass { get; set; }

		public string ExpandIconClass { get; set; }

		/// <summary>
		/// Gets or sets the on close handler = > click on close Icon
		/// </summary>
		/// <value>The on click close-icon handler.</value>
		public Action<Panel> CloseIconHandler { get; set; }

		/// <summary>
		/// Gets or sets the on collapse handler = > click on collapse Icon
		/// </summary>
		/// <value>The on click collapse-icon handler.</value>
		public Action<Panel,bool> CollapseIconHandler { get; set; }


	}

}
// Container -- Resizable Draggable Closable  Collapsible,   OnClose, OnCollapse
// Header -- Close, Collapse, Caption, CloseIconClass , CollapseIconClass, ExpandIconClass
// Body

/*

new Div(div, i=>{
	i.ClassName="c-panel";
	new Div(i, h=>{
		h.ClassName="c-panel-header";
		new Icon(h, icon=>{ 
			icon.ClassName="icon-remove-circle";
			icon.OnClick(evt=>{
				evt.PreventDefault();
				ContenedorWorkArea.Hide();
				ContenedorItemArea.Show();
			}); 

		});
		TituloModulo = Document.CreateElement("h3");
		TituloModulo.Text("Titulo del modulo");
		h.AppendChild(TituloModulo);
	});
	WorkArea= new Div(i, ct=>{
		ct.ClassName="c-panel-content";
	});
});

*/