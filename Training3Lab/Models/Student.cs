using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Training3Lab.Models
{
    public class Student
    {        
        public int Id
        { get; set; }
        [Required]
        public string Name
        { get; set; }
        public string Email
        { get; set; }
        public int CourseId
        { get; set; }

        public string PhotoLocation
        { get; set; }

        public virtual Course Course
        { get; set; }
    }
}
