using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practical23_API.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Employees",
                newName: "Isdeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "Employees",
                newName: "Status");
        }
    }
}
