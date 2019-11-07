using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.School
{
    public class StudentModel : PageModel
    {
        private readonly WebApplication1.AppDBContext _context;

        public StudentModel(WebApplication1.AppDBContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}