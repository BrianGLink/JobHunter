using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobHunter.Models;

[Table("Job")]
public partial class Job
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

    public Guid? CompanyID { get; set; }
    public Company Company { get; set; }    

    public Guid? ContactID { get; set; }
    public Contact Contact { get; set; }
}
