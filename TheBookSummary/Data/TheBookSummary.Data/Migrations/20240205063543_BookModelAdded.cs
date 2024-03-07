using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookSummary.Data.Migrations
{
    /// <inheritdoc />
    public partial class BookModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShortSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Short summary of the book. It is required and has a maximum length as defined by BookConstraints."),
                    FullSummary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Full summary of the book. It is required and has a maximum length as defined by BookConstraints."),
                    BookName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the book. It is required and has a maximum length as defined by BookConstraints."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_IsDeleted",
                table: "Books",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
