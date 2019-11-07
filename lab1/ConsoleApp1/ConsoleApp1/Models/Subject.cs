using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get;  set; }
        public int MaxRate { get; set; }
        public ICollection<StudentSubject> StudentSubject { get; set; }
        public ICollection<TeacherSubject> TeacherSubject { get; set; }


    }
}
