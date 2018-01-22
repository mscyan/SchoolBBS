using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBBS.Models
{
	public abstract class AbstractUser
	{
		public AbstractUser()
		{

		}
		public AbstractUser(string userNumber)
		{
			
		}

		private string userNumberID;
		private string nickName;
		private string password;
		private string headPicPath;
		private string gender;
		private int age;
		private string subjectName;
		private DateTime registerTime;

		public string UserNumberID
		{
			get { return userNumberID; }
			set { userNumberID = value; }
		}

		public string NickName
		{
			get { return nickName; }
			set { nickName = value; }
		}

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		public string HeadPicPath
		{
			get { return headPicPath; }
			set { headPicPath = value; }
		}

		public string Gender
		{
			get { return gender; }
			set { gender = value; }
		}

		public int Age
		{
			get { return age; }
			set { age = value; }
		}

		public string SubjectName
		{
			get { return subjectName; }
			set { subjectName = value; }
		}

		public DateTime RegisterTime
		{
			get { return registerTime; }
			set { registerTime = value; }
		}

		public abstract bool AddUser();

		public abstract bool UpdateUserByID();

		public abstract bool GetUserByID();

		public abstract bool DeleteUserByID();
	}
}