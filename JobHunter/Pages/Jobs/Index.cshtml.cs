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
        private readonly JobHunter.Models.JobberContext _context;

        public JobsModel(JobHunter.Models.JobberContext context)
        {
            _context = context;
        }

        public IList<Job> Job { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Job = await _context.Jobs.ToListAsync();
        }
    }
}
