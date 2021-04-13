using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNETCOREConfigurationDemo
{
    public class Configuration
    {
        public DatabaseConfiguration Database { get; set; }
    }
    public class DatabaseConfiguration
    {
        public string DatabaseName { get; set; }
        public string ServerHost { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString => $"Server=tcp:{ServerHost},{Port};Database={DatabaseName};User ID={Username};Password={Password};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}

