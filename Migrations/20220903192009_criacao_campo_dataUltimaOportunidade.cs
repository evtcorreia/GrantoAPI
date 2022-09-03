using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Granto.Migrations
{
    public partial class criacao_campo_dataUltimaOportunidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dataUltimaOprtunidade",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataUltimaOprtunidade",
                table: "Users");
        }
    }
}
