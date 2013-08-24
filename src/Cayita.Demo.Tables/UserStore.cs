using System;
using Cayita.JData;

namespace Cayita.Demo
{

	public class UserStore:Store<User>
	{
		static int id=0;

		public UserStore()
		{
			Api.Url="json/userResponse.json"; 
			Api.ReadMethod = "";
			Api.Converters ["DoB"] = u => u.DoB.Normalize ();
		}

		public void Save(User u)
		{
			if (u.Id == 0) {
				u.Id = --id;
				Add (u);

			} else {
				Replace (u);
			}

		}

	}

}

