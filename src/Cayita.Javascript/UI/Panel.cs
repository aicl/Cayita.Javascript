using System;
using System.Html;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class Panel:ElementBase
	{
		PanelConfig pc;

		Element captionElement;

		public Panel()
		{
			var p = new PanelConfig ();
			Init (p);
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
				pc.Container.AddClass ("overlay");
			
			
			if (pc.OnCloseHandler == null)
				pc.OnCloseHandler = p => p.Close ();
			
			new Icon (pc.Header.Element(), icon => {
				icon.ClassName=pc.CloseIconClass;
				
				icon.OnClick(evt=>{
					evt.PreventDefault();
					pc.OnCloseHandler(self);
				});
				if(!pc.Closable) icon.Hide();
			});
			
			captionElement = Document.CreateElement("h3");
			captionElement.Text(pc.Caption);
			pc.Header.JQuery().Append(captionElement);
		}

		public void Caption(string text)
		{
			captionElement.Text (text);
		}

		public void Render(Element parent=null)
		{
			AppendTo (parent ?? Document.Body);
		}


		public void Close()
		{
			if (OnClose != null)
				OnClose (this);

			pc.Container.Remove ();
		}

		public void Collapse()
		{
		}

		public new DivElement Element()
		{
			return pc.Container.Element ();
		}

		/// <summary>
		/// Occurs before panel is closed.
		/// </summary>
		public event Action<Panel> OnClose;


		//public event Action<Panel> OnRender; ??
	}

	[Serializable]
	[ScriptNamespace("Cayita.UI")]
	public class PanelConfig
	{
		public PanelConfig()
		{
			CloseIconClass = "icon-remove-circle";

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

		public bool Movable{ get; set; }

		public bool Closable{ get; set; }

		public bool Collapsible{ get; set; }

		public string Left{ get; set; }

		public string Top{ get; set; }

		public Div Container { get; set; }

		public Div Header { get; set; }

		public string Caption { get; set; }

		public string CloseIconClass { get; set; }

		public Div Body { get; set; }
		/// <summary>
		/// Gets or sets the on close handler = > click on close Icon
		/// </summary>
		/// <value>The on click close-icon handler.</value>
		public Action<Panel> OnCloseHandler { get; set; }

		/// <summary>
		/// Gets or sets the on collapse handler = > click on collapse Icon
		/// </summary>
		/// <value>The on click collapse-icon handler.</value>
		public Action<Panel> OnCollapseHandler { get; set; }


	}

}
// Container -- Resizable Movable Closable  Collapsible,   OnClose, OnCollapse
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