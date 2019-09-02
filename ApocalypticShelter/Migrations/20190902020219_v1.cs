using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApocalypticShelter.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Observation = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShelterStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ResourceId = table.Column<int>(nullable: false),
                    ShelterId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterStocks_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterStocks_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survivors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 120, nullable: false),
                    HashPassword = table.Column<string>(type: "varchar(255)", maxLength: 120, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ShelterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survivors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survivors_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Type = table.Column<int>(nullable: false),
                    ResourceId = table.Column<int>(nullable: false),
                    ShelterId = table.Column<int>(nullable: false),
                    SurvivorId = table.Column<int>(nullable: false),
                    InitialBalance = table.Column<int>(nullable: false),
                    FinalBalance = table.Column<int>(nullable: false),
                    QuantityMoved = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Survivors_SurvivorId",
                        column: x => x.SurvivorId,
                        principalTable: "Survivors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelterStocks_ResourceId",
                table: "ShelterStocks",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterStocks_ShelterId",
                table: "ShelterStocks",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Survivors_ShelterId",
                table: "Survivors",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ResourceId",
                table: "Transactions",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ShelterId",
                table: "Transactions",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SurvivorId",
                table: "Transactions",
                column: "SurvivorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelterStocks");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Survivors");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
