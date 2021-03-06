﻿using System;
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
		// Todo
		public bool AddCommunity(string communityName,string master,string description)
		{
			string sql = string.Format("insert into [Community] values ('{0}',0,'{1}','','{2}','',0)",communityName,master,description);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获取所有社区，管理界面
		public List<Community> GetAllTheCommunities()
		{
			string sql = string.Format("select * from [Community]");
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Community> list = new List<Community>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Community com = new Community();
					com.CommunityID = int.Parse(dt.Rows[i][0].ToString());
					com.CommunityName = dt.Rows[i][1].ToString();
					com.PostCount = int.Parse(dt.Rows[i][2].ToString());
					com.CommunityMaster = dt.Rows[i][3].ToString();
					com.HeadPicPath = dt.Rows[i][4].ToString();
					com.Description = dt.Rows[i][5].ToString();
					com.Declare = dt.Rows[i][6].ToString();
					com.IsDeleted = int.Parse(dt.Rows[i][7].ToString());
					list.Add(com);
				}
				return list;
			}
			else
				return null;
		}

		//获取所有社区
		public List<Community> GetAllCommunities()
		{
			string sql = string.Format("select * from [Community] where isdeleted = 0");
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
					com.HeadPicPath = dt.Rows[i][4].ToString();
					com.Description = dt.Rows[i][5].ToString();
					com.Declare = dt.Rows[i][6].ToString();
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
				com.HeadPicPath = dt.Rows[0][4].ToString();
				com.Description = dt.Rows[0][5].ToString();
				com.Declare = dt.Rows[0][6].ToString();
				return com;
			}
			else
			{
				return null;
			}
		}

		//修改管理员
		public bool UpdateMasterByID(int ID,string userNumber)
		{
			string sql = string.Format("update [Community] set [communityMaster] = '{0}' where communityID = '{1}'",userNumber,ID);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//修改公告
		public bool UpdateDeclareByID(int ID,string declare)
		{
			string sql = string.Format("update [Community] set [declare] = '{0}' where communityID = '{1}'",declare,ID);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
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