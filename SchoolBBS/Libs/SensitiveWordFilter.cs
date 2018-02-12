using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SchoolBBS.Libs
{
	public class SensitiveWordFilter
	{
		private SensitiveWordFilter()
		{
			//Do nothing
		}

		//通过本地txt匹配发表的言论验证是否有敏感词汇以过滤
		public static string CheckValidity(string checkString)
		{
			FileInfo fi = new FileInfo(@"C:\Users\CYAN\Documents\Visual Studio 2017\Projects\SchoolBBS\SchoolBBS\Assets\SensiWORDS.txt");
			FileStream fs = fi.Open(FileMode.Open);
			byte[] array = new byte[32];
			StreamReader reader = new StreamReader(fs,System.Text.Encoding.UTF8);
			string readerSUB;
			while ((readerSUB = reader.ReadLine()) != null)
			{
				if (checkString.Contains(readerSUB))
				{
					checkString = checkString.Replace(readerSUB,new string('*',readerSUB.Length));
				}
			}
			fs.Close();
			return checkString;
		}
	}
}