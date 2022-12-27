using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebEngage.Models;

public partial class WebEngageContext : DbContext
{
    public WebEngageContext()
    {
    }

    public WebEngageContext(DbContextOptions<WebEngageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LINHNGUYEN;Database=WebEngage;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.Property(e => e.AppCode).HasMaxLength(150);
            entity.Property(e => e.AppName).HasMaxLength(250);
            entity.Property(e => e.License).HasMaxLength(150);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.AnonymousId).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EventName).HasMaxLength(250);
            entity.Property(e => e.EventTime).HasMaxLength(150);
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.AnonymousId).HasMaxLength(50);
            entity.Property(e => e.BirthDate).HasMaxLength(50);
            entity.Property(e => e.Company).HasMaxLength(150);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.HashedEmail).HasMaxLength(150);
            entity.Property(e => e.HashedPhone).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);
            entity.Property(e => e.WhatsappOptIn).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
