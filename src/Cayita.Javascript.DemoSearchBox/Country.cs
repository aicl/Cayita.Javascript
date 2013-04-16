using System;
using System.Runtime.CompilerServices;
using jQueryApi;
using Cayita.Data;

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
		
		public IDeferred<Country> Read()
		{
			Firebug.Console.Log ("Country Read", this);
			return base.Read (ro=>{
				ro.LocalPaging=true;
				ro.PageNumber = 0;
				ro.PageSize = 10;
			});
		}
		
	}
	
}
