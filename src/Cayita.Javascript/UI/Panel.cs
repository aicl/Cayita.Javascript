using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi.UI.Interactions;
using jQueryApi;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class Panel:ElementBase
	{
		PanelConfig pc;

		Element captionElement;
		Icon closeIcon;
		Icon collapseIcon;
		DraggableObject  dobject;

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
			var self = this;
			
			pc = config;

			SetElement (pc.Container.Element ());
			
			if (pc.Overlay)
				pc.Container.AddClass ("c-overlay");
			
			
			if (pc.OnClickCloseIconHandler == null)
				pc.OnClickCloseIconHandler = p => p.Close ();

			if(pc.OnClickCollapseIconHandler==null)
				pc.OnClickCollapseIconHandler= (p,collapsed)=> p.Collapse();
			
			closeIcon =new Icon (pc.Header.Element(), icon => {

				icon.ClassName=pc.CloseIconClass;
				
				icon.OnClick(evt=>{
					evt.PreventDefault();
					pc.OnClickCloseIconHandler(self);
				});
				if(!pc.Closable) icon.Hide();

			});

			collapseIcon = new Icon (pc.Header.Element (), icon => {

				icon.ClassName = pc.CollapseIconClass;
				icon.OnClick (evt => {
					evt.PreventDefault ();
					pc.OnClickCollapseIconHandler (self, !pc.Body.IsVisible());
				});
				if (!pc.Collapsible)
					icon.Hide ();

			});

			captionElement = Document.CreateElement("h3");
			captionElement.Text(pc.Caption);
			pc.Header.JQuery().Append(captionElement);

			pc.Container.JQuery ().CSS ("left", pc.Left)
				.CSS ("top", pc.Top)
					.CSS ("width", pc.Width)
					.CSS ("height", pc.Height);

			dobject = pc.Container.Draggable ();
			dobject.Stack = ".c-panel";

			if (!pc.Draggable)
				dobject.Disable ();

			pc.Container.JQuery ().Click (evt => {
				var zI= pc.Container.JQuery().GetCSS("z-index");
				//pc.Container.JQuery().CSS("z-index", zI);
				var hZ= int.Parse(zI);
				Element hE= pc.Container.Element();
				jQuery.Select(".c-panel").Each( (index, element)=>{
					var cZ= int.Parse( jQuery.FromElement(element).GetCSS("z-index") );
					if(cZ>hZ){
						hE= element;
						hZ=cZ;
					}
				});
				jQuery.FromElement(hE).CSS("z-index", zI);
				pc.Container.JQuery().CSS("z-index", hZ.ToString());

			});

		}

		public Panel Caption(string text)
		{
			captionElement.Text (text);
			return this;
		}

		public Panel Render(Element parent=null)
		{
			AppendTo (parent);
			return this;
		}

		public Panel Overylay(bool value)
		{
			if (value)
				AddClass ("c-overlay");
			else
				RemoveClass ("c-overlay");
			return this;

		}

		public Panel Closable(bool value)
		{
			if (value)
				closeIcon.JQuery ().Show ();
			else
				closeIcon.JQuery ().Hide ();
			return this;
		}


		public Panel OnCloseHandler(Action<Panel> value)
		{
			OnClose += value;
			return this;
		}

		public Panel OnCollapseHandler(Action<Panel,bool> value)
		{
			OnCollapse += value;
			return this;
		}

		public Panel CloseIconHandler(Action<Panel> value )
		{
			pc.OnClickCloseIconHandler = value;
			return this;
		}

		public Panel CollapseIconHandler(Action<Panel,bool> value )
		{
			pc.OnClickCollapseIconHandler = value;
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
			if(pc.Body.IsVisible()) collapseIcon.ClassName (value);
			return this;
		}

		public Panel ExpandIconClass(string value)
		{
			pc.ExpandIconClass = value;
			if(!pc.Body.IsVisible()) collapseIcon.ClassName (value);
			return this;
		}


		public Panel Left(string value)
		{
			pc.Container.JQuery ().CSS ("left", value);
			return this;
		}

		public Panel Top(string value)
		{
			pc.Container.JQuery ().CSS ("top", value);
			return this;
		}

		public Panel Width(string value)
		{
			pc.Container.JQuery ().CSS ("width", value);
			return this;
		}

		public Panel Height(string value)
		{
			pc.Container.JQuery ().CSS ("height", value);
			return this;
		}


		public Panel Collapse()
		{
			var collapsed = !pc.Body.IsVisible ();

			if (OnCollapse != null)
				OnCollapse (this, collapsed );

			pc.Body.JQuery ().Toggle ();
			collapseIcon.ClassName (!collapsed ? pc.CollapseIconClass : pc.ExpandIconClass);
			return this;
		}


		public Panel Toggle()
		{
			var visible = pc.Container.IsVisible ();
			
			if (OnToggle != null)
				OnToggle (this, visible );
			
			pc.Container.JQuery ().Toggle ();
			return this;
		}


		public void Close()
		{
			if (OnClose != null)
				OnClose (this);

			pc.Container.Remove ();
		}


		public new DivElement Element()
		{
			return pc.Container.Element ();
		}

		/// <summary>
		/// Occurs when on close  panel.
		/// </summary>
		public event Action<Panel> OnClose;


		/// <summary>
		/// Occurs when on collapse=> (Panel, Collpased).
		/// </summary>
		public event Action<Panel,bool> OnCollapse;

		/// <summary>
		/// Occurs when on toggle => (Panel, Visible)
		/// </summary>
		public event Action<Panel,bool> OnToggle;
		
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

			Container = new Div (null, ct => {
				ct.ClassName="c-panel";
				Header = new Div(ct, hd=>{
					hd.ClassName="c-panel-header";
				});
				Body = new Div(ct, bd=>{
					bd.ClassName="c-panel-content";
				});

			});
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

		public Div Container { get; set; }

		public Div Header { get; set; }

		public string Caption { get; set; }

		public string CloseIconClass { get; set; }

		public string CollapseIconClass { get; set; }

		public string ExpandIconClass { get; set; }

		public Div Body { get; set; }
		/// <summary>
		/// Gets or sets the on close handler = > click on close Icon
		/// </summary>
		/// <value>The on click close-icon handler.</value>
		public Action<Panel> OnClickCloseIconHandler { get; set; }

		/// <summary>
		/// Gets or sets the on collapse handler = > click on collapse Icon
		/// </summary>
		/// <value>The on click collapse-icon handler.</value>
		public Action<Panel,bool> OnClickCollapseIconHandler { get; set; }


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