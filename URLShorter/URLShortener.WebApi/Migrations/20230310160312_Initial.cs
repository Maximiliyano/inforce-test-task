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
                    { 1, new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6173), "MSPMQP YPPYAO", "https://mail.google.com/mail/u/0/?pli=1#inbox", "WR0kDa", new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6173) },
                    { 2, new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6337), "ZABOYZ KCNQSK", "https://calendar.google.com/calendar/u/0/r", "8enV2d", new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6337) },
                    { 3, new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6351), "HUJKTI QOTMHS", "https://github.com/Maximiliyano?tab=repositories", "LaGYOb", new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6351) },
                    { 4, new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6362), "HMGWWD UOSWFW", "https://learnenglish.britishcouncil.org/", "jHaWHe", new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6362) },
                    { 5, new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6372), "FKAPUY RZOXTE", "https://www.youtube.com/", "vFrUTd", new DateTime(2023, 3, 10, 18, 3, 12, 476, DateTimeKind.Local).AddTicks(6372) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "obwupun@gmail.com", "FirstFVRJ SurLMGP", "WSFDEI34", "User" },
                    { 2, "qkneiph@gmail.com", "FirstQACR SurTDEH", "DHWAJW91", "User" },
                    { 3, "qdauoxa@gmail.com", "FirstLIDT SurXTYC", "UQYVJI8", "User" },
                    { 4, "jotiejp@gmail.com", "FirstWLWZ SurCIRX", "WLHXCY55", "User" },
                    { 5, "vjfximq@gmail.com", "FirstAFDM SurMGCV", "KODZRO78", "User" },
                    { 6, "aagdlpz@gmail.com", "FirstFDPT SurTMMP", "LWROWV14", "User" },
                    { 7, "bouvxod@gmail.com", "FirstOAGF SurCVEZ", "WMMENU89", "User" },
                    { 8, "qrrpesd@gmail.com", "FirstGZOY SurCRKA", "HDMYGF15", "User" },
                    { 9, "ikzwdst@gmail.com", "FirstZTHK SurBEHS", "RBEZEF9", "User" },
                    { 10, "dnzhimx@gmail.com", "FirstJZGR SurURTJ", "CDJAIO32", "User" },
                    { 11, "wtbenti@gmail.com", "FirstDYNA SurRXEX", "ZGEBKZ6", "Admin" }
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
