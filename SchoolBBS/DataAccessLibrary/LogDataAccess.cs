using DataAccessLibrary;
using SchoolBBS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SchoolBBS.DataAccessLibrary
{
	public class LogDataAccess
	{
		//添加一条日志
		public bool AddLog(string logUserNumber,string logUserName,string logInfo)
		{
			string sql = string.Format("insert into [Log] values ('{0}','{1}','{2}','{3}')", logUserNumber, logUserName, logInfo, DateTime.Now.ToLocalTime().ToString());
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//根据用户ID查找日志
		public List<Log> GetLogsByUserNumber(string userNumber)
		{
			string sql = string.Format("select * from [Log] where logUserNumber = '{0}'", userNumber);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Log> list = new List<Log>();
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					Log log = new Log();
					log.LogID = int.Parse(dt.Rows[i][0].ToString());
					log.LogUserNumber = dt.Rows[i][1].ToString();
					log.LogUserName = dt.Rows[i][2].ToString();
					log.LogInfo = dt.Rows[i][3].ToString();
					log.LogTime = DateTime.Parse(dt.Rows[i][4].ToString());
					list.Add(log);
				}
				return list;
			}
			else
				return null;
		}


		//根据日志编号查找日志
		public Log GetLogByLogID(string logID)
		{
			string sql = string.Format("select * from [Log] where logID = '{0}'", logID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Log log = new Log();
				log.LogID = int.Parse(dt.Rows[0][0].ToString());
				log.LogUserNumber = dt.Rows[0][1].ToString();
				log.LogUserName = dt.Rows[0][2].ToString();
				log.LogInfo = dt.Rows[0][3].ToString();
				log.LogTime = DateTime.Parse(dt.Rows[0][4].ToString());
				return log;
			}
			else
				return null;
		}
	}
}