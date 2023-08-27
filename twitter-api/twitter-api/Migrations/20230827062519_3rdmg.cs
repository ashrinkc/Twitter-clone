using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace twitter_api.Migrations
{
    public partial class _3rdmg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Comments_CommentId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Posts_PostId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "postOrcommentId",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Quotes",
                newName: "postId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Quotes",
                newName: "commentId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_PostId",
                table: "Quotes",
                newName: "IX_Quotes_postId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_CommentId",
                table: "Quotes",
                newName: "IX_Quotes_commentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Comments_commentId",
                table: "Quotes",
                column: "commentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Posts_postId",
                table: "Quotes",
                column: "postId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Comments_commentId",
                table: "Quotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Posts_postId",
                table: "Quotes");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Quotes",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "commentId",
                table: "Quotes",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_postId",
                table: "Quotes",
                newName: "IX_Quotes_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Quotes_commentId",
                table: "Quotes",
                newName: "IX_Quotes_CommentId");

            migrationBuilder.AddColumn<int>(
                name: "postOrcommentId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Comments_CommentId",
                table: "Quotes",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Posts_PostId",
                table: "Quotes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
