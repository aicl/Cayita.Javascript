using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using Cayita.Data;
using System.Html;

namespace Cayita.Javascript
{
	[IgnoreNamespace]
	[Serializable]
	[PreserveMemberCase]
	public class Country
	{
		
		public Country (){}
		public string Code { get; set; }
		public string Name { get; set; }

	}
	
	[IgnoreNamespace]
	public class CountryStore:Store<Country>
	{
		
		public CountryStore():base()
		{
			SetIdProperty ("Code");

			SetReadApi(api=>{
				api.Url="json/countriesResponse.json";
				api.DataProperty="Countries";

			});
		}
		
		public override IDeferred<Country> Read(Action<ReadOptions> options=null, bool clear=true)
		{
								
			if (options == null) {

				return base.Read (ro => {
					ro.LocalPaging = true;
					ro.PageNumber = 0;
					ro.PageSize = 10;
				}, clear);
			} else {
				return base.Read (options, clear)
					.Done(t=>{ // mimic server side
						Firebug.Console.Log("read country", Count, GetTotalCount());
						Filter(f=> f.Name.ToUpper().StartsWith(
							GetLastOption().QueryParams["Name"].ToString().ToUpper() ) );
						Firebug.Console.Log("read country", Count, GetTotalCount());
						
				});
			}


		}
		
	}
	
}
