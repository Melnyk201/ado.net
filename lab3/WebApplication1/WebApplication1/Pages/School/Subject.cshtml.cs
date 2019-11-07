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
    public class SubjectModel : PageModel
    {
        private readonly WebApplication1.AppDBContext _context;

        public SubjectModel(WebApplication1.AppDBContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; }

        public async Task OnGetAsync()
        {
            Subject = await _context.Subjects.ToListAsync();
        }
    }
}
