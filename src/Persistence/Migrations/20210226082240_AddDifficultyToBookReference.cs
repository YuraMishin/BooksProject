﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddDifficultyToBookReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DifficultyId",
                table: "Books",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_DifficultyId",
                table: "Books",
                column: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Difficulties_DifficultyId",
                table: "Books",
                column: "DifficultyId",
                principalTable: "Difficulties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Difficulties_DifficultyId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_DifficultyId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Books");
        }
    }
}
