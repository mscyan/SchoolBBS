using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolBBS.Models;
using DataAccessLibrary;
using System.Data;

namespace SchoolBBS.DataAccessLibrary
{
	public class PostDataAccess
	{
		//添加一条帖子
		public bool AddPost(Post post)
		{
			string sql = string.Format("insert into [Post] " +
				"(community,title,[content],contentOverview,postUser,postTime,replyCount,lastReplyTime,hasPicture,picturePath,isdeleted) values " +
				"('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
				post.Community,post.Title,post.Content,post.ContentOverview,post.PostUser,DateTime.Now.ToLocalTime().ToString(),0,DateTime.Now.ToLocalTime().ToString(),post.HasPicture,post.PicturePath,0);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//通过编号获取一条帖子对象
		public Post GetPostByID(int postID)
		{
			string sql = string.Format("select * from [post] where postID = '{0}'", postID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Post post = new Post(
					int.Parse(dt.Rows[0][0].ToString()),
					int.Parse(dt.Rows[0][1].ToString()),
					dt.Rows[0][2].ToString(),
					dt.Rows[0][3].ToString(),
					dt.Rows[0][4].ToString(),
					dt.Rows[0][5].ToString(),
					DateTime.Parse(dt.Rows[0][6].ToString()),
					int.Parse(dt.Rows[0][7].ToString()),
					DateTime.Parse(dt.Rows[0][8].ToString()),
					int.Parse(dt.Rows[0][9].ToString()),
					dt.Rows[0][10].ToString()
					);
				return post;
			}
			else
				return null;
		}

		//获取某个帖子内部回复的数量
		public int GetFloorByPostID(int postID)
		{
			string sql = string.Format("select count(*) from Reply where replyOfPost = '{0}'", postID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		public bool SetReplyCount(int postID)
		{
			string sql = string.Format("update [Post] set replyCount = '{0}' where postID = '{1}'", GetFloorByPostID(postID), postID);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获取社区内所有帖子数量
		public int GetPostCountByCommunityID(int comID)
		{
			string sql = string.Format("select Count(*) from [Post] where community = {0}", comID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			return int.Parse(dt.Rows[0][0].ToString());
		}

		//管理界面获取集合，全部获取
		public List<Post> GetAllPostsByCommunityID(int comID, int pageindex, int pagesize)
		{
			string sql = string.Format("select top {0} * from [Post] where postID not in (select top {1} postID from [Post] where community = '{2}')" +
				" and community = {3}", pagesize, pagesize * (pageindex - 1), comID, comID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Post> list = new List<Post>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Post post = new Post(
					int.Parse(dt.Rows[i][0].ToString()),
					int.Parse(dt.Rows[i][1].ToString()),
					dt.Rows[i][2].ToString(),
					dt.Rows[i][3].ToString(),
					dt.Rows[i][4].ToString(),
					dt.Rows[i][5].ToString(),
					DateTime.Parse(dt.Rows[i][6].ToString()),
					int.Parse(dt.Rows[i][7].ToString()),
					DateTime.Parse(dt.Rows[i][8].ToString()),
					int.Parse(dt.Rows[i][9].ToString()),
					dt.Rows[i][10].ToString()
					);
					post.IsDeleted = int.Parse(dt.Rows[i][11].ToString());
					list.Add(post);
				}
				return list;
			}
			else
				return null;
		}

		//根据所在社区/每页数量/页数 获得帖子集合，只获取未删除的
		public List<Post> GetPostsByCommunityID(int comID,int pageindex,int pagesize)
		{
			string sql = string.Format("select top {0} * from [Post] where postID not in (select top {1} postID from [Post] where community = '{2}') and isdeelted = 0" +
				" and community = {3}",pagesize,pagesize*(pageindex-1),comID,comID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Post> list = new List<Post>();
				for(int i = 0; i < dt.Rows.Count; i++)
				{
					Post post = new Post(
					int.Parse(dt.Rows[i][0].ToString()),
					int.Parse(dt.Rows[i][1].ToString()),
					dt.Rows[i][2].ToString(),
					dt.Rows[i][3].ToString(),
					dt.Rows[i][4].ToString(),
					dt.Rows[i][5].ToString(),
					DateTime.Parse(dt.Rows[i][6].ToString()),
					int.Parse(dt.Rows[i][7].ToString()),
					DateTime.Parse(dt.Rows[i][8].ToString()),
					int.Parse(dt.Rows[i][9].ToString()),
					dt.Rows[i][10].ToString()
					);
					list.Add(post);
				}
				return list;
			}
			else
				return null;
		}

		//删除帖子（逻辑删除）
		public bool DeletePostByID(string postID)
		{
			string sql = string.Format("update [post] set isdeleted = 1 where postID = '{0}'",postID);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}


		//修改帖子内容（是否要做）不需要做
	}
}