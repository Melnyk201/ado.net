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
    public class StudentSubjectRateModel : PageModel
    {
        private readonly WebApplication1.AppDBContext _context;

        public StudentSubjectRateModel(WebApplication1.AppDBContext context)
        {
            _context = context;
        }

        public IList<StudentSubjectRate> StudentSubjectRate { get;set; }

        public async Task OnGetAsync()
        {
            StudentSubjectRate = await _context.StudentSubjectRate
                .Include(s => s.Student)
                .Include(s => s.Subject).ToListAsync();
        }
    }
}
