using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class AddVideoPropToBook.
  /// Adds Video Prop to Book entity
  /// </summary>
  public partial class AddVideoPropToBook : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "Video",
          table: "Books",
          type: "text",
          nullable: true);
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Video",
          table: "Books");
    }
  }
}
