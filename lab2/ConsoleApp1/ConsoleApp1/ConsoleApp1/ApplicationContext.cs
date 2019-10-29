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
        //public DbSet<Students> Students { get; set; }
        public DbSet<StudentSubject>  StudentSubject { get; set; }
        public DbSet<StudentSubjectRate> StudentSubjectRate { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }

        public DbSet<Student> Student { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSubject>()
                .HasKey(bc => new { bc.StudentId, bc.SubjectId });
            modelBuilder.Entity<StudentSubject>()
                .HasOne(bc => bc.Student)
                .WithMany(b => b.StudentSubject)
                .HasForeignKey(bc => bc.StudentId);
            modelBuilder.Entity<StudentSubject>()
                .HasOne(bc => bc.Subject)
                .WithMany(c => c.StudentSubject)
                .HasForeignKey(bc => bc.SubjectId);
        }

    }
}
