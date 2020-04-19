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
    public class StudentsDataProvider : IStudentsDataProvider
    {

        private string connectionString = "Server=tcp:schooldbserver.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID=sqluser;Password=DevAssess96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        public int AddStudent(Students student)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", student.Name);
                parameters.Add("@Subjects", student.Subjects);
                parameters.Add("@ClassID", student.ClassID);
                parameters.Add("@AddedOn", student.AddedOn); rowAffected = con.Execute("spAddStudent", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }


        public int DeleteStudent(int? ID)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                rowAffected = con.Execute("spDeleteStudent", parameters, commandType: CommandType.StoredProcedure);

            }

            return rowAffected;
        }


        public Students GetStudent(int? ID)
        {
           
            Students student = new Students();
            if (ID == null)
                return student;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID", ID);
                student = con.Query<Students>("spGetStudent", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return student;
        }


        public IEnumerable<Students> GetStudents()
        {
            List<Students> getStudentsList = new List<Students>();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                getStudentsList = con.Query<Students>("spGetStudents").ToList();
            }
            return getStudentsList;
        }

        public int UpdateStudent(Students student)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", student.ID);
                parameters.Add("@Name", student.Name);
                parameters.Add("@Subjects", student.Subjects);
                parameters.Add("@ClassID", student.ClassID);
                parameters.Add("@AddedOn", student.AddedOn); rowAffected = con.Execute("spUpdateStudent", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

    }
}
