using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class AddPropNameToCategory
  /// </summary>
  public partial class AddPropNameToCategory : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "Name",
          table: "Categories",
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
          name: "Name",
          table: "Categories");
    }
  }
}
