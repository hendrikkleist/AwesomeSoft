using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeSoft.DataAccess.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddingMultipleRoomSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingRoomId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MeetingRoomId",
                table: "Bookings",
                column: "MeetingRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MeetingRooms_MeetingRoomId",
                table: "Bookings",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MeetingRooms_MeetingRoomId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MeetingRoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "MeetingRoomId",
                table: "Bookings");
        }
    }
}
