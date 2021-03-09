using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class RefactorSubmission
  /// </summary>
  public partial class RefactorSubmission : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<bool>(
          name: "VideoProcessed",
          table: "Submissions",
          type: "boolean",
          nullable: false,
          defaultValue: false);
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "VideoProcessed",
          table: "Submissions");
    }
  }
}
