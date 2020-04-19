using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.DataProvider
{
    public interface ISubjectsDataProvider 
    {
        public IEnumerable<Subjects> GetSubjects();

        public Subjects GetSubject(int? SubjectCode);

        public int AddSubject(Subjects subject);

        public int UpdateSubject(Subjects subject);

        public int DeleteSubject(int? SubjectCode);
    }
}
