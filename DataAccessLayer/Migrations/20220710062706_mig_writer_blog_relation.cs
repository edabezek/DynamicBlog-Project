using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_writer_blog_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterId",
                table: "Articles",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_WriterId",
                table: "Articles",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Writers_WriterId",
                table: "Articles",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "WriterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Writers_WriterId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_WriterId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Articles");
        }
    }
}
