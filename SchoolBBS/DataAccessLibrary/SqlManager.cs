using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DataAccessLibrary
{
	public class SqlManager
	{
		//public static string connStr = "Data Source=MSI;Initial Catalog=食品溯源;Integrated Security=True";
		public static string connStr = ConfigurationManager.ConnectionStrings["connectionStringss"].ToString();

		public SqlManager() { }

		/// <summary>
		/// 增删改操作
		/// </summary>
		/// <returns></returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
		{
			SqlCommand cmd = new SqlCommand();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				Prepareconmand(cmd, conn, null, commandType, commandText, paras);
				int val = cmd.ExecuteNonQuery();
				cmd.Parameters.Clear();
				return val;
			}
		}

		/// <summary>
		/// 获取DataTable
		/// </summary>
		/// <returns></returns>
		public static DataTable GetDataTable(string connectionString, CommandType commandType, string commandText, params SqlParameter[] paras)
		{
			SqlCommand cmd = new SqlCommand();
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				Prepareconmand(cmd, conn, null, commandType, commandText, paras);
				using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
				{
					DataTable dt = new DataTable();
					sda.Fill(dt);
					return dt;
				}
			}
		}

		/// <summary>
		/// 初始化Command对象
		/// </summary>
		private static void Prepareconmand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType commandType, string commandText, SqlParameter[] paras)
		{
			try
			{
				if (conn.State != ConnectionState.Open)
				{
					conn.Close();
					conn.Open();
				}
				cmd.Connection = conn;
				if (commandText != null)
				{
					cmd.CommandText = commandText;
				}
				cmd.CommandType = commandType;

				if (trans != null)
				{
					cmd.Transaction = trans;
				}

				if (paras != null && paras.Length > 0)
				{
					for (int i = 0; i < paras.Length; i++)
					{
						if (paras[i].Value == null && paras[i].Value.ToString() == "")
							paras[i].Value = DBNull.Value;
						cmd.Parameters.Add(paras[i]);
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
