﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkHubBackEndServices.Migrations
{
    /// <inheritdoc />
    public partial class ChangePrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "price");
        }
    }
}
