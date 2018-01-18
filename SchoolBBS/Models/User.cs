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

		public User(string userNumber,string nickname,string password,string headPicPath,string gender,int age,string subjectName,DateTime registerTime):base(userNumber)
		{
			this.UserNumberID = userNumber;
			this.NickName = nickname;
			//this.Password = password;
			this.HeadPicPath = headPicPath;
			this.Gender = gender;
			this.Age = age;
			this.SubjectName = subjectName;
			this.RegisterTime = registerTime;
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