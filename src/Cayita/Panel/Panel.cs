using System;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Panel:Div
	{
		[InlineCode("Cayita.UI.Panel()")]
		public Panel()
		{
		}

		[InlineCode("Cayita.UI.Panel({options})")]
		public Panel(PanelOptions options)
		{
		}

		public string Caption {
			get;
			set;
		}

		public string Height {
			get;
			set;
		}

		public string Width {
			get;
			set;
		}

		public string Top {
			get;
			set;
		}

		public string Left {
			get;
			set;
		}


		public bool Closable {
			[InlineCode("{this}.isClosable()")]
			get;
			[InlineCode("{this}.closable({value})")]
			set;
		}


		public bool Collapsible { 
			[InlineCode("{this}.isCollapsible()")]
			get;
			[InlineCode("{this}.collapsible({value})")]
			set;
		}

		[IntrinsicProperty]
		public Atom Header {
			get; 
			internal set; 
		}

		[IntrinsicProperty]
		public CssIcon CloseIcon { get;  internal set; }

		[IntrinsicProperty]
		public CssIcon CollapseIcon { get; internal  set; }


		/// <summary>
		/// Gets or sets the on close handler = > click on close Icon
		/// </summary>
		/// <value>The on click close-icon handler.</value>

		public Action<Panel> CloseIconHandler { 
			[InlineCode("{this}.options.closeIconHandler")]
			get; 
			[InlineCode("{this}.options.closeIconHandler={value}")]
			set; 
		}

		/// <summary>
		/// Gets or sets the on collapse handler = > click on collapse Icon
		/// </summary>
		/// <value>The on click collapse-icon handler.</value>
		public Action<Panel,bool> CollapseIconHandler { 
			[InlineCode("{this}.options.collapseIconHandler")]
			get; 
			[InlineCode("{this}.options.collapseIconHandler={value}")]
			set; 
		}

		public bool Resizable{ 
			[InlineCode("{this}.isResizable()")]get; 
			[InlineCode("{this}.resizable({value})")]set; 
		}

		public bool Draggable{ 
			[InlineCode("{this}.isDraggable()")]get; 
			[InlineCode("{this}.setDraggable({value})")]set; 
		}


		public void Show(bool value=true){
		}


		public void Collapse(){
		}

		public void Close(){
		}

		public Panel Add(Element content){
			return null;
		}

		public Panel Add(string content){
			return null;
		}


		public event jQueryEventHandler CloseIconClicked {
			[InlineCode("{this}.add_closeIconClicked({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_closeIconClicked({value})")]
			remove
			{
			}
		}

		public event jQueryEventHandler CollapseIconClicked {
			[InlineCode("{this}.add_collapseIconClicked({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_collapseIconClicked({value})")]
			remove
			{
			}
		}

		[IntrinsicProperty]
		public Div Body { get; internal set; }


	}
}

