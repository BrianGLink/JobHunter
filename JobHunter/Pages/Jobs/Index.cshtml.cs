using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobHunter.Models;

namespace JobHunter.Pages.Jobs
{
    public class JobsModel : PageModel
    {
        private readonly JobberContext _context;

        public JobsModel(JobberContext context)
        {
            _context = context;
        }

        public List<Job> Jobs { get; set; }

        public async Task OnGetAsync()
        {
            Jobs = await _context.Jobs.ToListAsync();
        }
    }
}
