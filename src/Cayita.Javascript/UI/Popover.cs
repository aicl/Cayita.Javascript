using System;
using System.Html;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.UI
{

	public class Popover
	{
		dynamic p;


		public Popover (Element parent, PopoverOptions options)
		{
			Init (parent, options);
		}

		public Popover (ElementBase parent, PopoverOptions options)
		{
			Init (parent.GetMainElement(), options);
		}

		public Popover (ElementBase parent, Action<PopoverOptions> options)
			:this(parent.GetMainElement(),options)
		{}

		public Popover (Element parent, Action<PopoverOptions> options)
		{
			var opt = new PopoverOptions ();
			options.Invoke (opt);
			Init (parent, opt);
		}


		public void Show()
		{
			p["popover"] ("show");
		}

		public void Hide()
		{
			p["popover"] ("hide");
		}

		public void Toggle()
		{
			p["popover"] ("toggle");
		}

		public void Destroy()
		{
			p["popover"] ("destroy");
		}


		void Init (Element parent, PopoverOptions options)
		{
			p = (dynamic) parent.JQuery();
			p["popover"] (options);
		}
	}

	[Serializable]
	public class PopoverOptions
	{
		public PopoverOptions()
		{
			Animation = true;
			Placement = "right";
			Trigger = "click";
			Title = "";
			Content = "";
		}

		/// <summary>
		/// apply a css fade transition to the tooltip
		/// </summary>
		/// <value><c>true</c> if animation; otherwise, <c>false</c>. Default: true</value>
		public bool Animation  {get;set;}

		/// <summary>
		/// Insert html into the popover. 
		/// If false, jquery's text method will be used to insert content into the dom. 
		/// Use text if you're worried about XSS attacks.
		/// </summary>
		/// <value><c>true</c> if html; otherwise, <c>false</c>. Default: false</value>
		public bool Html { get; set; }
		/// <summary>
		/// Gets or sets the placement.
		/// </summary>
		/// <value>how to position the popover - top | bottom | left | right. Default : right</value>
		public string Placement { get; set; }
		/// <summary>
		/// Gets or sets how popover is triggered 
		/// </summary>
		/// <value>click | hover | focus | manual. Default click</value>
		public string Trigger { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>Title value</value>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		/// <value>content value</value>
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the content func.
		/// </summary>
		/// <value>func that returns the content value</value>
		public Func<string> ContentFunc {
			[InlineCode("{this}.content={value}")]
			set;
			[InlineCode("{this}.content")]
			get;
		}


		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		/// <value>The Element to be used as content</value>
		public Element ContentElement {
			[InlineCode("{this}.content={value}")]
			set;
			[InlineCode("{this}.content")]
			get;
		}


		/// <summary>
		/// Gets or sets the content
		/// </summary>
		/// <value>The  ElementBase to be use as content.</value>
		public ElementBase ContentElementBase { 
			[InlineCode("{this}.content={value}.getMainElement()")]
			set;
			[InlineCode("{this}.content")]
			get;
		}
	}




}

/*

selector	string	false	if a selector is provided, tooltip objects will be delegated to the specified targets



delay	number | object	0	
delay showing and hiding the popover (ms) - does not apply to manual trigger type

If a number is supplied, delay is applied to both hide/show

Object structure is: delay: { show: 500, hide: 100 }

container	string | false	false	
Appends the popover to a specific element container: 'body'
*/
