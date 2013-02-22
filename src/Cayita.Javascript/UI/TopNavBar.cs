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
		Anchor brand;
		Element pullRightParagraph;
		Anchor pullRightAnchor;
		HtmlList navList;

		public Div GetContainerFluid()
		{
			return containerFluid;
		}

		public Div GetNavCollapse()
		{
			return navCollapse;
		}

		public Anchor GetBrand()
		{
			return brand;
		}

		public Element GetPullRightParagraph() 
		{
			return pullRightParagraph;
		}

		public Anchor GetPullRightAnchor()
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
							new Span(anchor,new SpanConfig{CssClass="icon-bar"});
						}

					});
					brand= new Anchor(fluid, brnd=>{
						brnd.Href="#";
						brnd.InnerText=brandText;
						brnd.ClassName="brand";
					});
					navCollapse = new Div(fluid, collapse=>{
						collapse.ClassName="nav-collapse collapse";
						pullRightParagraph= new Paragraph(collapse,
						paragraph=>{
							paragraph.ClassName="navbar-text pull-right";
							paragraph.JSelect().Text(rightText);
							pullRightAnchor= new Anchor(paragraph, a=>{
								a.Href="#";  a.ClassName="navbar-link" ; a.InnerText=rightLinkText;
							});
						}).Element();
						navList= HtmlList.CreatNavList(collapse, navlist);
					});
				});
			});

		}
	}
}
