using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobHunter.Models;

[Table("Contact")]
public partial class Contact
{
    [Key]
    public Guid ContactID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(50)]
    public string Email { get; set; }

    public Guid? CompanyID { get; set; }

    [Column(TypeName = "ntext")]
    public string Notes { get; set; }
}
