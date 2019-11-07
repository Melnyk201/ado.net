using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Pages.School
{
    public class StudentSubjectModel : PageModel
    {
        private readonly WebApplication1.AppDBContext _context;

        public StudentSubjectModel(WebApplication1.AppDBContext context)
        {
            _context = context;
        }

        public IList<StudentSubject> StudentSubject { get;set; }

        public async Task OnGetAsync()
        {
            StudentSubject = await _context.StudentSubject
                .Include(s => s.Student)
                .Include(s => s.Subject).ToListAsync();
        }
    }
}
