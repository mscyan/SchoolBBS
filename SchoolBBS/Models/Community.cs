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
	}
}