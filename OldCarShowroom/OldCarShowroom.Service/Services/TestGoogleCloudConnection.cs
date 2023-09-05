using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCarShowroom.Service.Services
{
    internal class TestGoogleCloudConnection
    {
        public static SqlConnectionStringBuilder NewSqlServerTCPConnectionString()
        {
            var connetionString = new SqlConnectionStringBuilder()
            {
                //DataSource = Environment.GetEnvironmentVariable("INSTANCE_HOST"),
                //UserID = Environment.GetEnvironmentVariable("INSTANCE_HOST"),
                //Password = Environment.GetEnvironmentVariable("INSTANCE_HOST"),
                //InitialCatalog = Environment.GetEnvironmentVariable("INSTANCE_HOST"),
                DataSource = "34.142.250.31",
                UserID = "sqlserver",
                Password = "r<spA|oU6..b#`=V",
                InitialCatalog = "oldcarshowroom",
                Encrypt = false
            };
            connetionString.Pooling = true;

            return connetionString;
        }
    }
}
