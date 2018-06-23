using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training3Lab.Models;

namespace Training3Lab.Models
{
    public class Training3LabContext : DbContext
    {
        public Training3LabContext (DbContextOptions<Training3LabContext> options)
            : base(options)
        {
        }

        public DbSet<Training3Lab.Models.Course> Course { get; set; }

        public DbSet<Training3Lab.Models.Student> Student { get; set; }
    }
}
