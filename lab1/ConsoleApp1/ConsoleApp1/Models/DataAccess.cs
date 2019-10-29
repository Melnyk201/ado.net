using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp1.Models
{
    public class DataAccess
    {
        public void PrintStudents()
        {
            Students students = new Students();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlExpression = "SELECT * FROM Students";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Iнфа про студентiв\n");
            Console.ResetColor();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Console.WriteLine("\t{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}\t{reader.GetName(6)}");
                    Console.ResetColor();
                    while (reader.Read())
                    {

                        students.Id = (int)reader.GetValue(0);
                        students.FirstName = (string)reader.GetValue(1);
                        students.SecondName = (string)reader.GetValue(2);
                        students.MiddleName = (string)reader.GetValue(3);
                        students.Address = (string)reader.GetValue(4);
                        students.PhoneNumb = (int)reader.GetValue(5);
                        students.DateBirth = (DateTime)reader.GetValue(6);
                        Console.WriteLine($"{students.Id}  {students.FirstName}  {students.SecondName}  {students.MiddleName}\t{students.Address}\t{students.PhoneNumb}\t{students.DateBirth}");
                    }
                }
                reader.Close();
            }
        }
        public void PrintTeachers()
        {
            Teachers teachers = new Teachers();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlExpression = "SELECT * FROM Teachers";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Iнфа про викладачів\n");
            Console.ResetColor();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                { 
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}");
                    Console.ResetColor();
                    while (reader.Read())
                    {

                        teachers.Id = (int)reader.GetValue(0);
                        teachers.FirstName = (string)reader.GetValue(1);
                        teachers.LastName = (string)reader.GetValue(2);
                        teachers.MiddleName = (string)reader.GetValue(3);
                        Console.WriteLine($"{teachers.Id}\t{teachers.FirstName}\t{teachers.LastName}\t{teachers.MiddleName}");
                    }
                }
                reader.Close();
            }
        }
        public void PrintSubjects()
        {
            Subjects subjects = new Subjects();
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var sqlExpression = "SELECT * FROM Subjects";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Iнфа про предмети\n");
            Console.ResetColor();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t\t\t\t{reader.GetName(2)}");
                    Console.ResetColor();
                    while (reader.Read())
                    {

                        subjects.Id = (int)reader.GetValue(0);
                        subjects.Name = (string)reader.GetValue(1);
                        subjects.MaxRate = (int)reader.GetValue(2);
                       
                        Console.WriteLine($"{subjects.Id}\t{subjects.Name}\t\t{subjects.MaxRate}");
                    }
                }
                reader.Close();
            }
        }
        public void PrintInfoAboutSгccess()
        {
            Students students = new Students();
            Subjects subjects = new Subjects();
            StudentSubjectRate studentSubjectRate = new StudentSubjectRate();

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //var sqlExpression = "SELECT * FROM StudentSubjectRate";
            var sqlExpression = "SELECT FirstName, SecondName, MiddleName, Name, Rate, Month FROM Students, Subjects, StudentSubjectRate WHERE Students.id = StudentId AND Subjects.id = SubjectId";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Iнфа про успішність\n");
            Console.ResetColor();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sqlExpression, connection);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}\t{reader.GetName(3)}\t{reader.GetName(4)}\t{reader.GetName(5)}");
                    Console.ResetColor();
                    while (reader.Read())
                    {

                        students.FirstName = (string)reader.GetValue(0);
                        students.SecondName = (string)reader.GetValue(1);
                        students.MiddleName = (string)reader.GetValue(2);
                        subjects.Name = (string)reader.GetValue(3);
                        studentSubjectRate.Rate = (int)reader.GetValue(4);
                        studentSubjectRate.Month = (int)reader.GetValue(5);

                        Console.WriteLine($"{students.FirstName}\t{ students.SecondName}\t{students.MiddleName}\t{subjects.Name}\t{studentSubjectRate.Rate}\t{studentSubjectRate.Month}");
                      
                        
                    }
                }
                reader.Close();
            }
        }
    }
}
