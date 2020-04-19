using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.DataProvider
{
    public interface IClassesDataProvider
    {
        public IEnumerable<Classes> GetClasses();

        public Classes GetClass(int? ID);

        public int AddClass(Classes classes);

        public int UpdateClass(Classes classes);

        public int DeleteClass(int? ID);
    }
}
