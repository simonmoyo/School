using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class Students
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(7, 7)]
        public string Subjects { get; set; }
        [Required]
        public int ClassID { get; set; }
        [Required]
        public DateTime AddedOn { get; set; }

    }
}
