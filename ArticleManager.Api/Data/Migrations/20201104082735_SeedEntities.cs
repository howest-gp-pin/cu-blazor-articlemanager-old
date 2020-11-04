using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleManager.Api.Data.Migrations
{
    public partial class SeedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Boardgames and computer games", "Games" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Enhance your programming skills", "Books" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Computer hardware", "Hardware" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Search for gold in de California Gold Rush", "Coloma" },
                    { 2, 1, "Examine mines and herd animals with your dwarves", "Caverna" },
                    { 3, 1, "Connect your production cites with boats and trains.", "Brass Birmingham" },
                    { 4, 2, "Step-by-step guide written in a lucid language for mastering C#", "Mastering C#" },
                    { 5, 2, "Become a more productive programmer by leveraging the newest features available to you in C#. ", "Exploring Advanced Features in C#" },
                    { 6, 2, "Implement rich Azure SAAS-PAAS-IAAS ecosystems using containers, serverless services, and storage solutions", "Learn Microsoft Azure" },
                    { 7, 3, "Have a clear sight on your code", "Monitor" },
                    { 8, 3, "Click your way to succes", "Mouse" },
                    { 9, 3, "Type great code", "Keyboard" },
                    { 10, 3, "Scan all kinds of cards", "Cardreader" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
