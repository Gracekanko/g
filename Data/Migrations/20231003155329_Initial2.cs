using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GogoDriverWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Reservtions_ReservationId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ReservationId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ReservationId",
                table: "Courses",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Reservtions_ReservationId",
                table: "Courses",
                column: "ReservationId",
                principalTable: "Reservtions",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
