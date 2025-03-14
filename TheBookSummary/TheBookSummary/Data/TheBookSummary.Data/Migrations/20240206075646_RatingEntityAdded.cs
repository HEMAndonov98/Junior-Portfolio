using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookSummary.Data.Migrations
{
    /// <inheritdoc />
    public partial class RatingEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSummary_BookSummaryId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookSummary",
                table: "BookSummary");

            migrationBuilder.RenameTable(
                name: "BookSummary",
                newName: "BookSummaries");

            migrationBuilder.RenameIndex(
                name: "IX_BookSummary_IsDeleted",
                table: "BookSummaries",
                newName: "IX_BookSummaries_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookSummaries",
                table: "BookSummaries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false, comment: "Number of stars given in the rating. Must be within the defined range."),
                    BookId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Foreign key referencing the associated book."),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Foreign key referencing the user who made the rating."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BookId",
                table: "Ratings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_IsDeleted",
                table: "Ratings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSummaries_BookSummaryId",
                table: "Books",
                column: "BookSummaryId",
                principalTable: "BookSummaries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookSummaries_BookSummaryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookSummaries",
                table: "BookSummaries");

            migrationBuilder.RenameTable(
                name: "BookSummaries",
                newName: "BookSummary");

            migrationBuilder.RenameIndex(
                name: "IX_BookSummaries_IsDeleted",
                table: "BookSummary",
                newName: "IX_BookSummary_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookSummary",
                table: "BookSummary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookSummary_BookSummaryId",
                table: "Books",
                column: "BookSummaryId",
                principalTable: "BookSummary",
                principalColumn: "Id");
        }
    }
}
