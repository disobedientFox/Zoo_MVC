using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoo_w57047.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zoo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Adress = table.Column<string>(maxLength: 100, nullable: true),
                    TicketPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aviary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<int>(nullable: false),
                    MaxAnimals = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ZooId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aviary_Zoo_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(maxLength: 30, nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    AviaryId = table.Column<long>(nullable: true),
                    ZooId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Aviary_AviaryId",
                        column: x => x.AviaryId,
                        principalTable: "Aviary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animal_Zoo_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AviaryId",
                table: "Animal",
                column: "AviaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ZooId",
                table: "Animal",
                column: "ZooId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviary_ZooId",
                table: "Aviary",
                column: "ZooId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Aviary");

            migrationBuilder.DropTable(
                name: "Zoo");
        }
    }
}
