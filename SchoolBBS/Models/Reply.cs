using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBBS.Models
{
	public class Reply
	{
		public Reply()
		{

		}

		private int replyID;
		private int replyOfPost;
		private string replyUser;
		private DateTime replyTime;
		private int replyFloor;
		private string replyContent;
		private int hasPicture;
		private string picturePath;

		public int ReplyID
		{
			get { return replyID; }
			set { replyID = value; }
		}

		public int ReplyOfPost
		{
			get { return replyOfPost; }
			set { replyOfPost = value; }
		}

		public string ReplyUser
		{
			get { return replyUser; }
			set { replyUser = value; }
		}

		public DateTime ReplyTime
		{
			get { return replyTime; }
			set { replyTime = value; }
		}

		public int ReplyFloor
		{
			get { return replyFloor; }
			set { replyFloor = value; }
		}

		public string ReplyContent
		{
			get { return replyContent; }
			set { replyContent = value; }
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