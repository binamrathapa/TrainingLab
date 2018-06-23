using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Training3Lab.Models
{
    [NotMapped]
    public class StudentCourse
    {
        public string CourseName
        { get; set; }

        public string StudentName
        { get; set; }

        
        public int Marks
        { get; set; }
    }
}
