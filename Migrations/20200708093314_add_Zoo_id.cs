using Microsoft.EntityFrameworkCore.Migrations;

namespace Zoo_w57047.Migrations
{
    public partial class add_Zoo_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aviary_Zoo_ZooId",
                table: "Aviary");

            migrationBuilder.AlterColumn<long>(
                name: "ZooId",
                table: "Aviary",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aviary_Zoo_ZooId",
                table: "Aviary",
                column: "ZooId",
                principalTable: "Zoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aviary_Zoo_ZooId",
                table: "Aviary");

            migrationBuilder.AlterColumn<long>(
                name: "ZooId",
                table: "Aviary",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Aviary_Zoo_ZooId",
                table: "Aviary",
                column: "ZooId",
                principalTable: "Zoo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
