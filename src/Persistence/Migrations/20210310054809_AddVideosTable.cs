using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
  /// <summary>
  /// Class AddVideosTable
  /// </summary>
  public partial class AddVideosTable : Migration
  {
    /// <summary>
    /// Method performs the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Video",
          table: "Submissions");

      migrationBuilder.AddColumn<Guid>(
          name: "VideoId",
          table: "Submissions",
          type: "uuid",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.CreateTable(
          name: "Videos",
          columns: table => new
          {
            Id = table.Column<Guid>(type: "uuid", nullable: false),
            VideoLink = table.Column<string>(type: "text", nullable: true),
            ThumbLink = table.Column<string>(type: "text", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Videos", x => x.Id);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Submissions_VideoId",
          table: "Submissions",
          column: "VideoId");

      migrationBuilder.AddForeignKey(
          name: "FK_Submissions_Videos_VideoId",
          table: "Submissions",
          column: "VideoId",
          principalTable: "Videos",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    /// <summary>
    /// Method rollbacks the migration
    /// </summary>
    /// <param name="migrationBuilder">migrationBuilder</param>
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Submissions_Videos_VideoId",
          table: "Submissions");

      migrationBuilder.DropTable(
          name: "Videos");

      migrationBuilder.DropIndex(
          name: "IX_Submissions_VideoId",
          table: "Submissions");

      migrationBuilder.DropColumn(
          name: "VideoId",
          table: "Submissions");

      migrationBuilder.AddColumn<string>(
          name: "Video",
          table: "Submissions",
          type: "text",
          nullable: true);
    }
  }
}
