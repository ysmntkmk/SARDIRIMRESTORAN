using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierSardırımRes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ysmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerSurname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CustomerSurname",
                table: "AspNetUsers");
        }
    }
}
