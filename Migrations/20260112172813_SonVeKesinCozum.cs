using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KutuphaneAPI.Migrations
{
    /// <inheritdoc />
    public partial class SonVeKesinCozum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ISBN = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "BorrowRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowRecords_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Yazar 1" },
                    { 2, false, "Yazar 2" },
                    { 3, false, "Yazar 3" },
                    { 4, false, "Yazar 4" },
                    { 5, false, "Yazar 5" },
                    { 6, false, "Yazar 6" },
                    { 7, false, "Yazar 7" },
                    { 8, false, "Yazar 8" },
                    { 9, false, "Yazar 9" },
                    { 10, false, "Yazar 10" },
                    { 11, false, "Yazar 11" },
                    { 12, false, "Yazar 12" },
                    { 13, false, "Yazar 13" },
                    { 14, false, "Yazar 14" },
                    { 15, false, "Yazar 15" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "IsDeleted", "LastName", "Name", "Password", "Role" },
                values: new object[] { 1, "Merkez", "admin@kutuphane.com", false, "Sistem", "Admin", "admin1905", "Admin" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, 1, "ISBN-1A", false, "Kitap 1A" },
                    { 2, 1, "ISBN-1B", false, "Kitap 1B" },
                    { 3, 2, "ISBN-2A", false, "Kitap 2A" },
                    { 4, 2, "ISBN-2B", false, "Kitap 2B" },
                    { 5, 3, "ISBN-3A", false, "Kitap 3A" },
                    { 6, 3, "ISBN-3B", false, "Kitap 3B" },
                    { 7, 4, "ISBN-4A", false, "Kitap 4A" },
                    { 8, 4, "ISBN-4B", false, "Kitap 4B" },
                    { 9, 5, "ISBN-5A", false, "Kitap 5A" },
                    { 10, 5, "ISBN-5B", false, "Kitap 5B" },
                    { 11, 6, "ISBN-6A", false, "Kitap 6A" },
                    { 12, 6, "ISBN-6B", false, "Kitap 6B" },
                    { 13, 7, "ISBN-7A", false, "Kitap 7A" },
                    { 14, 7, "ISBN-7B", false, "Kitap 7B" },
                    { 15, 8, "ISBN-8A", false, "Kitap 8A" },
                    { 16, 8, "ISBN-8B", false, "Kitap 8B" },
                    { 17, 9, "ISBN-9A", false, "Kitap 9A" },
                    { 18, 9, "ISBN-9B", false, "Kitap 9B" },
                    { 19, 10, "ISBN-10A", false, "Kitap 10A" },
                    { 20, 10, "ISBN-10B", false, "Kitap 10B" },
                    { 21, 11, "ISBN-11A", false, "Kitap 11A" },
                    { 22, 11, "ISBN-11B", false, "Kitap 11B" },
                    { 23, 12, "ISBN-12A", false, "Kitap 12A" },
                    { 24, 12, "ISBN-12B", false, "Kitap 12B" },
                    { 25, 13, "ISBN-13A", false, "Kitap 13A" },
                    { 26, 13, "ISBN-13B", false, "Kitap 13B" },
                    { 27, 14, "ISBN-14A", false, "Kitap 14A" },
                    { 28, 14, "ISBN-14B", false, "Kitap 14B" },
                    { 29, 15, "ISBN-15A", false, "Kitap 15A" },
                    { 30, 15, "ISBN-15B", false, "Kitap 15B" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_BookId",
                table: "BorrowRecords",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_UserId",
                table: "BorrowRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowRecords");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
