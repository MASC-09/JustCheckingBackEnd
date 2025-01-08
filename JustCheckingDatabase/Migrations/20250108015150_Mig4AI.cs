using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JustCheckingDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Mig4AI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayRecords_MacroCards_DailyMacroId",
                table: "DayRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_DayRecords_MealRecords_MealRecordId",
                table: "DayRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Users_UserId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlans_MealRecords_DistributionId",
                table: "UserPlans");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MacroCards",
                table: "MacroCards");

            migrationBuilder.DropIndex(
                name: "IX_DayRecords_DailyMacroId",
                table: "DayRecords");

            migrationBuilder.DropIndex(
                name: "IX_DayRecords_MealRecordId",
                table: "DayRecords");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MacroArray",
                table: "MealRecords");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MealRecords");

            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "MacroCards");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "MacroCards");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "MacroCards");

            migrationBuilder.DropColumn(
                name: "Snack1",
                table: "MacroCards");

            migrationBuilder.DropColumn(
                name: "Snack2",
                table: "MacroCards");

            migrationBuilder.DropColumn(
                name: "Snack3",
                table: "MacroCards");

            migrationBuilder.DropColumn(
                name: "DailyMacroId",
                table: "DayRecords");

            migrationBuilder.DropColumn(
                name: "MealRecordId",
                table: "DayRecords");

            migrationBuilder.RenameTable(
                name: "MacroCards",
                newName: "Macrocards");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "MealRecords",
                newName: "RecordedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserGender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Measurements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MealRecords",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayRecordId",
                table: "MealRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealMacroDistributionsId",
                table: "MealRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Macrocards",
                table: "Macrocards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MacroDistributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealType = table.Column<int>(type: "int", nullable: false),
                    Dairy = table.Column<float>(type: "real", nullable: false),
                    Vegetables = table.Column<float>(type: "real", nullable: false),
                    Fruits = table.Column<float>(type: "real", nullable: false),
                    Carbohydrates = table.Column<float>(type: "real", nullable: false),
                    Protein = table.Column<float>(type: "real", nullable: false),
                    Fats = table.Column<float>(type: "real", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    MacrocardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacroDistributions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MacroDistributions_Macrocards_MacrocardId",
                        column: x => x.MacrocardId,
                        principalTable: "Macrocards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealRecords_DayRecordId",
                table: "MealRecords",
                column: "DayRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MealRecords_MealMacroDistributionsId",
                table: "MealRecords",
                column: "MealMacroDistributionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MacroDistributions_MacrocardId",
                table: "MacroDistributions",
                column: "MacrocardId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealRecords_DayRecords_DayRecordId",
                table: "MealRecords",
                column: "DayRecordId",
                principalTable: "DayRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealRecords_MacroDistributions_MealMacroDistributionsId",
                table: "MealRecords",
                column: "MealMacroDistributionsId",
                principalTable: "MacroDistributions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlans_Macrocards_DistributionId",
                table: "UserPlans",
                column: "DistributionId",
                principalTable: "Macrocards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealRecords_DayRecords_DayRecordId",
                table: "MealRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MealRecords_MacroDistributions_MealMacroDistributionsId",
                table: "MealRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlans_Macrocards_DistributionId",
                table: "UserPlans");

            migrationBuilder.DropTable(
                name: "MacroDistributions");

            migrationBuilder.DropIndex(
                name: "IX_MealRecords_DayRecordId",
                table: "MealRecords");

            migrationBuilder.DropIndex(
                name: "IX_MealRecords_MealMacroDistributionsId",
                table: "MealRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Macrocards",
                table: "Macrocards");

            migrationBuilder.DropColumn(
                name: "UserGender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DayRecordId",
                table: "MealRecords");

            migrationBuilder.DropColumn(
                name: "MealMacroDistributionsId",
                table: "MealRecords");

            migrationBuilder.RenameTable(
                name: "Macrocards",
                newName: "MacroCards");

            migrationBuilder.RenameColumn(
                name: "RecordedAt",
                table: "MealRecords",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Measurements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "MealRecords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MacroArray",
                table: "MealRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MealRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Breakfast",
                table: "MacroCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dinner",
                table: "MacroCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lunch",
                table: "MacroCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Snack1",
                table: "MacroCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Snack2",
                table: "MacroCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Snack3",
                table: "MacroCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DailyMacroId",
                table: "DayRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MealRecordId",
                table: "DayRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MacroCards",
                table: "MacroCards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DayRecords_DailyMacroId",
                table: "DayRecords",
                column: "DailyMacroId");

            migrationBuilder.CreateIndex(
                name: "IX_DayRecords_MealRecordId",
                table: "DayRecords",
                column: "MealRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayRecords_MacroCards_DailyMacroId",
                table: "DayRecords",
                column: "DailyMacroId",
                principalTable: "MacroCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayRecords_MealRecords_MealRecordId",
                table: "DayRecords",
                column: "MealRecordId",
                principalTable: "MealRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Users_UserId",
                table: "Measurements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlans_MealRecords_DistributionId",
                table: "UserPlans",
                column: "DistributionId",
                principalTable: "MealRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
