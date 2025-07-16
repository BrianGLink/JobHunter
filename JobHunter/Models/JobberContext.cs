using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobHunter.Models;

public partial class JobberContext : DbContext
{
    public JobberContext(DbContextOptions<JobberContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.Property(e => e.CompanyID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.Property(e => e.ContactID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.EventID).ValueGeneratedNever();
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.Property(e => e.JobID).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
