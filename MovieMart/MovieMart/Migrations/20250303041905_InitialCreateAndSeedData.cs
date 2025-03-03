﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieMart.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvSeries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterTvSeries",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterTvSeries", x => new { x.CharacterId, x.TvSeriesId });
                    table.ForeignKey(
                        name: "FK_CharacterTvSeries_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterTvSeries_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    TvSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_TvSeries_TvSeriesId",
                        column: x => x.TvSeriesId,
                        principalTable: "TvSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovies",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovies", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovies_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Anime filled with action and adventure.", "Shonen" },
                    { 2, "Anime for mature audiences.", "Seinen" },
                    { 3, "Anime with magical and supernatural elements.", "Fantasy" },
                    { 4, "Futuristic anime with advanced technology.", "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The protagonist of Naruto, dreams of becoming Hokage.", "Naruto Uzumaki" },
                    { 2, "Naruto’s rival, seeking revenge against his brother Itachi.", "Sasuke Uchiha" },
                    { 3, "Captain of the Survey Corps, known for his unmatched combat skills.", "Levi Ackerman" },
                    { 4, "Main protagonist of Attack on Titan, fights against the Titans.", "Eren Yeager" },
                    { 5, "A teenage girl who swaps bodies with a boy from Tokyo in 'Your Name'.", "Mitsuha Miyamizu" }
                });

            migrationBuilder.InsertData(
                table: "TvSeries",
                columns: new[] { "Id", "Author", "Description", "ImgUrl", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Masashi Kishimoto", "A young ninja seeks recognition and dreams of becoming the Hokage.", "naruto.jpg", 8.3000000000000007, 2002, "Naruto" },
                    { 2, "Hajime Isayama", "Humanity fights for survival against terrifying Titans.", "aot.jpg", 9.0999999999999996, 2013, "Attack on Titan" },
                    { 3, "Eiichiro Oda", "Monkey D. Luffy sets sail to find the legendary One Piece treasure.", "onepiece.jpg", 9.0, 1999, "One Piece" }
                });

            migrationBuilder.InsertData(
                table: "CharacterTvSeries",
                columns: new[] { "CharacterId", "TvSeriesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Duration", "EndDate", "ImgUrl", "Price", "Rating", "ReleaseYear", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Makoto Shinkai", 3, "A heartwarming story of two teenagers swapping bodies across time.", new TimeSpan(0, 1, 46, 0, 0), null, "yourname.jpg", 12.99, 8.8000000000000007, 2016, new DateTime(2016, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your Name" },
                    { 2, "Hayao Miyazaki", 3, "A young girl must navigate a magical world to save her parents.", new TimeSpan(0, 2, 5, 0, 0), null, "spiritedaway.jpg", 14.99, 8.9000000000000004, 2001, new DateTime(2001, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spirited Away" },
                    { 3, "Katsuhiro Otomo", 4, "A cyberpunk masterpiece exploring a dystopian Tokyo.", new TimeSpan(0, 2, 4, 0, 0), null, "akira.jpg", 10.99, 8.0999999999999996, 1988, new DateTime(1988, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Akira" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "ReleaseYear", "SeasonNumber", "Title", "TvSeriesId" },
                values: new object[,]
                {
                    { 1, 2002, 1, "Naruto - Season 1", 1 },
                    { 2, 2003, 2, "Naruto - Season 2", 1 },
                    { 3, 2004, 3, "Naruto - Season 3", 1 },
                    { 4, 2013, 1, "Attack on Titan - Season 1", 2 },
                    { 5, 2017, 2, "Attack on Titan - Season 2", 2 },
                    { 6, 2018, 3, "Attack on Titan - Season 3", 2 }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovies",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 5, 1 });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "Id", "Duration", "EpisodeNumber", "SeasonId", "Title" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 23, 0, 0), 1, 1, "Enter: Naruto Uzumaki!" },
                    { 2, new TimeSpan(0, 0, 23, 0, 0), 2, 1, "My Name is Konohamaru!" },
                    { 3, new TimeSpan(0, 0, 23, 0, 0), 3, 1, "Sasuke and Sakura: Friends or Foes?" },
                    { 4, new TimeSpan(0, 0, 25, 0, 0), 1, 2, "To You, in 2000 Years: The Fall of Shiganshina" },
                    { 5, new TimeSpan(0, 0, 25, 0, 0), 2, 2, "That Day: The Fall of Shiganshina, Part 2" },
                    { 6, new TimeSpan(0, 0, 25, 0, 0), 3, 2, "A Dim Light Amid Despair: Humanity's Comeback" },
                    { 7, new TimeSpan(0, 0, 24, 0, 0), 1, 3, "I'm Luffy! The Man Who's Gonna Be King of the Pirates!" },
                    { 8, new TimeSpan(0, 0, 24, 0, 0), 2, 3, "Enter the Great Swordsman! Pirate Hunter Roronoa Zoro" },
                    { 9, new TimeSpan(0, 0, 24, 0, 0), 3, 3, "Morgan vs. Luffy! Who's This Beautiful Young Girl?" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovies_MovieId",
                table: "CharacterMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterTvSeries_TvSeriesId",
                table: "CharacterTvSeries",
                column: "TvSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TvSeriesId",
                table: "Seasons",
                column: "TvSeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovies");

            migrationBuilder.DropTable(
                name: "CharacterTvSeries");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TvSeries");
        }
    }
}
