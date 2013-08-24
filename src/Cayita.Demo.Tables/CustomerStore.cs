using System;
using Cayita.JData;

namespace Cayita.Demo
{
	public class CustomerStore:Store<Customer>
	{
		public CustomerStore ()
		{
			Api.Url="json/customersResponse.json"; 
			Api.ReadMethod = "";
			Api.DataProperty = "Customers";

			LastOption.PageNumber = 0;
			LastOption.PageSize = 10;
			LastOption.LocalPaging = true;

		}
	}
}

