using System;
using System.Html;
using jQueryApi;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Cayita.UI

{
	public class TabPanel:TabPanelBase<TabPanel>
	{
		public TabPanel (ElementBase parent):base(parent.Element())
		{}
		
		public TabPanel(ElementBase parent, Action<TabPanelConfig> config)
			:base(parent.Element(), config)
		{}
		
		public TabPanel(ElementBase parent, TabPanelConfig config)
			:base(parent.Element(), config)
		{}
		
		public TabPanel ():base(default(Element))
		{}
		
		public TabPanel (Element parent):base(parent)
		{
		}
		
		public TabPanel (Element parent, Action<TabPanelConfig> config):base(parent, config)
		{
		}
		
		public TabPanel(Element parent, TabPanelConfig config):base(parent,config)
		{
		}

	}


	public abstract class TabPanelBase<T>:ElementBase<T> where T:ElementBase 
	{
		TabPanelConfig cfg;
		List<Tab> tabs = new List<Tab> ();

		public TabPanelBase (ElementBase parent):this(parent.Element())
		{}

		public TabPanelBase (ElementBase parent, Action<TabPanelConfig> config)
			:this(parent.Element(), config)
		{}

		public TabPanelBase (ElementBase parent, TabPanelConfig config)
			:this(parent.Element(), config)
		{}

		public TabPanelBase ():this(default(Element))
		{}

		public TabPanelBase (Element parent)
		{
			Init (parent, new TabPanelConfig ());
		}

		public TabPanelBase (Element parent, Action<TabPanelConfig> config)
		{
			var c = new TabPanelConfig ();
			config.Invoke (c);
			Init (parent, c);
		}

		public TabPanelBase(Element parent, TabPanelConfig config)
		{
			Init (parent, config);
		}

		void Init (Element parent, TabPanelConfig config)
		{
			CreateElement ("div", parent);
			ClassName (string.Format ("tabbable{0}{1}",
			                         config.Bordered ? " tabbable-bordered" : "",
			                         " tabs-" + config.TabsPosition));

			if (config.TabsPosition != "below") {
				Append (config.Links);
				Append (config.Content);
			} else {
				Append (config.Content);
				Append (config.Links);
			}

			cfg = config;
			JQuery ("a[data-toggle='tab']").On ("shown", evt =>  
				OnTabShown (GetTab (evt.Target.As<AnchorElement> ()), GetTab (evt.RelatedTarget.As<AnchorElement> ()))
			);
			JQuery ("a[data-toggle='tab']").On ("show", evt =>  
				OnTabShow ( GetTab (evt.Target.As<AnchorElement> ()), GetTab (evt.RelatedTarget.As<AnchorElement> ()))
			);
			JQuery ("a[data-toggle='tab']").On ("Click", evt =>  {
				if (TabClicked != null) {
					evt.PreventDefault ();
					TabClicked (this, GetTab (evt.Target.As<AnchorElement> ()));
				}
			});
		}


		Tab GetTab(AnchorElement anchor){
			return (anchor != null) ? tabs.First (f => "#" + f.Body.ID == anchor.Href) : default(Tab);
		}

		public T AddTab(string title)
		{
			return AddTab (new Tab { Title=title });
		}

		public T AddTab( Tab tab)
		{
			tabs.Add (tab);
			cfg.Links.AddItem ((i,a) => {
				a.Href="#"+tab.Body.ID;
				a.SetAttribute("data-toggle", "tab");
				a.Text(tab.Title);
			});

			cfg.Content.Append (tab.Body);
			return As<T> ();
		}


		public T AddTab(Action<Tab> tab, Action<AnchorElement> anchor = null)
		{
			var t = new Tab ();
			tab.Invoke (t);
			tabs.Add (t);

			cfg.Links.AddItem ((i,a) => {
				a.Href="#"+t.Body.ID;
				a.SetAttribute("data-toggle", "tab");
				if(anchor!=null) anchor.Invoke(a);
				else a.Text(t.Title);
			});
			
			cfg.Content.Append (t.Body);
			return As<T> ();

		}

		public Tab GetTab(int index)
		{
			return new Tab ();
		}

		public T ShowTab(int index)
		{
			var t = tabs [index];
			var jq = cfg.Links.JQuery ();
			Firebug.Console.Log ("jq ", jq);
			var jq2 = cfg.Links.JQuery ("a[href='#" + t.Body.ID + "']");
			Firebug.Console.Log ("jq2 ", jq2);
			Firebug.Console.Log ("t.Body.ID ", t.Body.ID);
			ShowTab(cfg.Links.JQuery("a[href='#" + t.Body.ID + "']"));
			return As<T> ();
		}

		public T ShowTab(Tab tab)
		{
			ShowTab(cfg.Links.JQuery ("a[href='#" + tab.Body.ID + "']"));
			return As<T> ();
		}

		[InlineCode("{tab}.tab('show')")]
		void ShowTab(jQueryObject tab)
		{
		}


		/// <summary>
		/// This event fires on tab show after a tab has been shown.
		/// <TabPanelBase,Tab,Tab> 
		/// TabPanelBase, the active tab and the previous active tab (if available) respectively.
		/// </summary>
		public event Action<TabPanelBase<T>,Tab,Tab> TabShown = (p,ac,pr) => {};

		protected virtual void OnTabShown ( Tab active, Tab previous)
		{
			TabShown (this, active, previous);
		}

		/// <summary>
		/// This event fires on tab show, but before the new tab has been shown. 
		/// <TabPanelBase,Tab,Tab> 
		/// TabPanelBase, the active tab and the previous active tab (if available) respectively.
		/// </summary>
		public event Action<TabPanelBase<T>,Tab,Tab> TabShow = (p,ac,pr) => {};

		protected virtual void OnTabShow ( Tab active, Tab previous)
		{
			TabShow(this,active, previous);
		}

		/// <summary>
		/// Occurs when on tab click.
		/// <TabPanelBase,Tab> TabPanelBase, Tab clicked.
		/// </summary>
		public event Action<TabPanelBase<T>,Tab> TabClicked ;

		protected virtual void OnTabClicked (Tab tab)
		{
			if (TabClicked != null)
				TabClicked (this, tab);
		}
	}

	[Serializable]
	public class TabPanelConfig
	{
		public TabPanelConfig()
		{
			Bordered = false;
			TabsPosition = "top";

			NavType = "tabs";

			Links = new HtmlList (null, l => {
				l.ClassName = string.Format ("nav nav-{0}{1}", NavType, Stacked ? " nav-stacked" : "");

			});

			Content = new Div ( d => d.ClassName = "tab-content");

		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Cayita.UI.TabPanelConfig"/> is bordered.
		/// </summary>
		/// <value><c>true</c> if bordered; otherwise, <c>false</c>.</value>
		public bool Bordered { get; set; }

		/// <summary>
		/// Gets or sets the tabs position.
		/// </summary>
		/// <value>The tabs position: top, right, below, left</value>
		public string TabsPosition { get; set; }

		/// <summary>
		/// Gets or sets the type of the nav.
		/// </summary>
		/// <value>The type of the nav:tabs || pills.</value>
		public string NavType { get; set; }


		public bool Stacked { get; set; }

		public HtmlList Links { get; set; }

		public Div Content { get; set; }

	}


	[Serializable]
	public class Tab
	{
		public Tab()
		{
			Title = "";
			Name = "";

			Body= new Div ().ClassName("tab-pane");

		}

		public string Title { get; set; }
		public string Name { get; set; }
		public Div Body { get; set; }

	}
}

/*

//var t =$('#myTab a[href="#profile"]');  t.tab("show");
			//t["tab"]("show");--> jquery object



$('a[data-toggle="tab"]').on('shown', function (e) {
  e.target // activated tab  <a href="#profile" data-toggle="tab">Profile</a> 
  e.relatedTarget // previous tab
})

<div class="tabbable"> <!-- Only required for left/right tabs -->
  <ul class="nav nav-tabs">
    <li class="active"><a href="#tab1" data-toggle="tab">Section 1</a></li>
    <li><a href="#tab2" data-toggle="tab">Section 2</a></li>
  </ul>
  <div class="tab-content">
    <div class="tab-pane active" id="tab1">
      <p>I'm in Section 1.</p>
    </div>
    <div class="tab-pane" id="tab2">
      <p>Howdy, I'm in Section 2.</p>
    </div>
  </div>
</div>


*/