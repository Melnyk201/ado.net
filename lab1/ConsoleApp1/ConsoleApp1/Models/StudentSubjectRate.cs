﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    class StudentSubjectRate
    {
        [Key]
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Rate { get; set; }
        public int Month { get; set; }

    }
}
