using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class AddCommentsTable
  /// </summary>
  public partial class AddCommentsTable : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Comments",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            Content = table.Column<string>(type: "text", nullable: true),
            HtmlContent = table.Column<string>(type: "text", nullable: true),
            ModerationItemId = table.Column<Guid>(type: "uuid", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Comments", x => x.Id);
            table.ForeignKey(
                      name: "FK_Comments_ModerationItems_ModerationItemId",
                      column: x => x.ModerationItemId,
                      principalTable: "ModerationItems",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Comments_ModerationItemId",
          table: "Comments",
          column: "ModerationItemId");
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Comments");
    }
  }
}
