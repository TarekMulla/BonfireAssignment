using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace MovieCatalogue.Classes
{
    public static class DBConnection
    {
        /// <summary>
        /// Get Connection string to Database server using SQL Authintication
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name) </param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <param name="SQLUser">Username for connect to database server</param>
        /// <param name="SQLPassword">Password for connect to database server</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default)</param>
        /// <param name="IntegratedSecurity">Allow Connection using Windoth authentication</param>
        /// <param name="MultipleActiveResultSets">Allow create multiple context</param>
        /// <returns>The connection string to the database</returns>
        public static string GetConnectionString(string ServerName, string DataBase, string SQLUser, string SQLPassword, string Port = "", 
            bool IntegratedSecurity = false, bool MultipleActiveResultSets = true)
        {
            string connString = GetConnectionStringBase(ServerName, DataBase, Port);
            if (IntegratedSecurity == true) connString += ";Integrated Security=true";
            else connString += "; User ID=" + SQLUser + ";Password=" + SQLPassword + ";";
            if (MultipleActiveResultSets) connString += ";MultipleActiveResultSets=true";
            return connString;
        }

        /// <summary>
        /// Get Connection string to Database server using windows Authintication
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name) </param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default)</param>
        /// <returns>The connection string to the database</returns>
        public static string GetConnectionString(string ServerName, string DataBase, string Port = "")
        {
            string connString = GetConnectionStringBase(ServerName, DataBase, Port);
            connString += "; Integrated Security=true;";
            return connString;
        }

        /// <summary>
        /// Get Connection string to Database server
        /// </summary>
        /// <param name="Server">Setting of the server </param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <returns>The connection string to the database</returns>
        public static string GetConnectionString(DatabaseServer Server, string DataBase)
        {
            return GetConnectionString(Server.ServerName, DataBase, Server.Username, Server.Password, Server.Port);
        }

        /// <summary>
        /// Return the base string of Connection String
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name)</param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default)</param>
        /// <returns>The base setting of Connection String wich contain (Server name, Port and Database)</returns>
        private static string GetConnectionStringBase(string ServerName, string DataBase, string Port)
        {
            string connString = @"Data Source=" + ServerName;
            if (Port != null && Port != "") connString += "," + Port;
            connString += @";Initial Catalog=" + DataBase + ";MultipleActiveResultSets=true";
            return connString;
        }

        /// <summary>
        /// Test Connection to Database server using SQL Authintication
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name) </param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default) </param>
        /// <param name="SQLUser">Username for connect to database server</param>
        /// <param name="SQLPassword">Password for connect to database server</param>
        /// <returns>Return true if connection test Successful</returns>
        public static bool DBConnectionTest(string ServerName, string DataBase, string SQLUser, string SQLPassword, string Port = "")
        {
            string connString = GetConnectionString(ServerName, DataBase, SQLUser, SQLPassword, Port);
            return DBConnectionTest(connString);
        }

        /// <summary>
        /// Test Connection to Database server using SQL Authintication
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name) </param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default) </param>
        /// <returns>Return true if connection test Successful</returns>
        public static bool DBConnectionTest(string ServerName, string DataBase, string Port = "")
        {
            string connString = GetConnectionString(ServerName, DataBase, Port);
            return DBConnectionTest(connString);
        }

        /// <summary>
        /// Test Connection to Database server using SQL Authintication
        /// </summary>
        /// <param name="Server">Server Setting </param>
        /// <param name="DataBase">Name of database you want to connect with it</param>
        /// <returns>Return true if connection test Successful</returns>
        public static bool DBConnectionTest(DatabaseServer Server, string DataBase)
        {
            string connString = GetConnectionString(Server.ServerName, DataBase, Server.Username, Server.Password, Server.Port);
            return DBConnectionTest(connString);
        }

        /// <summary>
        /// Test Connection to Database server using SQL Authintication
        /// </summary>
        /// <param name="Server">Server Setting </param>
        /// <returns>Return true if connection test Successful</returns>
        public static bool DBConnectionTest(DatabaseServer Server)
        {
            string connString = GetConnectionString(Server.ServerName, "Master", Server.Username, Server.Password, Server.Port);
            return DBConnectionTest(connString);
        }

        /// <summary>
        /// Test Connection to Database using SQL Authintication
        /// </summary>
        /// <param name="Setting">Database  Setting </param>
        /// <returns>Return true if connection test Successful</returns>
        public static bool DBConnectionTest(ConnectionSetting Setting)
        {
            string connString = GetConnectionString(Setting.ServerName, Setting.DatabaseName, Setting.Username, Setting.Password, Setting.Port);
            return DBConnectionTest(connString);
        }

        /// <summary>
        /// Test Connection to Database server using SQL Authintication
        /// </summary>
        /// <param name="ConnectionString">Connection String to the database which we want to test it </param>
        /// <returns>Return true if connection test Successful</returns>
        public static bool DBConnectionTest(string ConnectionString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn.State == ConnectionState.Open;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Check where is the Server is Default one or not
        /// </summary>
        /// <param name="ServerName">Name of the Server</param>
        /// <returns>Is Server default</returns>
        public static bool IsSQLServerDefault(string ServerName)
        {
            if (string.IsNullOrWhiteSpace(ServerName)) return false;
            string MachineName = ServerName.Split('\\').FirstOrDefault()?.Trim().ToLower();
            return MachineName == "." || Environment.MachineName.Trim().ToLower() == MachineName || CurrentMachineIPs.Contains(MachineName);
        }

        /// <summary>
        /// Get the Machine IPs of the Current Computer
        /// </summary>
        public static List<string> CurrentMachineIPs
        {
            get
            {
                List<IPAddress> Ips = Dns.GetHostAddressesAsync(Dns.GetHostName()).Result.Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToList();
                return Ips.Select(x => x.ToString().ToLower().Trim()).ToList();
            }
        }
    }
}
