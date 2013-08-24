using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita
{
	[IgnoreNamespace, Imported]
	public class PopoverOptions
	{
		[InlineCode("Cayita.Plugins.PopoverOptions()")]
		public PopoverOptions()
		{
		}

		/// <summary>
		/// apply a css fade transition to the tooltip
		/// </summary>
		/// <value><c>true</c> if animation; otherwise, <c>false</c>. Default: true</value>

		[IntrinsicProperty]
		public bool Animation  {get;set;}

		/// <summary>
		/// Insert html into the popover. 
		/// If false, jquery's text method will be used to insert content into the dom. 
		/// Use text if you're worried about XSS attacks.
		/// </summary>
		/// <value><c>true</c> if html; otherwise, <c>false</c>. Default: false</value>
		[IntrinsicProperty]
		public bool Html { get; set; }
		/// <summary>
		/// Gets or sets the placement.
		/// </summary>
		/// <value>how to position the popover - top | bottom | left | right. Default : right</value>
		[IntrinsicProperty]
		public string Placement { get; set; }
		/// <summary>
		/// Gets or sets how popover is triggered 
		/// </summary>
		/// <value>click | hover | focus | manual. Default click</value>
		[IntrinsicProperty]
		public string Trigger { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>Title value</value>
		[IntrinsicProperty]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		/// <value>content value</value>
		[IntrinsicProperty]
		public string Content { set{} }

		/// <summary>
		/// Gets or sets the content func.
		/// </summary>
		/// <value>func that returns the content value</value>
		public Func<string> ContentFunc {
			[InlineCode("{this}.content={value}")]
			set {}
		}


		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		/// <value>The Element to be used as content</value>
		public Element ContentElement {
			[InlineCode("{this}.content={value}")]
			set{}
		}

	}
}

