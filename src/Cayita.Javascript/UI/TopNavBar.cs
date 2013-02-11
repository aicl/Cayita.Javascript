using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{

	[Serializable]	
	[ScriptNamespace("Cayita.UI")]

	public class TopNavBar:Div
	{
		public Div ContainerFluid{get;private set;}
		public Div NavCollapse{get;private set;}
		public AnchorElement Brand {get;private set;}
		public Element PullRightParagraph {get;private set;}
		public Anchor PullRightAnchor {get;private set;}
		public Element NavList {get;private set;}

		public TopNavBar (Element parent, string brand, string rightText, string rightLinkText,
		                  Action<Element> navlist)
			:base(parent)
		{

			Element().ClassName="navbar navbar-inverse navbar-fixed-top";

			new Div(Element(),inner=>{
				inner.ClassName="navbar-inner";
				ContainerFluid = Div.CreateContainerFluid(inner,fluid=>{
					new Anchor(fluid, anchor=>{
						anchor.ClassName="btn btn-navbar";
						anchor.SetAttribute("data-toggle","collapse");
						anchor.SetAttribute("data-target",".nav-collapse");
						for(int i =0; i<3; i++){
							new Span(anchor,new SpanConfig{CssClass="icon-bar"});
						}

					});
					new Anchor(fluid, brnd=>{
						brnd.Href="#";
						brnd.InnerText=brand;
						brnd.ClassName="brand";
					});
					NavCollapse = new Div(fluid, collapse=>{
						collapse.ClassName="nav-collapse collapse";
						PullRightParagraph= new Paragraph(collapse, new ParagraphConfig{
							Text=rightText, CssClass="navbar-text pull-right"
						},
						paragraph=>{
							PullRightAnchor= new Anchor(paragraph, a=>{
								a.Href="#";  a.ClassName="navbar-link" ; a.InnerText=rightLinkText;
							});
						}).Element();
						HtmlList.CreatNavList(collapse, navlist);
					});
				});
			});

		}
	}
}
