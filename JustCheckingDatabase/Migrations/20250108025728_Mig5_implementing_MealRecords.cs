using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCheckingDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Mig5_implementing_MealRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlans_Macrocards_DistributionId",
                table: "UserPlans");

            migrationBuilder.RenameColumn(
                name: "DistributionId",
                table: "UserPlans",
                newName: "MacroCardId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPlans_DistributionId",
                table: "UserPlans",
                newName: "IX_UserPlans_MacroCardId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Macrocards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlans_Macrocards_MacroCardId",
                table: "UserPlans",
                column: "MacroCardId",
                principalTable: "Macrocards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPlans_Macrocards_MacroCardId",
                table: "UserPlans");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserPlans");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Macrocards");

            migrationBuilder.RenameColumn(
                name: "MacroCardId",
                table: "UserPlans",
                newName: "DistributionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPlans_MacroCardId",
                table: "UserPlans",
                newName: "IX_UserPlans_DistributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlans_Macrocards_DistributionId",
                table: "UserPlans",
                column: "DistributionId",
                principalTable: "Macrocards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
