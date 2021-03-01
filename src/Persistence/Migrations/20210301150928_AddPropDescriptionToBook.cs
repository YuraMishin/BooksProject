using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class AddPropDescriptionToBook
  /// </summary>
  public partial class AddPropDescriptionToBook : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "Description",
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
          name: "Description",
          table: "Books");
    }
  }
}
