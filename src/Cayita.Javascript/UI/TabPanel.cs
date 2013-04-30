using System;
using System.Html;
using jQueryApi;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;

namespace Cayita.UI

{
	public class TabPanel:Div
	{
		TabPanelConfig cfg;
		List<Tab> tabs = new List<Tab> ();

		public TabPanel (Element parent):this(parent, new TabPanelConfig() )
		{

		}

		public TabPanel(Element parent, TabPanelConfig config):base(parent)
		{
			var el = Element ();
			el.ClassName = string.Format("tabbable{0}{1}", 
			                             config.Bordered?" tabbable-bordered":"",
			                             "tabs-"+config.TabsPosition);
			el.Append (config.Links).Append (config.Content);

			cfg = config;

			this.JQuery ("a[data-toggle='tab']").On ("shown", evt => {
				var crt =evt.Target.As<AnchorElement>();
				var prv = evt.RelatedTarget.As<AnchorElement>();

				if(crt!=null){
					var current = tabs.First(f=>"#"+f.Body.ID== crt.Href );
				}

				if(prv!=null){
				}


			});

		}

		public void AddTab(string title)
		{
			AddTab (new Tab { Title=title });
		}

		public void AddTab( Tab tab)
		{
			tabs.Add (tab);
			cfg.Links.AddItem ((i,a) => {
				a.Href="#"+tab.Body.ID;
				a.SetAttribute("data-toggle", "tab");
				a.Text(tab.Title);
			});

			cfg.Content.Append (tab.Body);
		}

		public Tab GetTab(int index)
		{
			return new Tab ();
		}

		public void Show(int index)
		{
			var t = tabs [index];
			Show(this.JQuery ("a[href='#" + t.Body.ID + "']"));
		}

		[InlineCode("{tab}.tab('show')")]
		void Show(jQueryObject tab)
		{
		}

		public event Action<TabPanel,Tab,Tab> OnShown;
		public event Action<TabPanel,Tab,Tab> OnShow;
		public event Action<TabPanel,Tab> OnClick;

	}

	[Serializable]
	public class TabPanelConfig
	{
		public TabPanelConfig()
		{
			Bordered = true;
			TabsPosition = "top";

			NavType = "tabs";

			new HtmlList (null, l => {
				l.ClassName = string.Format ("nav nav-{0}", NavType);
				Links=l;
			});

			new Div (null, d => {
				d.ClassName="tab-content";
				Content=d;
			});

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

		public ListElement Links { get; set; }

		public DivElement Content { get; set; }

	}


	[Serializable]
	public class Tab
	{
		public Tab()
		{
			Title = "";
			Name = "";

			new Div (null, d => {
				d.ClassName="tab-pane";
				Body=d;
			});
		}

		public string Title { get; set; }
		public string Name { get; set; }
		public Action<jQueryEvent> OnClickHandler{ get; set; }
		public DivElement Body { get; set; }

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