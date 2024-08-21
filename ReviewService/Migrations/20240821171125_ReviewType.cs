using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewService.Migrations
{
    /// <inheritdoc />
    public partial class ReviewType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "Reviews",
                newName: "RevieweeId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "RevieweeId",
                table: "Reviews",
                newName: "PropertyId");
        }
    }
}
