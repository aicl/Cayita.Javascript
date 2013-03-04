using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[ScriptNamespace("Cayita.UI")]
	public class TopNavBar:Div
	{
		Div containerFluid;
		Div navCollapse;
		AnchorElement brand;
		Element pullRightParagraph;
		AnchorElement pullRightAnchor;
		HtmlList navList;

		public Div GetContainerFluid()
		{
			return containerFluid;
		}

		public Div GetNavCollapse()
		{
			return navCollapse;
		}

		public AnchorElement GetBrand()
		{
			return brand;
		}

		public Element GetPullRightParagraph() 
		{
			return pullRightParagraph;
		}

		public AnchorElement GetPullRightAnchor()
		{
			return pullRightAnchor;
		}

		public HtmlList GetNavList()
		{
			return navList;
		}

		public TopNavBar (Element parent, string brandText, string rightText, string rightLinkText,
		                  Action<Element> navlist)
			:base(parent)
		{

			Element().ClassName="navbar navbar-inverse navbar-fixed-top";

			new Div(Element(),inner=>{
				inner.ClassName="navbar-inner";
				containerFluid = Div.CreateContainerFluid(inner,fluid=>{
					new Anchor(fluid, anchor=>{
						anchor.ClassName="btn btn-navbar";
						anchor.SetAttribute("data-toggle","collapse");
						anchor.SetAttribute("data-target",".nav-collapse");
						for(int i =0; i<3; i++){
							new Span(anchor, span=>{span.ClassName="icon-bar";});
						}

					});
					brand= new Anchor(fluid, brnd=>{
						brnd.Href="#";
						brnd.Text(brandText);
						brnd.ClassName="brand";
					}).Element();
					navCollapse = new Div(fluid, collapse=>{
						collapse.ClassName="nav-collapse collapse";
						pullRightParagraph= new Paragraph(collapse,
						paragraph=>{
							paragraph.ClassName="navbar-text pull-right";
							paragraph.Text(rightText);
							pullRightAnchor= new Anchor(paragraph, a=>{
								a.Href="#";  a.ClassName="navbar-link" ; a.Text(rightLinkText);
							}).Element();
						}).Element();
						navList= HtmlList.CreateNavList(collapse, navlist);
						navList.RemoveClass("nav-list");
					});
				});
			});

		}
	}
}
