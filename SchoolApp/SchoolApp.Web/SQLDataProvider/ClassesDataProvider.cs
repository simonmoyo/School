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
    public class ClassesDataProvider : IClassesDataProvider
    {

        private static string connectionString = "Server=tcp:schooldbserver.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID=sqluser;Password=DevAssess96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public int AddClass(Classes classes)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", classes.Name);
                parameters.Add("@Teacher", classes.Teacher); rowAffected = con.Execute("spAddClass", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;

        }


        public int DeleteClass(int? ID)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", ID);
                rowAffected = con.Execute("spDeleteClass", parameters, commandType: CommandType.StoredProcedure);

            }

            return rowAffected;
        }


        public Classes GetClass(int? ID)
        {
            Classes classes = new Classes();
            if (ID == null)
                return classes;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID", ID);
                classes = con.Query<Classes>("spGetClass", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return classes;
        }


        public IEnumerable<Classes> GetClasses()
        {
            List<Classes> getList = new List<Classes>();
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                getList = con.Query<Classes>("spGetClasses").ToList();
            }
            return getList;
        }

        public int UpdateClass(Classes classes)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ID", classes.ID);
                parameters.Add("@Name", classes.Name);
                parameters.Add("@Teacher", classes.Teacher); rowAffected = con.Execute("spUpdateClass", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }

    }



}
