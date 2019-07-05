using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.api.Migrations
{
    public partial class InitianMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("02d0be85-7064-4446-a3f3-00000cb31f46"), "George", "Orwell" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("b29f845e-62cc-4aa6-b764-000010082f62"), "Jack", "Kureoak" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("2492cf4e-e468-4b32-b77a-0000538842a8"), "Dan", "Brown" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("c5f57cf7-0dfb-4bac-9419-00007d690626"), new Guid("02d0be85-7064-4446-a3f3-00000cb31f46"), "Duplipensar", "1984" },
                    { new Guid("a08b083d-cf52-4641-a6f9-000087b26762"), new Guid("02d0be85-7064-4446-a3f3-00000cb31f46"), "Pigs", "Animal Farm" },
                    { new Guid("8b833dbe-7d3e-4567-a332-0000b06950ef"), new Guid("b29f845e-62cc-4aa6-b764-000010082f62"), "Beatniks", "On the Road" },
                    { new Guid("d5c261a7-b5e5-4552-8a8b-0000c514e724"), new Guid("2492cf4e-e468-4b32-b77a-0000538842a8"), "Amon and Isis", "da Vinci code" },
                    { new Guid("d54d6591-629e-43df-8b9e-0000f7f4c73b"), new Guid("2492cf4e-e468-4b32-b77a-0000538842a8"), "Vatican", "Angels and Deamons" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
