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

    public DbSet<Difficulty> Difficulties { get; set; }
    #endregion
  }
}
