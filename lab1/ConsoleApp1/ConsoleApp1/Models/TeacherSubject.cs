using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class TeacherSubject
    {
        [Key]
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }
    }
}
