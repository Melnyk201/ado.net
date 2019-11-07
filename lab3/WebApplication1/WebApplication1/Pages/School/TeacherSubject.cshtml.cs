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
    public class TeacherSubjectModel : PageModel
    {
        private readonly WebApplication1.AppDBContext _context;

        public TeacherSubjectModel(WebApplication1.AppDBContext context)
        {
            _context = context;
        }

        public IList<TeacherSubject> TeacherSubject { get;set; }

        public async Task OnGetAsync()
        {
            TeacherSubject = await _context.TeacherSubjects
                .Include(t => t.Subject)
                .Include(t => t.Teacher).ToListAsync();
        }
    }
}
