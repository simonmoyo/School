using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.DataProvider
{
    public class SubjectsDataProvider : ISubjectsDataProvider
    {
        private readonly string connectionString = "Server=tcp:schooldbserver.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID=sqluser;Password=DevAssess96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int AddSubject(Subjects subject)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", subject.Name);
                parameters.Add("@Teacher", subject.Teacher); rowAffected = con.Execute("spAddSubject", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }


        public int DeleteSubject(int? SubjectCode)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SubjectCode", SubjectCode);
                rowAffected = con.Execute("spDeleteSubject", parameters, commandType: CommandType.StoredProcedure);

            }

            return rowAffected;
        }


        public Subjects GetSubject(int? SubjectCode)
        {
            
            Subjects subject = new Subjects();
            if (SubjectCode == null)
                return subject;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@SubjectCode", SubjectCode);
                subject = con.Query<Subjects>("spGetSubject", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return subject;
        }


        public IEnumerable<Subjects> GetSubjects()
        {
            List<Subjects> getSubjectsList = new List<Subjects>();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                getSubjectsList = con.Query<Subjects>("spGetSubjects").ToList();
            }
            return getSubjectsList;
        }

        public int UpdateSubject(Subjects subject)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SubjectCode", subject.SubjectCode);
                parameters.Add("@Name", subject.Name);
                parameters.Add("@Teacher", subject.Teacher); rowAffected = con.Execute("spUpdateSubject", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

    }



}
