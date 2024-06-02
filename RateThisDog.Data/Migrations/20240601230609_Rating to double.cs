using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateThisDog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ratingtodouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Dogs_DogID",
                table: "UserRatings");

            migrationBuilder.AlterColumn<int>(
                name: "DogID",
                table: "UserRatings",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Dogs_DogID",
                table: "UserRatings",
                column: "DogID",
                principalTable: "Dogs",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRatings_Dogs_DogID",
                table: "UserRatings");

            migrationBuilder.AlterColumn<int>(
                name: "DogID",
                table: "UserRatings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRatings_Dogs_DogID",
                table: "UserRatings",
                column: "DogID",
                principalTable: "Dogs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
