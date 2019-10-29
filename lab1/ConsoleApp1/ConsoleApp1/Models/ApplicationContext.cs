using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    class ApplicationContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentSubject>  StudentSubjects { get; set; }
        public DbSet<StudentSubjectRate> StudentSubjectRates { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
