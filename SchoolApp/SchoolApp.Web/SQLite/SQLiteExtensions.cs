using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using Dapper;

namespace SchoolApp.Web.SQLite
{
    public static class SQLiteExtensions
    {
        public static void ExecuteNonQuery(this SQLiteConnection connection,
            string commandText,
            object param = null)
        {
            if (connection == null)
            {
                throw new NullReferenceException("Please provide a connection");
            }

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            connection.Execute(commandText);
        }
    }
}
