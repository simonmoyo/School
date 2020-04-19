using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Web.DataProvider;
using SchoolApp.Web.Models;
using SchoolApp.Web.SQLite;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolApp.Web.Controllers
{
    [Route("api/[controller]")]
    
    public class ClassesController : Controller
    {
        private readonly ClassesDataProvider classesDataProvider;
        public ClassesController()
        {
            classesDataProvider = new ClassesDataProvider();
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Classes> Classes()
        {
            return classesDataProvider.GetClasses();
        }

        // GET api/<controller>/5
        [HttpGet("{ID}")]
        public Classes GetClass(int? ID)
        {
            return classesDataProvider.GetClass(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public int Post([FromBody]Classes classes)
        {
            return classesDataProvider.AddClass(classes);
        }
        // PUT api/<controller>/5
        [HttpPut("{ID}")]
        public int Put([FromBody]Classes classes)
        {
            return classesDataProvider.UpdateClass(classes);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public int DeleteClass(int ID)
        {
            return classesDataProvider.DeleteClass(ID);
        }
    }
}