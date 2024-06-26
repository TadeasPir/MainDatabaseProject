﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    /// <summary>
    /// Represents a singleton class for managing database connections.
    /// </summary>
	/// 
    public class DatabaseSingleton
    {
		private static SqlConnection conn = null;
		private DatabaseSingleton()
		{
		}

        /// <summary>
        /// Gets the singleton instance of the database connection.
        /// </summary>
        /// <returns>The singleton instance of the SqlConnection object.</returns>
        public static SqlConnection GetInstance()
		{
			if (conn == null)
			{
				SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
				consStringBuilder.UserID = ReadSetting("Name");
				consStringBuilder.Password = ReadSetting("Password");
				consStringBuilder.InitialCatalog = ReadSetting("Database");
				consStringBuilder.DataSource = ReadSetting("DataSource");
				consStringBuilder.ConnectTimeout = 30;
				conn = new SqlConnection(consStringBuilder.ConnectionString);
				conn.Open();
			}
			return conn;
		}

		public static void CloseConnection()
		{
			if (conn != null)
			{
				conn.Close();
				conn.Dispose();
			}
		}

        /// <summary>
        /// Reads a setting value from the application's configuration file.
        /// </summary>
        /// <param name="key">The key of the setting to read.</param>
        /// <returns>The value of the setting if found, otherwise "Not Found".</returns>
        private static string ReadSetting(string key)
		{
			
			var appSettings = ConfigurationManager.AppSettings;
			string result = appSettings[key] ?? "Not Found";
			return result;
		}
	}
}
