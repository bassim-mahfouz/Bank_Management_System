using Microsoft.EntityFrameworkCore.Migrations;

namespace Bank_Management_System.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "PaidAmount",
                table: "Loans",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Loans");
        }
    }
}
