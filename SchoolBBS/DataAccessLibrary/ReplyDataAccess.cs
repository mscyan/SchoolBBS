using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolBBS.Models;
using System.Data;
using DataAccessLibrary;

namespace SchoolBBS.DataAccessLibrary
{
	public class ReplyDataAccess
	{
		//添加一条回复
		public bool AddReply(Reply reply)
		{
			string sql = string.Format("insert into [Reply] values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
				reply.ReplyOfPost,reply.ReplyUser,reply.ReplyTime,reply.ReplyFloor,reply.ReplyContent,reply.HasPicture,reply.PicturePath,0);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}

		//获取某个帖子的所有回复集合
		public List<Reply> GetReplysByPostID(int postID)
		{
			string sql = string.Format("select * from [Reply] where replyOfPost = '{0}' and isdeleted = 0", postID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Reply> list = new List<Reply>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Reply reply = new Reply();
					reply.ReplyID = int.Parse(dt.Rows[i][0].ToString());
					reply.ReplyOfPost = int.Parse(dt.Rows[i][1].ToString());
					reply.ReplyUser = dt.Rows[i][2].ToString();
					reply.ReplyTime = DateTime.Parse(dt.Rows[i][3].ToString());
					reply.ReplyFloor = int.Parse(dt.Rows[i][4].ToString());
					reply.ReplyContent = dt.Rows[i][5].ToString();
					reply.HasPicture = int.Parse(dt.Rows[i][6].ToString());
					reply.PicturePath = dt.Rows[i][7].ToString();
					list.Add(reply);
				}
				return list;
			}
			else
				return null;
		}

		//根据replyID获取某条回复
		public Reply GetReplyByReplyID(int replyID)
		{
			string sql = string.Format("select * from [Reply] where replyID = '{0}'", replyID);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				Reply reply = new Reply();
				reply.ReplyID = int.Parse(dt.Rows[0][0].ToString());
				reply.ReplyOfPost = int.Parse(dt.Rows[0][1].ToString());
				reply.ReplyUser = dt.Rows[0][2].ToString();
				reply.ReplyTime = DateTime.Parse(dt.Rows[0][3].ToString());
				reply.ReplyFloor = int.Parse(dt.Rows[0][4].ToString());
				reply.ReplyContent = dt.Rows[0][5].ToString();
				reply.HasPicture = int.Parse(dt.Rows[0][6].ToString());
				reply.PicturePath = dt.Rows[0][7].ToString();
				return reply;
			}
			else
				return null;
		}

		//获取某个用户发表的回复的集合
		public List<Reply> GetReplysByUserID(string userNumber)
		{
			string sql = string.Format("select * from [Reply] where replyUser = '{0}' and isdeleted = 0", userNumber);
			DataTable dt = SqlManager.GetDataTable(SqlManager.connStr, CommandType.Text, sql, null);
			if (dt.Rows.Count > 0)
			{
				List<Reply> list = new List<Reply>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					Reply reply = new Reply();
					reply.ReplyID = int.Parse(dt.Rows[i][0].ToString());
					reply.ReplyOfPost = int.Parse(dt.Rows[i][1].ToString());
					reply.ReplyUser = dt.Rows[i][2].ToString();
					reply.ReplyTime = DateTime.Parse(dt.Rows[i][3].ToString());
					reply.ReplyFloor = int.Parse(dt.Rows[i][4].ToString());
					reply.ReplyContent = dt.Rows[i][5].ToString();
					reply.HasPicture = int.Parse(dt.Rows[i][6].ToString());
					reply.PicturePath = dt.Rows[i][7].ToString();
					list.Add(reply);
				}
				return list;
			}
			else
				return null;
		}

		//删除回复（逻辑删除）
		public bool DeleteReplyByReplyID(int replyID)
		{
			string sql = string.Format("update [Reply] set isdeleted = 1 where replyID = '{0}'", replyID);
			object obj = SqlManager.ExecuteNonQuery(SqlManager.connStr, CommandType.Text, sql, null);
			if (Convert.ToInt32(obj) > 0)
				return true;
			else
				return false;
		}
	}
}