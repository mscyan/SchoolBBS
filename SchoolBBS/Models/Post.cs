using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBBS.Models
{
	public class Post
	{
		public Post()
		{

		}

		public Post(int community,string title,string content,string postUser,int hasPicture,string picturePath)
		{
			this.community = community;
			this.title = title;
			this.content = content;
			if (content.Length > 30)
				contentOverview = content.Substring(0, 30);
			else
			{
				contentOverview = content;
			}
			this.postUser = postUser;
			this.hasPicture = hasPicture;
			this.picturePath = picturePath;
		}

		public Post(int postID, int community, string title, string content, string contentOverview, string postUser, DateTime postTime, int replyCount, DateTime lastReplyTime, int hasPicture, string picturePath)
		{
			this.postID = postID;
			this.community = community;
			this.title = title;
			this.content = content;
			this.contentOverview = contentOverview;
			this.postUser = postUser;
			this.postTime = postTime;
			this.replyCount = replyCount;
			this.lastReplyTime = lastReplyTime;
			this.hasPicture = hasPicture;
			this.picturePath = picturePath;
		}

		private int postID;				//贴子编号
		private int community;		//所属社区
		private string title;			//标题
		private string content;         //发表内容
		private string contentOverview; //内容概要
		private string postUser;        //发表人
		private DateTime postTime;      //发表时间
		private int replyCount;			//回复数量
		private DateTime lastReplyTime; //最后回复时间
		private int hasPicture;         //是否有图片
		private string picturePath;		//图片路径

		public int PostID
		{
			get { return postID; }
			set { postID = value; }
		}

		public int Community
		{
			get { return community; }
			set { community = value; }
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string Content
		{
			get { return content; }
			set { content = value; }
		}

		public string ContentOverview
		{
			get { return contentOverview; }
			set { contentOverview = value; }
		}

		public string PostUser
		{
			get { return postUser; }
			set { postUser = value; }
		}

		public DateTime PostTime
		{
			get { return postTime; }
			set { postTime = value; }
		}

		public int ReplyCount
		{
			get { return replyCount; }
			set { replyCount = value; }
		}

		public DateTime LastReplyTime
		{
			get { return lastReplyTime; }
			set { lastReplyTime = value; }
		}

		public int HasPicture
		{
			get { return hasPicture; }
			set { hasPicture = value; }
		}

		public string PicturePath
		{
			get { return picturePath; }
			set { picturePath = value; }
		}
	}
}