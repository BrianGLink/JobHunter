using JobHunter.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobHunter.ViewModels
{
    public class EditJobViewModel
    {
        public Job Job { get; set; }

        public SelectList CompanyOptions { get; set; }
    }
}
