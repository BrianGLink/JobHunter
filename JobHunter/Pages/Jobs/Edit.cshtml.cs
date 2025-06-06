using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobHunter.Models;
using JobHunter.ViewModels;

namespace JobHunter.Pages.Jobs
{
    public class EditModel : PageModel
    {
        private readonly JobHunter.Models.JobberContext _context;
        public EditJobViewModel ViewModel { get; set; }

        public EditModel(JobHunter.Models.JobberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            var companies = await _context.Companies.ToListAsync();

            ViewModel = new EditJobViewModel
            {
                Job = job,
                CompanyOptions = new SelectList(companies, "CompanyID", "Name")
            };

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Partial("_EditJobPartial", ViewModel);
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(Job.JobID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobExists(Guid id)
        {
            return _context.Jobs.Any(e => e.JobID == id);
        }


      
    }
}
