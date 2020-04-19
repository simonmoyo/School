using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.DataProvider
{
    public interface ITeachersDataProvider
    {
        public IEnumerable<Teachers> GetTeachers();

        public Teachers GetTeacher(int? ID);

        public int AddTeacher(Teachers teacher);

        public int UpdateTeacher(Teachers teacher);

        public int DeleteTeacher(int? ID);
    }
}
