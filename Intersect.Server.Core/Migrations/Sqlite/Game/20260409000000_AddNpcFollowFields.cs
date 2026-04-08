using Microsoft.EntityFrameworkCore.Migrations;

namespace Intersect.Server.Migrations.Sqlite.Game
{
    public partial class AddNpcFollowFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Followable",
                table: "Npcs",
                nullable: false,
                defaultValue: false
            );

            migrationBuilder.AddColumn<int>(
                name: "FollowTeleportRange",
                table: "Npcs",
                nullable: false,
                defaultValue: 10
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Followable",
                table: "Npcs"
            );

            migrationBuilder.DropColumn(
                name: "FollowTeleportRange",
                table: "Npcs"
            );
        }
    }
}