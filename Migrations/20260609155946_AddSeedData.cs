using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyComfort.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Blankets",
                columns: new[] { "Id", "Material", "Model", "Stock" },
                values: new object[] { 1, "Fleece", "Cozy Classic", 100 });

            migrationBuilder.InsertData(
                table: "Distributors",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "New York", "Global Dist" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { 1, "contact@bestbeds.com", "Best Beds" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blankets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Distributors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
