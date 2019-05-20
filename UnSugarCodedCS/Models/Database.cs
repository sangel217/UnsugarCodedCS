using System;
using MySql.Data.MySqlClient;
using UnSugarCodedCS;

namespace UnSugarCodedCS.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
