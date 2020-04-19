using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class Subjects
    {
        [Required]
        public int SubjectCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Teacher { get; set; }

        
    }
}
