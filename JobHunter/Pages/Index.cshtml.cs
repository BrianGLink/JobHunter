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
    public class IndexModel : PageModel
    {
        private readonly JobHunter.Models.JobberContext _context;

        public IndexModel(JobHunter.Models.JobberContext context) => _context = context;

        public IList<Job> Jobs { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    Jobs = await _context.Jobs.ToListAsync();
            //}
            //else
            //{
            Jobs = new List<Job>
        {
            new Job { PositionTitle = "Software Developer", PostedDate= DateOnly.FromDateTime( DateTime.Now.AddDays(-3)) },
            new Job { PositionTitle = "QA Tester", PostedDate= DateOnly.FromDateTime( DateTime.Now.AddDays(-3)) },
            new Job { PositionTitle = "UI/UX Designer", PostedDate = DateOnly.FromDateTime( DateTime.Now.AddDays(-3))  }
        };
        }

    }
}
