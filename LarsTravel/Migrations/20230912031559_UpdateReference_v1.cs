using Microsoft.EntityFrameworkCore.Migrations;

namespace LarsTravel.Migrations
{
    public partial class UpdateReference_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ticket_detail_HotelId",
                table: "ticket_detail");

            migrationBuilder.DropIndex(
                name: "IX_ticket_detail_MemberPackageId",
                table: "ticket_detail");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_detail_HotelId",
                table: "ticket_detail",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_detail_MemberPackageId",
                table: "ticket_detail",
                column: "MemberPackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ticket_detail_HotelId",
                table: "ticket_detail");

            migrationBuilder.DropIndex(
                name: "IX_ticket_detail_MemberPackageId",
                table: "ticket_detail");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_detail_HotelId",
                table: "ticket_detail",
                column: "HotelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_detail_MemberPackageId",
                table: "ticket_detail",
                column: "MemberPackageId",
                unique: true);
        }
    }
}
