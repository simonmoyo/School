using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.DataProvider
{
    public interface IStudentsDataProvider
    {
        public IEnumerable<Students> GetStudents();

        public Students GetStudent(int? ID);

        public int AddStudent(Students student);

        public int UpdateStudent(Students student);

        public int DeleteStudent(int? ID);
    }
}
