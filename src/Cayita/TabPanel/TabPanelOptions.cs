using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TabPanelOptions
	{
		[InlineCode("Cayita.UI.TabPanelOptions()")]
		public TabPanelOptions()
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Cayita.UI.TabPanelConfig"/> is bordered.
		/// </summary>
		/// <value><c>true</c> if bordered; otherwise, <c>false</c>.</value>
		[IntrinsicProperty]
		public bool Bordered { get; set; }

		/// <summary>
		/// Gets or sets the tabs position.
		/// </summary>
		/// <value>The tabs position: top, right, below, left</value>
		[IntrinsicProperty]
		public string TabsPosition { get; set; }

		/// <summary>
		/// Gets or sets the type of the nav.
		/// </summary>
		/// <value>The type of the nav:tabs || pills.</value>
		[IntrinsicProperty]
		public string NavType { get; set; }

		[IntrinsicProperty]
		public bool Stacked { get; set; }


	}
}

