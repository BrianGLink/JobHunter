using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobHunter.Models;

[Keyless]
public partial class vw_JobListing
{
 [Key]
    public Guid JobID { get; set; }

    [Required]
    [StringLength(50)]
    public string PositionTitle { get; set; }

    [Required]
    [Column(TypeName = "ntext")]
    public string Requirements { get; set; }

    public DateOnly? PostedDate { get; set; }

    public DateOnly? AppliedDate { get; set; }

    [StringLength(50)]
    public string CompanyName { get; set; }

    [StringLength(50)]
    public string Location { get; set; }
}
