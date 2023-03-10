using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace URLShortener.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortedString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UrlInfo",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "OriginalString", "ShortedString", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1058), "PZPBUA IPOFQS", "https://mail.google.com/mail/u/0/?pli=1#inbox", "WR0kDa", new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1058) },
                    { 2, new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1228), "UDOGWD NLAWVF", "https://calendar.google.com/calendar/u/0/r", "8enV2d", new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1228) },
                    { 3, new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1245), "SIHFPW QYUWKY", "https://github.com/Maximiliyano?tab=repositories", "LaGYOb", new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1245) },
                    { 4, new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1257), "YYXXUA YLWJEI", "https://learnenglish.britishcouncil.org/", "jHaWHe", new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1257) },
                    { 5, new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1292), "UFCHOQ IPFVUV", "https://www.youtube.com/", "vFrUTd", new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1292) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "gkypnfp@gmail.com", "FirstYEAB SurDGJP", "XKEXHZ8", 0 },
                    { 2, "talgfne@gmail.com", "FirstVOYL SurREBK", "LISTAS61", 0 },
                    { 3, "qyijlfl@gmail.com", "FirstXCWK SurPUIJ", "TDAKRQ92", 0 },
                    { 4, "odptzew@gmail.com", "FirstBGPI SurHYDU", "RZSZWL70", 0 },
                    { 5, "pdnjhgv@gmail.com", "FirstNMZH SurACYI", "DEDDQV70", 0 },
                    { 6, "vqrocnl@gmail.com", "FirstUILR SurXOHI", "YVXKHW95", 0 },
                    { 7, "kpwiwsb@gmail.com", "FirstOYVZ SurKEVQ", "LKMVWP94", 0 },
                    { 8, "naaptqo@gmail.com", "FirstNYJJ SurWXDQ", "GJAQNN94", 0 },
                    { 9, "rtxvyci@gmail.com", "FirstGSYE SurWPHU", "URJKUW83", 0 },
                    { 10, "xcaacpa@gmail.com", "FirstNBBU SurXOSN", "CWPLAI41", 0 },
                    { 11, "rabonil@gmail.com", "FirstBOUU SurDJTG", "YLYRNQ53", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlInfo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
