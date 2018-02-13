using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBBS.Models
{
	public class Community
	{
		public Community()
		{

		}

		private int communityID;
		private string communityName;
		private int postCount;
		private string communityMaster;
		private string headPicPath;
		private string description;
		private string declare;
		private int isdeleted;

		public int CommunityID
		{
			get { return communityID; }
			set { communityID = value; }
		}

		public string CommunityName
		{
			get { return communityName; }
			set { communityName = value; }
		}

		public int PostCount
		{
			get { return postCount; }
			set { postCount = value; }
		}

		public string CommunityMaster
		{
			get { return communityMaster; }
			set { communityMaster = value; }
		}

		public string HeadPicPath
		{
			get { return headPicPath; }
			set { headPicPath = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public string Declare
		{
			get { return declare; }
			set { declare = value; }
		}

		public int IsDeleted
		{
			get { return isdeleted; }
			set { isdeleted = value; }
		}
	}
}