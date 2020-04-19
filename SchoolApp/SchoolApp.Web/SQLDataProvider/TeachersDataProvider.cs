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
    public class TeachersDataProvider : ITeachersDataProvider
    {

       readonly string connectionString = "Server=tcp:schooldbserver.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID=sqluser;Password=DevAssess96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        public int AddTeacher(Teachers teacher)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", teacher.Name);
                parameters.Add("@Subjects", teacher.Subjects);
                parameters.Add("@AddedOn", teacher.AddedOn);
                rowAffected = con.Execute("spAddTeacher", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }


        public int DeleteTeacher(int? ID)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                rowAffected = con.Execute("spDeleteTeacher", parameters, commandType: CommandType.StoredProcedure);

            }

            return rowAffected;
        }


        public Teachers GetTeacher(int? ID)
        {
            Teachers teacher = new Teachers();
            if (ID == null)
                return teacher;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID", ID);
                teacher = con.Query<Teachers>("spGetTeacher", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return teacher;
        }


        public IEnumerable<Teachers> GetTeachers()
        {
            string connectionString = "Server=tcp:schooldbserver.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID=sqluser;Password=DevAssess96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            List<Teachers> getTeachersList = new List<Teachers>();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                getTeachersList = con.Query<Teachers>("spGetTeachers").ToList();
            }
            return getTeachersList;
        }

       public int UpdateTeacher(Teachers teacher)  
        {  
            int rowAffected = 0;  
  
            using (IDbConnection con = new SqlConnection(connectionString))  
            {  
                if (con.State == ConnectionState.Closed)  
                    con.Open();  
  
                DynamicParameters parameters = new DynamicParameters();  
                parameters.Add("@ID", teacher.ID);
                parameters.Add("@Name", teacher.Name);
                parameters.Add("@Subjects", teacher.Subjects);
                parameters.Add("@AddedOn", teacher.AddedOn);  
              rowAffected=  con.Execute("spUpdateTeacher",parameters,commandType:CommandType.StoredProcedure);  
            }  
                          
            return rowAffected;  
        }  

    }
}
