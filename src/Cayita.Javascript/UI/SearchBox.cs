using System;
using Cayita.UI;
using System.Html;

namespace Cayita.UI
{
	public class SearchBox:Div
	{
		TextElement te;
		ButtonElement bt;
		DivElement m;
		DivElement body;

		public SearchBox ():base(default(Element))
		{
			Init ();
		}


		void Init()
		{
			m = Element ();
			te = new InputText (m).Element();
			te.ClassName="search-query";

			bt = new Button (m).Element();
			bt.Text ("Search");

			body = new Div (m).Element();
			body.ClassName="modal";
			body.Append (" BODY ");
			body.Hide ();
			body.ClassName = "c-search-body";


			bt.OnClick (e => {
				body.JQuery().Toggle();
			});
		}
	}
}

