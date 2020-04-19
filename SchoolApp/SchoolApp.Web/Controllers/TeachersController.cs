using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Web.DataProvider;
using SchoolApp.Web.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApp.Web.Controllers
{

    [Route("api/[controller]")]
    public class TeachersController : Controller
    {
        private readonly TeachersDataProvider teachersDataProvider;
        public TeachersController()
        {
            teachersDataProvider = new TeachersDataProvider();
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Teachers> GetTeachers()
        {
            return teachersDataProvider.GetTeachers();
        }

        // GET api/<controller>/5
        [HttpGet("{ID}")]
        public Teachers GetTeacher(int ID) 
        {
            return teachersDataProvider.GetTeacher(ID);
        }


        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Teachers teacher) 
        {
            return teachersDataProvider.AddTeacher(teacher);
        }
        // PUT api/<controller>/5
        [HttpPut("{ID}")]
        public int Put([FromBody]Teachers teacher)
        {
            return teachersDataProvider.UpdateTeacher(teacher);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public int DeleteTeacher(int ID)
        {
            return teachersDataProvider.DeleteTeacher(ID);
        }
    }
}
