using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginManagement.Entities.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserRole",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");
        }
    }
}
