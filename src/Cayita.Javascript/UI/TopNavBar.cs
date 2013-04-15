using System;
using System.Html;

namespace Cayita.UI
{

	public class TopNavBar:Div
	{
		DivElement ctFluid;
		DivElement nCollapse;
		AnchorElement bElement;
		ParagraphElement pullRP;
		AnchorElement pRA;
		ListElement nList;

		public DivElement ContainerFluid()
		{
			return ctFluid;
		}

		public DivElement NavCollapse()
		{
			return nCollapse;
		}

		public AnchorElement Brand()
		{
			return bElement;
		}

		public ParagraphElement PullRightParagraph() 
		{
			return pullRP;
		}

		public AnchorElement PullRightAnchor()
		{
			return pRA;
		}

		public ListElement NavList()
		{
			return nList;
		}

		public TopNavBar (Element parent, string brandText,  Action<ListElement> navlist)
			:this(parent, brandText,"","", navlist)
		{}

		public TopNavBar (Element parent, string brandText, string rightText, string rightLinkText,
		                  Action<ListElement> navlist)
			:base(parent)
		{
			Element().ClassName="navbar";

			new Div(Element(),inner=>{
				inner.ClassName="navbar-inner";
				ctFluid = Div.CreateContainerFluid(inner,fluid=>{
					new Anchor(fluid, anchor=>{
						anchor.ClassName="btn btn-navbar";
						anchor.SetAttribute("data-toggle","collapse");
						anchor.SetAttribute("data-target",".nav-collapse");
						for(int i =0; i<3; i++){
							new Span(anchor, span=>{span.ClassName="icon-bar";});
						}

					});
					bElement= new Anchor(fluid, brnd=>{
						brnd.Href="#";
						brnd.Text(brandText);
						brnd.ClassName="brand";
					}).Element();
					nCollapse = new Div(fluid, collapse=>{
						collapse.ClassName="nav-collapse collapse";
						pullRP= new Paragraph(collapse,
						paragraph=>{
							paragraph.ClassName="navbar-text pull-right";
							paragraph.Text(rightText);
							pRA= new Anchor(paragraph, a=>{
								a.Href="#";  a.ClassName="navbar-link" ; a.Text(rightLinkText);
							}).Element();
						}).Element();
						nList= HtmlList.CreateNavList(collapse, navlist).Element();
						nList.RemoveClass("nav-list");
					}).Element();
				}).Element();
			});
		}
	}
}
