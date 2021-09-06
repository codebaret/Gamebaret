using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Games.Data.Access.Migrations
{
    public partial class GameUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameIndexFiles_GameIndexFileId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameIndexFiles");

            migrationBuilder.DropIndex(
                name: "IX_Games_GameIndexFileId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameIndexFileId",
                table: "Games");

            migrationBuilder.AddColumn<byte[]>(
                name: "GameIndexFile",
                table: "Games",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameIndexFile",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameIndexFileId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GameIndexFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameIndexFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameIndexFileId",
                table: "Games",
                column: "GameIndexFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameIndexFiles_GameIndexFileId",
                table: "Games",
                column: "GameIndexFileId",
                principalTable: "GameIndexFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
