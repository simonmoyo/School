using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using SchoolApp.Web.Models;
using Dapper;

namespace SchoolApp.Web.SQLite
{
    public static class StudentsExtensions
    {
        public static void AddStudent(this Students student,
        SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            INSERT INTO Students (ID, Name, Subjects, ClassID, AddedOn )
            VALUES (@ID, @Name, @Subjects, @ClassID, @AddedOn)",
                student);
        }

        public static Students GetStudent(this SQLiteConnection connection)
        {
            var studentCollection = connection.Query<Students>(
                "SELECT * FROM Students");

            return studentCollection.FirstOrDefault();
        }

        public static Students GetStudent(this SQLiteConnection connection,
        int ID)
        {
            var studentCollection = connection.Query<Students>(
                "SELECT * FROM Students WHERE ID = @ID");

            return studentCollection.FirstOrDefault();
        }

        public static void UpdateStudent(this Students student, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            UPDATE Students
            SET
            Name = @Name, Subjects = @Subjects, ClassID = @ClassID, AddedOn = @AddedOn
            WHERE ID = @ID", student);
        }

        public static void DeleteStudent(this Students student, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(
                "DELETE FROM Students WHERE ID = @ID", student);
        }
    }
}
