using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using Cayita.Data;
using System.Serialization;
using Cayita.UI;

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
		
		public CountryStore(Action<ReadOptions> options=null):base()
		{
			var ro = GetLastOption ();
			ro.PageNumber = 0;
			ro.PageSize = 10;

			if (options != null)
				options.Invoke (ro);

			SetIdProperty ("Code");

			SetReadApi(api=>{
				api.Url="json/countriesResponse.json";
				api.DataProperty="Countries";

			});

		}
		
		public override IDeferred<Country> Read(Action<ReadOptions> options=null, bool clear=true)
		{					

			return base.Read (options, clear)
				.Done(t=>{ // mimic server side
					if( GetLastOption().QueryParams.ContainsKey("Name") )
					{
						("Request: "+ Json.Stringify(((object)GetLastOption().GetRequestObject()))).LogInfo();
						Filter(f=> f.Name.ToUpper().StartsWith(
													GetLastOption().QueryParams["Name"].ToString().ToUpper() ) );

					}				
			});

		}
		
	}
	
}
