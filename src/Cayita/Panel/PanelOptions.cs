using System;
using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class PanelOptions
	{
		[InlineCode("Cayita.UI.PanelOptions()")]
		public PanelOptions()
		{
		}

		[IntrinsicProperty]
		public bool Hidden{ get; set; }

		[IntrinsicProperty]
		public bool Overlay { get; set; }

		[IntrinsicProperty]
		public bool Resizable{ get; set; }

		[IntrinsicProperty]
		public bool Draggable{ get; set; }

		[IntrinsicProperty]
		public bool Closable{ get; set; }

		[IntrinsicProperty]
		public bool Collapsible{ get; set; }

		[IntrinsicProperty]
		public string Left{ get; set; }

		[IntrinsicProperty]
		public string Top{ get; set; }

		[IntrinsicProperty]
		public string Width{ get; set; }

		[IntrinsicProperty]
		public string Height{ get; set; }

		[IntrinsicProperty]
		public string Caption { get; set; }

		[IntrinsicProperty]
		public string CloseIconClass { get; set; }

		[IntrinsicProperty]
		public string CollapseIconClass { get; set; }

		[IntrinsicProperty]
		public string ExpandIconClass { get; set; }

		/// <summary>
		/// Gets or sets the on close handler = > click on close Icon
		/// </summary>
		/// <value>The on click close-icon handler.</value>
		[IntrinsicProperty]
		public Action<Panel> CloseIconHandler { get; set; }

		/// <summary>
		/// Gets or sets the on collapse handler = > click on collapse Icon
		/// </summary>
		/// <value>The on click collapse-icon handler.</value>
		[IntrinsicProperty]
		public Action<Panel,bool> CollapseIconHandler { get; set; }


	}
}

