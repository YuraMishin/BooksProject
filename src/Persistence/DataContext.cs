using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  /// <summary>
  /// Class DataContext.
  /// Implements DbContext
  /// </summary>
  public class DataContext : DbContext
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options">options</param>
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    #region DB Tables
    /// <summary>
    /// Books
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Submissions
    /// </summary>
    public DbSet<Submission> Submissions { get; set; }

    /// <summary>
    /// Difficulties
    /// </summary>
    public DbSet<Difficulty> Difficulties { get; set; }

    /// <summary>
    /// BookRelationships
    /// </summary>
    public DbSet<BookRelationship> BookRelationships { get; set; }

    /// <summary>
    /// Categories
    /// </summary>
    public DbSet<Category> Categories { get; set; }
    #endregion

    /// <summary>
    /// Method finetunes DbContext via Fluent API
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<BookRelationship>()
        .HasKey(x => new { x.PrerequisiteId, x.ProgressionId });

      modelBuilder.Entity<BookRelationship>()
        .HasOne(x => x.Progression)
        .WithMany(x => x.Prerequisites)
        .HasForeignKey(x => x.ProgressionId);

      modelBuilder.Entity<BookRelationship>()
        .HasOne(x => x.Prerequisite)
        .WithMany(x => x.Progressions)
        .HasForeignKey(x => x.PrerequisiteId);
    }
  }
}
