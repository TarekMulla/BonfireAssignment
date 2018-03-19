namespace MovieCatalogue.Classes
{
    /// <summary>
    /// Represent Database Server Setting
    /// </summary>
    public class DatabaseServer
    {
        /// <summary>
        /// Name of the Database server
        /// </summary>
        public string ServerName { set; get; }
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
        /// Constructor of Server Setting class which represent SQL Database setting
        /// </summary>
        /// <param name="ServerName">Name of the Database server</param>
        /// <param name="Port">Port Number for connection</param>
        /// <param name="Username">Username for connect to database server</param>
        /// <param name="Password">Password for connect to database server</param>
        public DatabaseServer(string ServerName, string Port, string Username, string Password)
        {
            this.ServerName = ServerName;
            this.Port = Port;
            this.Username = Username;
            this.Password = Password;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DatabaseServer()
        {
        }
    }
}
