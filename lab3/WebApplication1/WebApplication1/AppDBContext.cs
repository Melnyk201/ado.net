using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
           
        }
        public DbSet<StudentSubject> StudentSubject { get; set; }
        public DbSet<StudentSubjectRate> StudentSubjectRate { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Student> Student { get; set; }

    }
}
