using System;
using System.Html;


namespace Cayita.UI
{
	public class SpinnerIcon:Div
	{
		IconElement ic;

		public SpinnerIcon (Element parent, Action<DivElement,IconElement> config, string message  )
			:base(parent)
		{

			Element().ClassName="well well-large lead";

			ic = new Icon(Element(), i=>{
				i.ClassName="icon-spinner icon-spin icon-2x pull-left";
			}).Element();

			config.Invoke(Element(), ic);

			Element().Append(message);

		}

		public SpinnerIcon ( Action<DivElement,Element> config, string message  )
			:this(default(Element), config, message)
		{}

		public new DivElement Element()
		{
			return (DivElement) base.Element();
		}


		public Element Icon()
		{
			return ic;
		}

	}
}

/*
<div class="well well-large well-transparent lead">
	<i class="icon-spinner icon-spin icon-2x pull-left">
		</i>Spinner icon when loading content
		</div>

*/