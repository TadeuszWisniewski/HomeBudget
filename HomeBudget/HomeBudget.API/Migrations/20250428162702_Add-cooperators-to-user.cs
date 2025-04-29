using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeBudget.API.Migrations
{
    /// <inheritdoc />
    public partial class Addcooperatorstouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoOperatorId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_CoOperatorId",
                table: "User",
                column: "CoOperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CoOperatorId",
                table: "User",
                column: "CoOperatorId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CoOperatorId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CoOperatorId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CoOperatorId",
                table: "User");
        }
    }
}
