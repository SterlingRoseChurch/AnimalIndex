using Microsoft.EntityFrameworkCore.Migrations;

namespace TheAnimalIndex.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Animalss",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animalss", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animalss_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { "M", "Mammal" },
                    { "B", "Bird" },
                    { "R", "Reptile" },
                    { "A", "Amphimbian" },
                    { "I", "Invertebrate" },
                    { "F", "Fish" }
                });

            migrationBuilder.InsertData(
                table: "Animalss",
                columns: new[] { "AnimalId", "Species", "TypeId" },
                values: new object[] { 1, "Tiger", "M" });

            migrationBuilder.InsertData(
                table: "Animalss",
                columns: new[] { "AnimalId", "Species", "TypeId" },
                values: new object[] { 3, "Frog", "A" });

            migrationBuilder.InsertData(
                table: "Animalss",
                columns: new[] { "AnimalId", "Species", "TypeId" },
                values: new object[] { 2, "Tuna", "F" });

            migrationBuilder.CreateIndex(
                name: "IX_Animalss_TypeId",
                table: "Animalss",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animalss");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
