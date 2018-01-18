using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolBBS.Models
{
	public class Log
	{
		public Log()
		{

		}

		private int logID;
		private string logUserNumber;
		private string logUserName;
		private string logInfo;
		private DateTime logTime;

		public int LogID
		{
			get { return logID; }
			set { logID = value; }
		}

		public string LogUserNumber
		{
			get { return logUserNumber; }
			set { logUserNumber = value; }
		}

		public string LogUserName
		{
			get { return logUserName; }
			set { logUserName = value; }
		}

		public string LogInfo
		{
			get { return logInfo; }
			set { logInfo = value; }
		}

		public DateTime LogTime
		{
			get { return logTime; }
			set { logTime = value; }
		}

		//添加操作到日志表中
		public bool AddLogAction()
		{
			
			return false;
		}
	}
}