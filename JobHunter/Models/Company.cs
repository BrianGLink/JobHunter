﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace JobHunter.Models;

[Table("Company")]
public partial class Company
{
    [Key]
    public Guid CompanyID { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    [StringLength(50)]
    public string? Location { get; set; }

    // Reverse navigation
    public ICollection<Job> Jobs { get; set; }
}
