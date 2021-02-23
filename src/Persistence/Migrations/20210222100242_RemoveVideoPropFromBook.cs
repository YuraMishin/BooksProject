using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  public partial class RemoveVideoPropFromBook : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Video",
          table: "Books");
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
          name: "Video",
          table: "Books",
          type: "text",
          nullable: true);
    }
  }
}
