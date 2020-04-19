using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class Teachers
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subjects { get; set; }
        [Required]
        public DateTime AddedOn { get; set; }

        
    }
}
