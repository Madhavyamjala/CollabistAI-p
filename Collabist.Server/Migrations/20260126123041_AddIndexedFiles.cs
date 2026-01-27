using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collabist.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexedFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IgnoreFileDetected",
                table: "DataSources");

            migrationBuilder.RenameColumn(
                name: "AddedAt",
                table: "DataSources",
                newName: "ApprovedAt");

            migrationBuilder.AddColumn<string>(
                name: "IgnoreFilePath",
                table: "DataSources",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IndexedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataSourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileHash = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    LastIndexedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexedFiles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndexedFiles");

            migrationBuilder.DropColumn(
                name: "IgnoreFilePath",
                table: "DataSources");

            migrationBuilder.RenameColumn(
                name: "ApprovedAt",
                table: "DataSources",
                newName: "AddedAt");

            migrationBuilder.AddColumn<bool>(
                name: "IgnoreFileDetected",
                table: "DataSources",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
