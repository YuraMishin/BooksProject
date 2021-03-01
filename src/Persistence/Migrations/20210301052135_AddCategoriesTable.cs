using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// AddCategoriesTable
  /// </summary>
  public partial class AddCategoriesTable : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Categories",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Description = table.Column<string>(type: "text", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Categories", x => x.Id);
          });
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Categories");
    }
  }
}
