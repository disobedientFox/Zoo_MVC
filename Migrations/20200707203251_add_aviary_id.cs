using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoo_w57047.Migrations
{
    public partial class add_aviary_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Aviary_AviaryId",
                table: "Animal");

            migrationBuilder.AlterColumn<long>(
                name: "AviaryId",
                table: "Animal",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Aviary_AviaryId",
                table: "Animal",
                column: "AviaryId",
                principalTable: "Aviary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Aviary_AviaryId",
                table: "Animal");

            migrationBuilder.AlterColumn<long>(
                name: "AviaryId",
                table: "Animal",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Aviary_AviaryId",
                table: "Animal",
                column: "AviaryId",
                principalTable: "Aviary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
