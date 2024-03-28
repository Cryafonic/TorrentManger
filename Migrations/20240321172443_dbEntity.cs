using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorrentManager.Migrations
{
    /// <inheritdoc />
    public partial class dbEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvidedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TorrentFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaFileTypeId = table.Column<int>(type: "int", nullable: false),
                    MediaRequestStatusId = table.Column<int>(type: "int", nullable: false),
                    DownloadableLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaRequests");
        }
    }
}
