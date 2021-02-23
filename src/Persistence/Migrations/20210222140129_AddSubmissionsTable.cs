using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  public partial class AddSubmissionsTable : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
           name: "Submissions",
           columns: table => new
           {
             Id = table.Column<Guid>(type: "uuid", nullable: false),
             BookId = table.Column<Guid>(type: "uuid", nullable: false),
             Video = table.Column<string>(type: "text", nullable: true),
             Description = table.Column<string>(type: "text", nullable: true)
           },
           constraints: table =>
           {
             table.PrimaryKey("PK_Submissions", x => x.Id);
           });
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Submissions");
    }
  }
}
