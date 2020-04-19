using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using SchoolApp.Web.DataProvider;
using SchoolApp.Web.Models;
using Dapper;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApp.Web.Controllers
{
    [Route("api/[controller]")]

    public class StudentsController : Controller
    {
        private readonly StudentsDataProvider studentsDataProvider;
        public StudentsController()
        {
            studentsDataProvider = new StudentsDataProvider();
        }
        private static string connectionString = "Server=tcp:schooldbserver.database.windows.net,1433;Initial Catalog=SchoolDB;Persist Security Info=False;User ID=sqluser;Password=DevAssess96;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Students> GetStudents()
        {
                return studentsDataProvider.GetStudents();
        }

        // GET api/<controller>/5
        [HttpGet("{ID}")]
        public Students GetStudent(int? ID)
        {
            return studentsDataProvider.GetStudent(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Students student)
        {
            return studentsDataProvider.AddStudent(student);
        }
        // PUT api/<controller>/5
        [HttpPut("{ID}")]
        public int Put([FromBody]Students student)
        {
            return studentsDataProvider.UpdateStudent(student);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public int DeleteStudent(int ID)
        {
            return studentsDataProvider.DeleteStudent(ID);
        }

    }
}
