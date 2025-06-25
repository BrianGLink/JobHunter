using JobHunter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobHunter.Pages.Jobs
{
    public class DeleteModel : PageModel
    {
        private readonly JobHunter.Models.JobberContext _context;

        public DeleteModel(JobHunter.Models.JobberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Job = await _context.Jobs.FindAsync(id);

            if (Job == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var job = await _context.Jobs.FindAsync(Job.JobID);
            if (job != null)
            {
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

    }
}
