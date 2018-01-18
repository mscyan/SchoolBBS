using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBBS.Models
{
	public class User : AbstractUser
	{
		public User(string userNumber):base(userNumber)
		{
			this.UserNumberID = userNumber;
		}

		public override bool AddUser()
		{
			throw new NotImplementedException();
		}

		public override bool DeleteUserByID()
		{
			throw new NotImplementedException();
		}

		public override bool GetUserByID()
		{
			throw new NotImplementedException();
		}

		public override bool UpdateUserByID()
		{
			throw new NotImplementedException();
		}
	}
}