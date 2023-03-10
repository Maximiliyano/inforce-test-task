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
                name: "AboutInfo",
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
                    table.PrimaryKey("PK_AboutInfo", x => x.Id);
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
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { 1, new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(8824), "TLLZLT ZWLNCG", "https://mail.google.com/mail/u/0/?pli=1#inbox", "WR0kDa", new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(8824) },
                    { 2, new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9000), "TBASPT BNBGXN", "https://calendar.google.com/calendar/u/0/r", "8enV2d", new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9000) },
                    { 3, new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9019), "TEWAGK HREPMD", "https://github.com/Maximiliyano?tab=repositories", "LaGYOb", new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9019) },
                    { 4, new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9033), "ITEGAN WTNDDO", "https://learnenglish.britishcouncil.org/", "jHaWHe", new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9033) },
                    { 5, new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9045), "UZAZXZ YTKNVC", "https://www.youtube.com/", "vFrUTd", new DateTime(2023, 3, 10, 13, 30, 23, 863, DateTimeKind.Local).AddTicks(9045) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "zvhhvqm@gmail.com", "FirstJRHQ SurGSPY", "BJVSOC37", "User" },
                    { 2, "cciwijj@gmail.com", "FirstQXEX SurGKEE", "AUHEBL90", "User" },
                    { 3, "twbpulz@gmail.com", "FirstFPOE SurGESP", "YGBJCA36", "User" },
                    { 4, "jsjvxtn@gmail.com", "FirstZNLE SurXECB", "YYBYUR74", "User" },
                    { 5, "mzueypm@gmail.com", "FirstDPEK SurLBNP", "JHNCWH66", "User" },
                    { 6, "jfwlgom@gmail.com", "FirstMBRF SurDRAP", "NETSFD82", "User" },
                    { 7, "enfbnho@gmail.com", "FirstFNHZ SurYVKZ", "NIVCXI92", "User" },
                    { 8, "fiwstlj@gmail.com", "FirstIKZU SurNGGG", "IAOWIK99", "User" },
                    { 9, "rkmussj@gmail.com", "FirstSRND SurCEBH", "KWHGZY46", "User" },
                    { 10, "adkbifa@gmail.com", "FirstLZFP SurINPF", "KHTCPM90", "User" },
                    { 11, "cxadppc@gmail.com", "FirstEFPG SurODFB", "TOABLS33", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutInfo");

            migrationBuilder.DropTable(
                name: "UrlInfo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
