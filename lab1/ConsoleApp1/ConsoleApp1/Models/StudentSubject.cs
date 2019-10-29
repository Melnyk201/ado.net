using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class StudentSubject
    {
        [Key]
        public int SrudentId { get; set; }
        public int SubjectId { get; set; }
        

    }
}
