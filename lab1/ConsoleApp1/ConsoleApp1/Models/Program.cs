using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;


            using (ApplicationContext db = new ApplicationContext())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Iнфа про студентiв\n");
                var students = db.Students.ToList();
                
                //Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (Students student in students)
                {
                    Console.WriteLine($"{student.Id}  {student.FirstName}  {student.SecondName}  {student.MiddleName}\t{student.Address}\t{student.PhoneNumb}\t{student.DateBirth}");
                }
                //Console.ResetColor();
            }
            Console.Read();
        }
    }
}
