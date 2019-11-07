using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace ConsoleApp1.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            var data = new DataAccess();
            data.PrintStudents();
            data.PrintSubjects();
            data.PrintTeachers();
            data.PrintInfoAboutSгccess();
            Console.Read();
        }
    }
}
