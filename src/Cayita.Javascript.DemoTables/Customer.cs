using System;
using System.Runtime.CompilerServices;
using Cayita.Javascript.Data;
using jQueryApi;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	[Serializable]
	[PreserveMemberCase]
	public class Customer
	{

		public Customer (){}
		public string Id { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }

	}

	[IgnoreNamespace]
	public class CustomerStore:Store<Customer>
	{
		
		public CustomerStore():base()
		{
			SetReadApi(api=>{
				api.Url="json/customersResponse.json";
				api.DataProperty="Customers";
			});
		}

		public IDeferred<Customer> Read()
		{
			return base.Read (ro=>{
				ro.LocalPaging=true;
				ro.PageNumber = 0;
				ro.PageSize = 10;

			});
		}


	}

}

//"Id":"ALFKI","CompanyName":"Alfreds Futterkiste","ContactName":"Maria Anders","ContactTitle":"Sales Representative","Address":"Obere Str. 57","City":"Berlin","PostalCode":"12209","Country":"Germany","Phone":"030-0074321","Fax":"030-0076545"}
