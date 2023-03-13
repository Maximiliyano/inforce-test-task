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
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

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
                table: "Abouts",
                columns: new[] { "Id", "CreatedAt", "Text", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9190), "An URL shortening algorithm in ASP.NET MVC Core typically involves generating\"a shorter unique identifier for a given URL and storing it in a database. \"When a user accesses the shortened URL, the application retrieves the original URL from the database \"and redirects the user to the original URL.", new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9190) });

            migrationBuilder.InsertData(
                table: "UrlInfo",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "OriginalString", "ShortedString", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(8907), "FNBPNM QWWNUW", "https://mail.google.com/mail/u/0/?pli=1#inbox", "WR0kDa", new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(8907) },
                    { 2, new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9080), "XHIMLC PXEEYE", "https://calendar.google.com/calendar/u/0/r", "8enV2d", new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9080) },
                    { 3, new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9093), "DQRTKI OKJCKP", "https://github.com/Maximiliyano?tab=repositories", "LaGYOb", new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9093) },
                    { 4, new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9104), "QSHXBL DSFWKC", "https://learnenglish.britishcouncil.org/", "jHaWHe", new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9104) },
                    { 5, new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9137), "WJHLOM ALCCQP", "https://www.youtube.com/", "vFrUTd", new DateTime(2023, 3, 11, 2, 44, 3, 351, DateTimeKind.Local).AddTicks(9137) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "ndrewac@gmail.com", "FirstHXIZ SurDVES", "SGDUMD28", 0 },
                    { 2, "qerbzwf@gmail.com", "FirstPCTD SurPRJD", "CAJHZI68", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "UrlInfo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
