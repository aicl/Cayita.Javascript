using System;
using System.Runtime.CompilerServices;
using Cayita.Javascript.Data;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	[Serializable]
	[PreserveMemberCase]
	public  class User
	{
		public User(){}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public DateTime DoB { get; set; }
		public bool IsActive { get; set; }
		public string Level { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public int Rating { get; set; }
	}

	[IgnoreNamespace]
	public class UserStore:Store<User>
	{
		public UserStore():base()
		{
			SetReadApi(api=>api.Url="json/userResponse.json");
		}
	}
}

