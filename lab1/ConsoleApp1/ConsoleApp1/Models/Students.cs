using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public int PhoneNumb { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
