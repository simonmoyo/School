using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Web.DataProvider;
using SchoolApp.Web.Models;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApp.Web.Controllers
{
    [Route("Subjects")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly SubjectsDataProvider subjectsDataProvider;
        public SubjectsController()
        {
            subjectsDataProvider = new SubjectsDataProvider();
        }
       

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Subjects> GetSubjects()
        {
            return subjectsDataProvider.GetSubjects();
        }

        // GET api/<controller>/5
        [HttpGet("{ID}")]
        public Subjects GetSubject(int? SubjectCode)
        {
            return subjectsDataProvider.GetSubject(SubjectCode);    
        }


        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Subjects subject)
        {
            return subjectsDataProvider.AddSubject(subject);
        }
        // PUT api/<controller>/5
        [HttpPut("{SubjectCode}")]
        public int Put([FromBody]Subjects subject)
        {
            return subjectsDataProvider.UpdateSubject(subject);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public int DeleteSubject(int? SubjectCode)
        {
            return subjectsDataProvider.DeleteSubject(SubjectCode);
        }
    }
}
