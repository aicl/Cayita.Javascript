using System;
using Cayita.JData;
using jQueryApi;

namespace Cayita
{
	public static partial class UI
	{
		public static StorePager<T> StorePager<T>(Store<T> store) where T: Record, new ()
		{

			var e = new Div ("storage-pager").As<StorePager<T>>();

			var ofText = "of";
			var pageText= "Page";
			Func<Store<T>,string> infoFn = (st) => { 
				var ft = st.FromTo();
				return "from {0} to {1} of {2}".Fmt(ft.Item2, ft.Item3, st.TotalCount);
			};

			e.SetToAtomProperty("update", (Action)(()=>{

				var fromTo = store.FromTo();
				var pagesCount = store.PagesCount();

				e.FirstPage.Disabled = !store.HasPreviousPage ();
				e.PreviousPage.Disabled = !store.HasPreviousPage ();
				e.NextPage.Disabled = !store.HasNextPage ();
				e.LastPage.Disabled = !store.HasNextPage ();

				e.PageLabel.Text= e.PageText;
				e.CurrentPage.Value= (fromTo.Item1<pagesCount? fromTo.Item1 + 1: pagesCount );
				e.TotalPagesLabel.Text= e.OfText+ " "+ pagesCount ;
				e.InfoLabel.Text= e.InfoFn(store);

			}));

			UI.SetToProperty(e, "get_pageText", (Func<string>)(()=> pageText));
			UI.SetToProperty(e, "set_pageText", (Action<string>)((v)=> pageText=v));

			UI.SetToProperty(e, "get_ofText", (Func<string>)(()=> ofText));
			UI.SetToProperty(e, "set_ofText", (Action<string>)((v)=> ofText=v));

			UI.SetToProperty(e, "get_infoFn", (Func<Func<Store<T>,string>>)(()=> infoFn));
			UI.SetToProperty(e, "set_infoFn", (Action<Func<Store<T>,string>>)((v)=> infoFn=v));


			e.NavDiv = new Div ("btn-group");

			e.FirstPage = new ButtonIcon ("icon-double-angle-left");
			e.FirstPage.AddClass ("btn-medium");
			e.FirstPage.Clicked+= ev => store.ReadFirstPage() ;

			e.PreviousPage = new ButtonIcon ("icon-angle-left");
			e.PreviousPage.AddClass ("btn-medium");
			e.PreviousPage.Clicked+= ev => store.ReadPreviousPage() ;

			e.NextPage = new ButtonIcon ("icon-angle-right");
			e.NextPage.AddClass ("btn-medium");
			e.NextPage.Clicked+= ev => store.ReadNextPage() ;

			e.LastPage = new ButtonIcon ("icon-double-angle-right");
			e.LastPage.AddClass ("btn-medium");
			e.LastPage.Clicked+= ev => store.ReadLastPage() ;

			//
			e.PagerDiv = new Div ("form-inline label");
			e.PagerDiv.Style.Padding="4.5px";

			e.PageLabel = new Label ("checkbox");
			e.PageLabel.Style.PaddingRight = "4px";
			e.PageLabel.Text = e.PageText;
			e.PageLabel.Style.FontSize="98%";

			e.CurrentPage = new NullableIntInput ();
			e.CurrentPage.Settings.MinValue = 0;
			e.CurrentPage.ClassName="input-mini";
			e.CurrentPage.Style.Padding="0px";
			e.CurrentPage.Style.Height="18px";
			e.CurrentPage.Style.TextAlign="center";
			e.CurrentPage.Style.FontSize="97%";
			e.CurrentPage.Style.Width="45px";
			e.CurrentPage.On ("keypress", evt => {
				if (evt.Which == 13) {
					store.ReadPage (e.CurrentPage.Value-1);
				}
			});

			e.TotalPagesLabel = new Label ("checkbox");
			e.TotalPagesLabel.Style.PaddingLeft="2px";
			e.TotalPagesLabel.Text = e.OfText;
			e.TotalPagesLabel.Style.FontSize="98%";

			e.InfoDiv = new Div ("form-inline label");
			e.InfoDiv.Style.Padding="4.5px";

			e.InfoLabel =new Label("checkbox");
			e.InfoLabel.Style.PaddingRight="4px";
			e.InfoLabel.Style.FontSize="98%";
			e.InfoLabel.Text= e.InfoFn (store);


			jQuery.FromElement (e.InfoDiv).Append (e.InfoLabel);
			jQuery.FromElement (e.PagerDiv).Append (e.PageLabel).Append (e.CurrentPage).Append (e.TotalPagesLabel);
			jQuery.FromElement(e.NavDiv).Append(e.FirstPage).Append(e.PreviousPage).Append(e.NextPage).Append(e.LastPage);
			jQuery.FromElement (e).Append (e.NavDiv).Append(e.PagerDiv).Append(e.InfoDiv);
					
			store.StoreChanged += (st,dt) => e.Update();

			return e;
		}
	}
}
