using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobHunter.Models;

[Table("Event")]
public partial class Event
{
    [Key]
    public Guid EventID { get; set; }

    [StringLength(50)]
    public string Description { get; set; }

    public Guid? ContactID { get; set; }

    public Guid? CompanyID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AlertTime { get; set; }

    public Guid? JobID { get; set; }
}
