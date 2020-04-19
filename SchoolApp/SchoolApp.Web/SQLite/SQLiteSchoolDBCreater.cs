using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace SchoolApp.Web.SQLite
{
    public class SQLiteSchoolDBCreater
    {
        private static SQLiteConnection _dbConnection;
        static void CreateAndOpenDb()
        {
            var dbFilePath = "./SchoolDb.sqlite";
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }
            _dbConnection = new SQLiteConnection(string.Format(
                "Data Source={0};Version=3;", dbFilePath));
            _dbConnection.Open();
        }

        static void CreateTables()
        {
            _dbConnection.ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS [Classes] (
            [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Name] NVARCHAR(50) NOT NULL,
            [Teacher] NVARCHAR(250) NOT NULL)");

            _dbConnection.ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS [Students] (
            [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Name] NVARCHAR(50) NOT NULL,
            [Subjects] NVARCHAR(250) NOT NULL,
            [ClassID] NVARCHAR(250) NOT NULL,
            [AddedOn] TIMESTAMP DEFAULT CURRENT_TIMESTAMP)");

            _dbConnection.ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS [Subjects] (
            [SubjectCode] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Name] NVARCHAR(50) NOT NULL,
            [Teacher] NVARCHAR(250) NOT NULL)");

            _dbConnection.ExecuteNonQuery(@"
            CREATE TABLE IF NOT EXISTS [Teachers] (
            [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Name] NVARCHAR(50) NOT NULL,
            [Subjects] NVARCHAR(250) NOT NULL,
            [AddedOn] TIMESTAMP DEFAULT CURRENT_TIMESTAMP)");

        }
    }   

}
