using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleBlogId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleBlogId",
                table: "Comments",
                column: "ArticleBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articles_ArticleBlogId",
                table: "Comments",
                column: "ArticleBlogId",
                principalTable: "Articles",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articles_ArticleBlogId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ArticleBlogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ArticleBlogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Comments");
        }
    }
}
