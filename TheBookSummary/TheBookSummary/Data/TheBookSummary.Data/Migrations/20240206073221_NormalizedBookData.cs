using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookSummary.Data.Migrations
{
    /// <inheritdoc />
    public partial class NormalizedBookData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullSummary",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ShortSummary",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "BookSummaryId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Foreign key referencing the associated book summary.");

            migrationBuilder.CreateTable(
                name: "BookSummary",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShortSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Short summary of the book. It is required and has a maximum length as defined by BookConstraints."),
                    FullSummary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "Full summary of the book. It is required and has a maximum length as defined by BookConstraints."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSummary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookSummaryId",
                table: "Books",
                column: "BookSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSummary_IsDeleted",
                table: "BookSummary",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSummary_BookSummaryId",
                table: "Books",
                column: "BookSummaryId",
                principalTable: "BookSummary",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSummary_BookSummaryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookSummary");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookSummaryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookSummaryId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "FullSummary",
                table: "Books",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                comment: "Full summary of the book. It is required and has a maximum length as defined by BookConstraints.");

            migrationBuilder.AddColumn<string>(
                name: "ShortSummary",
                table: "Books",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                comment: "Short summary of the book. It is required and has a maximum length as defined by BookConstraints.");
        }
    }
}
