using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parser.Database
{
    //SINGLETON
    class DbConfig
    {
        private static volatile DbConfig instance;
        private volatile SqlConnection connection;
        private static object syncRoot = new object();
        private static readonly string connectionString = @"Data Source=DESKTOP-GAN2GTI\SQLEXPRESS;Initial Catalog=parser;Integrated Security=True";

        private DbConfig(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public static DbConfig GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DbConfig(connectionString);
                    }
                }

                return instance;
            }
        }

        public SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}