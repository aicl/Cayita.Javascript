using System;
using System.Runtime.CompilerServices;
using System.Html;


namespace Cayita.Javascript.UI
{

	[ScriptNamespace("Cayita.UI")]
	public class SpinnerIcon:ElementBase
	{
		Element icon;

		public SpinnerIcon (Element parent, Action<DivElement,Element> config, string message  )
		{

			CreateElement("div", parent, new ElementConfig());
			Element().ClassName="well well-large lead";

			icon = new Icon(Element(), i=>{
				i.ClassName="icon-spinner icon-spin icon-2x pull-left";
			}).Element();

			config.Invoke(Element(), icon);

			Element().Append(message);

		}

		public SpinnerIcon ( Action<Element,Element> config, string message  )
			:this(default(Element), config, message)
		{}

		public new DivElement Element()
		{
			return (DivElement) base.Element();
		}


		public Element GetIcon()
		{
			return icon;
		}

	}
}

/*
<div class="well well-large well-transparent lead">
	<i class="icon-spinner icon-spin icon-2x pull-left">
		</i>Spinner icon when loading content
		</div>

*/