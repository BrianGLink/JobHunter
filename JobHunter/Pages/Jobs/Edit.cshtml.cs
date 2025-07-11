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

        public EditModel(JobHunter.Models.JobberContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Job? Job { get; set; } = default!;

        [BindProperty]
        public string NewCompanyName { get; set; }

        [BindProperty]
        public string NewContactName { get; set; }

        public List<SelectListItem> CompanyOptions { get; set; }
        public List<SelectListItem> ContactOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            CompanyOptions = await _context.Companies
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem { Value = c.CompanyID.ToString(), Text = c.Name })
                .ToListAsync();

            ContactOptions = await _context.Contacts
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem { Value = c.ContactID.ToString(), Text = c.Name })
                .ToListAsync();

            if (id == null)
            {
                Job = new Job();
            }
            else
            {
                Job = await _context.Jobs
                    .Include(j => j.Company)
                    .Include(j => j.Contact)
                    .FirstOrDefaultAsync(j => j.JobID == id.Value);
                if (Job == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Job == null)
            {
                throw new Exception("Job is null on post");
            }

            // Handle Company
            if (!string.IsNullOrWhiteSpace(NewCompanyName))
            {
                var existingCompany = await _context.Companies
                    .FirstOrDefaultAsync(c => c.Name == NewCompanyName);

                if (existingCompany != null)
                {
                    // Use the existing company
                    Job.CompanyID = existingCompany.CompanyID;
                }
                else
                {
                    var company = new Company
                    {
                        CompanyID = Guid.NewGuid(),
                        Name = NewCompanyName
                    };

                    _context.Companies.Add(company);
                    Job.CompanyID = company.CompanyID;
                }
            }

            // Handle Contact
            if (!string.IsNullOrWhiteSpace(NewContactName))
            {
                // Check if a contact with this name already exists
                var existingContact = await _context.Contacts
                    .FirstOrDefaultAsync(c => c.Name == NewContactName);

                if (existingContact != null)
                {
                    // Use the existing contact
                    Job.ContactID = existingContact.ContactID;
                }
                else
                {
                    // Add a new contact
                    var contact = new Contact
                    {
                        ContactID = Guid.NewGuid(),
                        Name = NewContactName
                    };

                    _context.Contacts.Add(contact);
                    Job.ContactID = contact.ContactID;
                }
            }

            if (Job.JobID == Guid.Empty)
            {
                Job.JobID = Guid.NewGuid();
                _context.Jobs.Add(Job);
            }
            else
            {
                _context.Attach(Job).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("../Index");
        }

    }
}
