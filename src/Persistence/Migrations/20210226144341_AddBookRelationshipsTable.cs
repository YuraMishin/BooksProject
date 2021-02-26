using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class AddBookRelationshipsTable
  /// </summary>
  public partial class AddBookRelationshipsTable : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "BookRelationships",
          columns: table => new
          {
            PrerequisiteId = table.Column<Guid>(type: "uuid", nullable: false),
            ProgressionId = table.Column<Guid>(type: "uuid", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_BookRelationships", x => new { x.PrerequisiteId, x.ProgressionId });
            table.ForeignKey(
                      name: "FK_BookRelationships_Books_PrerequisiteId",
                      column: x => x.PrerequisiteId,
                      principalTable: "Books",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_BookRelationships_Books_ProgressionId",
                      column: x => x.ProgressionId,
                      principalTable: "Books",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_BookRelationships_ProgressionId",
          table: "BookRelationships",
          column: "ProgressionId");
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "BookRelationships");
    }
  }
}
