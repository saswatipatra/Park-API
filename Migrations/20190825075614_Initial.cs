﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Solution.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    StateName = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "nationalPark",
                columns: table => new
                {
                    NationalParkId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<int>(nullable: false),
                    ParkName = table.Column<string>(nullable: true),
                    AvgRating = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalPark", x => x.NationalParkId);
                    table.ForeignKey(
                        name: "FK_nationalPark_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateId = table.Column<int>(nullable: false),
                    NationalParkId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    ReviewText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_reviews_nationalPark_NationalParkId",
                        column: x => x.NationalParkId,
                        principalTable: "nationalPark",
                        principalColumn: "NationalParkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_states_StateId",
                        column: x => x.StateId,
                        principalTable: "states",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nationalPark_StateId",
                table: "nationalPark",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_NationalParkId",
                table: "reviews",
                column: "NationalParkId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_StateId",
                table: "reviews",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "nationalPark");

            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
