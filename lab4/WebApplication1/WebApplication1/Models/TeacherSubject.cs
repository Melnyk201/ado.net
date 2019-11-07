﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class TeacherSubject
    {
        [Key]
        public int TeacherSubjectId { get; set; }
        [ForeignKey("TeacherId")]
        public int TeacherId { get; set; }
        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
        public Teachers Teacher{ get; set; }
        public Subject Subject { get; set; }
    }
}