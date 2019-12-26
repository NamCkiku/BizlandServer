using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bizland.Room.Api.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    RoomName = table.Column<string>(maxLength: 256, nullable: false),
                    Alias = table.Column<string>(maxLength: 256, nullable: false),
                    RoomCategoryID = table.Column<int>(nullable: false),
                    WardID = table.Column<int>(nullable: true),
                    DistrictID = table.Column<int>(nullable: true),
                    ProvinceID = table.Column<int>(nullable: false),
                    VipID = table.Column<int>(nullable: true),
                    MoreInfomationID = table.Column<int>(nullable: true),
                    PaymentID = table.Column<int>(nullable: true),
                    ThumbnailImage = table.Column<string>(maxLength: 256, nullable: false),
                    MoreImages = table.Column<string>(type: "xml", nullable: true),
                    Acreage = table.Column<double>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 256, nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    Lat = table.Column<double>(nullable: true),
                    Lng = table.Column<double>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    RoomStar = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
