using System;
using System.Runtime.CompilerServices;

namespace Cayita.Demo
{
	[PreserveMemberCase]
	public class Customer:Record
	{
		public Customer ()
		{
		}

		public string Id { get; set; }
		public string CompanyName { get; set; }
		public string ContactName { get; set; }
		public string Country { get; set; }
	}
}

