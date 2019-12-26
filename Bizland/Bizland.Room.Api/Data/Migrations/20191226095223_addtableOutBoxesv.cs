using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bizland.Room.Api.Data.Migrations
{
    public partial class addtableOutBoxesv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    OccurredOn = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    ProcessedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outboxes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outboxes");
        }
    }
}
