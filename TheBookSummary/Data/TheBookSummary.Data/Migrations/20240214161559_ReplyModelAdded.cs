using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheBookSummary.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReplyModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ParentCommentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParentReplyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_Replies_ParentReplyId",
                        column: x => x.ParentReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_IsDeleted",
                table: "Replies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ParentCommentId",
                table: "Replies",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ParentReplyId",
                table: "Replies",
                column: "ParentReplyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");
        }
    }
}
