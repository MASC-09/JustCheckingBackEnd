using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCheckingDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealRecordId",
                table: "DayRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "DayRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "User_History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_History_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayRecords_MealRecordId",
                table: "DayRecords",
                column: "MealRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_User_History_UserId",
                table: "User_History",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayRecords_MealRecords_MealRecordId",
                table: "DayRecords",
                column: "MealRecordId",
                principalTable: "MealRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayRecords_MealRecords_MealRecordId",
                table: "DayRecords");

            migrationBuilder.DropTable(
                name: "User_History");

            migrationBuilder.DropIndex(
                name: "IX_DayRecords_MealRecordId",
                table: "DayRecords");

            migrationBuilder.DropColumn(
                name: "MealRecordId",
                table: "DayRecords");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "DayRecords");
        }
    }
}
