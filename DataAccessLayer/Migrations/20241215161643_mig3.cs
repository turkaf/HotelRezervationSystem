using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Cities_CityID",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_CityID",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CityID",
                table: "Rooms",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Cities_CityID",
                table: "Rooms",
                column: "CityID",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
