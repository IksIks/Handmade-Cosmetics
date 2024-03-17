using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HandmadeСosmetics.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_AmountInRecipe_AmountsId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Recipes_RecipesId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_AmountsId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipesId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "AmountsId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipesId",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "AmountInRecipeRecipe",
                columns: table => new
                {
                    AmountsId = table.Column<int>(type: "integer", nullable: false),
                    RecipesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountInRecipeRecipe", x => new { x.AmountsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_AmountInRecipeRecipe_AmountInRecipe_AmountsId",
                        column: x => x.AmountsId,
                        principalTable: "AmountInRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmountInRecipeRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmountInRecipeRecipe_RecipesId",
                table: "AmountInRecipeRecipe",
                column: "RecipesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmountInRecipeRecipe");

            migrationBuilder.AddColumn<int>(
                name: "AmountsId",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipesId",
                table: "Recipes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_AmountsId",
                table: "Recipes",
                column: "AmountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipesId",
                table: "Recipes",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_AmountInRecipe_AmountsId",
                table: "Recipes",
                column: "AmountsId",
                principalTable: "AmountInRecipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Recipes_RecipesId",
                table: "Recipes",
                column: "RecipesId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
