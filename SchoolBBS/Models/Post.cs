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

		private int postID;				//贴子编号
		private string community;		//所属社区
		private string title;			//标题
		private string content;         //发表内容
		private string contentOverview; //内容概要
		private string postUser;        //发表人
		private DateTime postTime;      //发表时间
		private int replyCount;		//回复数量
		private DateTime lastReplyTime; //最后回复时间
		private int hasPicture;         //是否有图片
		private string picturePath;		//图片路径

		public int PostID
		{
			get { return postID; }
			set { postID = value; }
		}

		public string Community
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