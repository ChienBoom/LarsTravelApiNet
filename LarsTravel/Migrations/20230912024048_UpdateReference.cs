using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsTravel.Migrations
{
    public partial class UpdateReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tour_EvaluateId",
                table: "tour");

            migrationBuilder.DropIndex(
                name: "IX_comment_EvaluateId",
                table: "comment");

            migrationBuilder.CreateIndex(
                name: "IX_tour_EvaluateId",
                table: "tour",
                column: "EvaluateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comment_EvaluateId",
                table: "comment",
                column: "EvaluateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tour_EvaluateId",
                table: "tour");

            migrationBuilder.DropIndex(
                name: "IX_comment_EvaluateId",
                table: "comment");

            migrationBuilder.CreateIndex(
                name: "IX_tour_EvaluateId",
                table: "tour",
                column: "EvaluateId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_EvaluateId",
                table: "comment",
                column: "EvaluateId");
        }
    }
}
