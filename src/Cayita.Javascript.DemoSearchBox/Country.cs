using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using Cayita.Data;
using Cayita.UI;
using System.Collections.Generic;

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
					var qp = GetLastOption().QueryParams;
					if( qp.ContainsKey("Name") )
					{
						var n = qp["Name"].ToString();
						("Request: "+ n ).LogInfo();
						Filter(f=> f.Name.ToUpper().StartsWith(	n.ToUpper() ) );
					}
			});
		}

	}
	
}
