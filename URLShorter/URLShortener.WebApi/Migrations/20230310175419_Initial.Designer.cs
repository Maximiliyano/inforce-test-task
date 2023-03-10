﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URLShortener.WebApi.Data;

#nullable disable

namespace URLShortener.WebApi.Migrations
{
    [DbContext(typeof(UrlDbContext))]
    [Migration("20230310175419_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("URLShortener.WebApi.Data.Dtos.UrlInfoDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortedString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UrlInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1058),
                            CreatedBy = "PZPBUA IPOFQS",
                            OriginalString = "https://mail.google.com/mail/u/0/?pli=1#inbox",
                            ShortedString = "WR0kDa",
                            UpdatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1058)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1228),
                            CreatedBy = "UDOGWD NLAWVF",
                            OriginalString = "https://calendar.google.com/calendar/u/0/r",
                            ShortedString = "8enV2d",
                            UpdatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1228)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1245),
                            CreatedBy = "SIHFPW QYUWKY",
                            OriginalString = "https://github.com/Maximiliyano?tab=repositories",
                            ShortedString = "LaGYOb",
                            UpdatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1245)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1257),
                            CreatedBy = "YYXXUA YLWJEI",
                            OriginalString = "https://learnenglish.britishcouncil.org/",
                            ShortedString = "jHaWHe",
                            UpdatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1257)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1292),
                            CreatedBy = "UFCHOQ IPFVUV",
                            OriginalString = "https://www.youtube.com/",
                            ShortedString = "vFrUTd",
                            UpdatedAt = new DateTime(2023, 3, 10, 19, 54, 19, 687, DateTimeKind.Local).AddTicks(1292)
                        });
                });

            modelBuilder.Entity("URLShortener.WebApi.Data.Dtos.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "gkypnfp@gmail.com",
                            Name = "FirstYEAB SurDGJP",
                            Password = "XKEXHZ8",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "talgfne@gmail.com",
                            Name = "FirstVOYL SurREBK",
                            Password = "LISTAS61",
                            Role = 0
                        },
                        new
                        {
                            Id = 3,
                            Email = "qyijlfl@gmail.com",
                            Name = "FirstXCWK SurPUIJ",
                            Password = "TDAKRQ92",
                            Role = 0
                        },
                        new
                        {
                            Id = 4,
                            Email = "odptzew@gmail.com",
                            Name = "FirstBGPI SurHYDU",
                            Password = "RZSZWL70",
                            Role = 0
                        },
                        new
                        {
                            Id = 5,
                            Email = "pdnjhgv@gmail.com",
                            Name = "FirstNMZH SurACYI",
                            Password = "DEDDQV70",
                            Role = 0
                        },
                        new
                        {
                            Id = 6,
                            Email = "vqrocnl@gmail.com",
                            Name = "FirstUILR SurXOHI",
                            Password = "YVXKHW95",
                            Role = 0
                        },
                        new
                        {
                            Id = 7,
                            Email = "kpwiwsb@gmail.com",
                            Name = "FirstOYVZ SurKEVQ",
                            Password = "LKMVWP94",
                            Role = 0
                        },
                        new
                        {
                            Id = 8,
                            Email = "naaptqo@gmail.com",
                            Name = "FirstNYJJ SurWXDQ",
                            Password = "GJAQNN94",
                            Role = 0
                        },
                        new
                        {
                            Id = 9,
                            Email = "rtxvyci@gmail.com",
                            Name = "FirstGSYE SurWPHU",
                            Password = "URJKUW83",
                            Role = 0
                        },
                        new
                        {
                            Id = 10,
                            Email = "xcaacpa@gmail.com",
                            Name = "FirstNBBU SurXOSN",
                            Password = "CWPLAI41",
                            Role = 0
                        },
                        new
                        {
                            Id = 11,
                            Email = "rabonil@gmail.com",
                            Name = "FirstBOUU SurDJTG",
                            Password = "YLYRNQ53",
                            Role = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}