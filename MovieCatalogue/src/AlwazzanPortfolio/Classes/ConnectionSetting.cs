using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCatalogue.Classes
{
    /// <summary>
    /// Class which represent the connection setting to SQL Database
    /// </summary>
    public class ConnectionSetting
    {
        /// <summary>
        /// Name of the Database server
        /// </summary>
        public string ServerName { set; get; }
        /// <summary>
        /// Name of database you want to connect with it
        /// </summary>
        public string DatabaseName { set; get; }
        /// <summary>
        /// Port Number for connection
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        /// Username for connect to database server
        /// </summary>
        public string Username { set; get; }
        /// <summary>
        /// Password for connect to database server
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// Connect with windows authentication
        /// </summary>
        public bool IntegratedSecurity { set; get; }

        /// <summary>
        /// Allow Multiple Contexts
        /// </summary>
        public bool MultipleActiveResultSets { set; get; }

        /// <summary>
        /// Constructor of Connection Setting Class which represent the Connection setting to SQL Database server
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name)</param>
        /// <param name="DatabaseName">Name of database you want to connect with it</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default)</param>
        /// <param name="Username">Username for connect to database server</param>
        /// <param name="Password">Password for connect to database server</param>
        /// <param name="IntegratedSecurity">Allow Connection using Windoth authentication</param>
        /// <param name="MultipleActiveResultSets">Allow create multiple context</param>
        public ConnectionSetting(string ServerName, string DatabaseName, string Port, string Username,
            string Password, bool IntegratedSecurity = false, bool MultipleActiveResultSets = true)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.Port = Port;
            this.Username = Username;
            this.Password = Password;
            this.IntegratedSecurity = IntegratedSecurity;
            this.MultipleActiveResultSets = MultipleActiveResultSets;
        }

        /// <summary>
        /// Constructor of Connection Setting Class which represent the Connection setting to SQL Database server
        /// </summary>
        /// <param name="ServerName">Name of the Database server (Usualy it is the same of Server name)</param>
        /// <param name="DatabaseName">Name of database you want to connect with it</param>
        /// <param name="Port">Port Number for connection (Leave empty if the the database server name is not default)</param>
        /// <param name="IntegratedSecurity">Allow Connection using Windoth authentication</param>
        /// <param name="MultipleActiveResultSets">Allow create multiple context</param>
        public ConnectionSetting(string ServerName, string DatabaseName, string Port, bool IntegratedSecurity = false, bool MultipleActiveResultSets = true)
        {
            this.ServerName = ServerName;
            this.DatabaseName = DatabaseName;
            this.Port = Port;
            this.IntegratedSecurity = IntegratedSecurity;
            this.MultipleActiveResultSets = MultipleActiveResultSets;
        }

        /// <summary>
        /// Constructor of Connection Setting Class which represent the Connection setting to SQL Database server
        /// </summary>
        /// <param name="Server">Server Settings</param>
        /// <param name="DatabaseName">Name of database you want to connect with it</param>
        public ConnectionSetting(DatabaseServer Server, string DatabaseName)
        {
            this.ServerName = Server.ServerName;
            this.DatabaseName = DatabaseName;
            this.Port = Server.Port;
            this.Username = Server.Username;
            this.Password = Server.Password;
        }

        /// <summary>
        /// Default Constructor of Connection Setting Class which represent the Connection setting to SQL Database server
        /// </summary>
        public ConnectionSetting()
        {
        }

        /// <summary>
        /// Get the Connection string dependence on Connnection setting properties
        /// </summary>
        /// <returns>Connection string to the Database</returns>
        public string GetConnectionString()
        {
            return DBConnection.GetConnectionString(ServerName, DatabaseName, Username, Password,
                Port, IntegratedSecurity, MultipleActiveResultSets);
        }

        /// <summary>
        /// Get the Connection string dependence on Connnection setting properties
        /// </summary>
        /// <returns>Connection string to the Database</returns>
        public override string ToString()
        {
            return GetConnectionString();
        }
    }
}
