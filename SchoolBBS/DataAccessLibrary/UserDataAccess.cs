using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SchoolBBS.Models;

namespace SchoolBBS.DataAccessLibrary
{
	public class UserDataAccess
	{
		//向用户表中添加一条记录
		public bool AddUser(string userNumber, string nickname, string password, string age, string subject)
		{
			string sql = string.Format("insert into [User] values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
				userNumber, nickname, password, "N", "M",age, subject, DateTime.Now.ToLocalTime().ToString(),1);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//判断用户名为userNumber的用户是否存在
		public bool isUserExist(string userNumber)
		{
			string sql = string.Format("select * from [User] where [userNumber] = '{0}'", userNumber);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
				return true;
			else
				return false;
		}

		//判断用户名、密码是否都符合
		public bool isUserExist(string userNumber,string password)
		{
			string sql = string.Format("select * from [User] where [userNumber] = '{0}' and [password] = '{1}'", userNumber,password);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				return true;
			}
			else
				return false;
		}

		//根据ID获取用户
		public User GetUserByID(string userNumber)
		{
			string sql = string.Format("select * from [User] where [userNumber] = '{0}'", userNumber);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				User user = new User(
					dt.Rows[0][0].ToString(),
					dt.Rows[0][1].ToString(),
					dt.Rows[0][2].ToString(),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString(),
					int.Parse(dt.Rows[0][5].ToString()),
					dt.Rows[0][6].ToString(),
					DateTime.Parse(dt.Rows[0][7].ToString())
					);
				
				return user;
			}
			else
				return null;
		}

		//根据用户ID修改用户信息
		public bool AlterUserInfoByID(string usr, string nick, string gen, int age, string subject)
		{
			string sql = string.Format("update [User] set nickname = '{0}',gender = '{1}',age = '{2}',subjectName = '{3}' where userNumber = '{4}'", nick, gen, age, subject, usr);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}