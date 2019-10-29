using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleApp1.Models
{
    class Program : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            DbContextOptionsBuilder<ApplicationContext> optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString);
            return new ApplicationContext(optionsBuilder.Options);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Program p = new Program();

            using (ApplicationContext sc = p.CreateDbContext(null))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Iнфа про студентiв\n");
                var students = sc.Student.ToList();
                Console.ResetColor();
                foreach (var student in students)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{student.StudentId}  {student.FirstName}  {student.SecondName}  {student.MiddleName}\t{student.Address}\t{student.PhoneNumb}\t{student.DateBirth}");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Iнфа про викладачів\n");
                var teachers = sc.Teachers.ToList();
                Console.ResetColor();
                foreach (Teachers teacher in teachers)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{teacher.Id}\t{teacher.FirstName}\t{teacher.LastName}\t{teacher.MiddleName}");
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Iнфа про предмети\n");
                var subjects = sc.Subjects.ToList();
                Console.ResetColor();
                foreach (Subject subject in subjects)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{subject.SubjectId}\t{subject.Name}\t\t{subject.MaxRate}");

                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Iнфа про успішність\n");


                var allStudents = sc.Student.ToList();
                var allSuccess = sc.StudentSubjectRate.ToList();
                var cs = sc.StudentSubjectRate.Include(x => x.Subject).Include(x => x.Student).ToList();
                foreach (var student in allStudents)
                {

                    Console.WriteLine($"Student name : {student.FirstName}, surname: {student.SecondName}");
                    foreach (var item in cs.Where(c => c.StudentId == student.StudentId))
                    {
                        Console.WriteLine($"Subject : {item.Subject.Name}, Rate : {item.Rate}, Month : {item.Month}");
                    }
                }
                


               Console.ReadKey();

            }
           
            
            Console.Read();
        }
    }
}
