using FlashCardService.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardService.DbContexts;

public partial class FlashCardDbContext : DbContext
{
    public FlashCardDbContext(DbContextOptions<FlashCardDbContext> options)
        : base(options)
    {
    }

    public DbSet<FlashCard> FlashCards { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FlashCard>(entity =>
        {
            entity.Property(e => e.FrontOfFlashCard).HasMaxLength(1000);
            entity.Property(e => e.BackOfFlashCard).HasMaxLength(1000);
            entity.Property(e => e.Category).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}