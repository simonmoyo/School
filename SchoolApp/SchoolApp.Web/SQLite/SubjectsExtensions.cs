using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using SchoolApp.Web.Models;
using Dapper;

namespace SchoolApp.Web.SQLite
{
    public static class SubjectsExtensions
    {
        public static void AddSubjects(this Subjects subject,
      SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            INSERT INTO Subjects (SubjectCode, Name, Teacher)
            VALUES (@SubjectCode, @Name, @Teacher)",
                subject);
        }

        public static Subjects subject(this SQLiteConnection connection)
        {
            var subjectCollection = connection.Query<Subjects>(
                "SELECT * FROM Subjects");

            return subjectCollection.FirstOrDefault();
        }

        public static Subjects GetSubject(this SQLiteConnection connection,
        int SubjectCode)
        {
            var subjectCollection = connection.Query<Subjects>(
                "SELECT * FROM Subjects WHERE SubjectCode = @SubjectCode");

            return subjectCollection.FirstOrDefault();
        }

        public static void UpdateSubject(this Subjects subject, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(@"
            UPDATE Subjects
            SET
            Name = @Name, Teacher = @Teacher
            WHERE SubjectCode = @SubjectCode", subject);
        }

        public static void DeleteSubject(this Subjects subject, SQLiteConnection connection)
        {
            connection.ExecuteNonQuery(
                "DELETE FROM Subjects WHERE SubjectCode = @SubjectCode", subject);
        }
    }
}
