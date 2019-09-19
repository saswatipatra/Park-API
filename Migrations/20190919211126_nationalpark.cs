using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Solution.Migrations
{
    public partial class nationalpark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_states_StateId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_StateId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "reviews",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_StateId",
                table: "reviews",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_states_StateId",
                table: "reviews",
                column: "StateId",
                principalTable: "states",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
