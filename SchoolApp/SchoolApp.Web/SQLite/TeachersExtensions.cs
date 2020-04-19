using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using SchoolApp.Web.Models;
using Dapper;

namespace SchoolApp.Web.SQLite
{
    public static class TeachersExtensions
    {
        public static void AddTeacher(this Teachers teacher,
        SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            INSERT INTO Teachers (ID, Name, Subjects, AddedOn )
            VALUES (@ID, @Name, @Subjects, @AddedOn)",
                teacher);
        }

        public static Teachers GetTeachers(this SQLiteConnection connection)
        {
            var teachersCollection = connection.Query<Teachers>(
                "SELECT * FROM Teachers");

            return teachersCollection.FirstOrDefault();
        }

        public static Teachers GetTeacher(this SQLiteConnection connection,
        int ID)
        {
            var teachersCollection = connection.Query<Teachers>(
                "SELECT * FROM Teachers WHERE ID = @ID");

            return teachersCollection.FirstOrDefault();
        }

        public static void UpdateTeacher(this Teachers teacher, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            UPDATE Teachers
            SET
            Name = @Name, Subjects = @Subjects, AddedOn = @AddedOn
            WHERE ID = @ID", teacher);
        }

        public static void DeleteTeacher(this Teachers teacher, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(
                "DELETE FROM Teachers WHERE ID = @ID", teacher);
        }
    }
}
