using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iTechArt.Database.Migrations
{
    public partial class studentFaculty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Faculty",
                table: "Students",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Students");
        }
    }
}
