using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtArchitects.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changesInModelsProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Architects_ArcitectId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ArcitectId",
                table: "Projects",
                newName: "ArchitectId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ArcitectId",
                table: "Projects",
                newName: "IX_Projects_ArchitectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Architects_ArchitectId",
                table: "Projects",
                column: "ArchitectId",
                principalTable: "Architects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Architects_ArchitectId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ArchitectId",
                table: "Projects",
                newName: "ArcitectId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ArchitectId",
                table: "Projects",
                newName: "IX_Projects_ArcitectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Architects_ArcitectId",
                table: "Projects",
                column: "ArcitectId",
                principalTable: "Architects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
