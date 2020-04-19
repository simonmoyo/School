using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using SchoolApp.Web.Models;
using Dapper;

namespace SchoolApp.Web.SQLite
{
    public static class ClassesExtensions
    {
        public static void AddClass(this Classes classes,
        SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            INSERT INTO Classes (ID, Name, Teacher)
            VALUES (@ID, @Name, @Teacher)",
                classes);
        }

        public static Classes GetClasses(this SQLiteConnection connection)
        {
            var classCollection = connection.Query<Classes>(
                "SELECT * FROM Classes");

            return classCollection.FirstOrDefault();
        }
        
        public static Classes GetClass(this SQLiteConnection connection,
        int ID)
        {
            var classCollection = connection.Query<Classes>(
                "SELECT * FROM Classes WHERE ID = @ID");

            return classCollection.FirstOrDefault();
        }

        public static void UpdateClass(this Classes classes, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            UPDATE Classes
            SET
            Name = @Name, Teacher = @Teacher
            WHERE ID = @ID", classes);
        }

        public static void DeleteClass(this Classes classes, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(
                "DELETE FROM Classes WHERE ID = @ID", classes);
        }
    }
}
