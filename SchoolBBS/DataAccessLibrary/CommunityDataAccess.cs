using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolBBS.Models;
using System.Data;
using DataAccessLibrary;

namespace SchoolBBS.DataAccessLibrary
{
	public class CommunityDataAccess
	{
		//添加社区
		public bool AddCommunity(string communityName,string master)
		{
			string sql = string.Format("insert into [Community] values ('{0}',0,'{1}')",communityName,master);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}


		//获取所有社区
		public List<Community> GetAllCommunities()
		{
			string sql = string.Format("select * from [Community]");
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Community> list = new List<Community>();
				for(int i = 0; i < dt.Rows.Count;i++)
				{
					Community com = new Community();
					com.CommunityID = int.Parse(dt.Rows[i][0].ToString());
					com.CommunityName = dt.Rows[i][1].ToString();
					com.PostCount = int.Parse(dt.Rows[i][2].ToString());
					com.CommunityMaster = dt.Rows[i][3].ToString();
					list.Add(com);
				}
				return list;
			}
			else
				return null;
		}


		//根据社区ID获取社区
		public Community GetCommunityByID(int communityID)
		{
			string sql = string.Format("select * from [Community] where communityID = '{0}'", communityID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Community com = new Community();
				com.CommunityID = int.Parse(dt.Rows[0][0].ToString());
				com.CommunityName = dt.Rows[0][1].ToString();
				com.PostCount = int.Parse(dt.Rows[0][2].ToString());
				com.CommunityMaster = dt.Rows[0][3].ToString();
				return com;
			}
			else
			{
				return null;
			}
		}

		//删除社区（逻辑删除）
		public bool DeleteCommunityByID(int comID)
		{
			string sql = string.Format("update [Community] set isdeleted = 1 where communityID = '{0}'",comID);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}