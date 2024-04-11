using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtArchitects.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedmanyToManyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReviews_AspNetUsers_UserId",
                table: "ProjectReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReviews_Projects_ProjectId",
                table: "ProjectReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Architects_ArchitectId",
                table: "Projects");

            migrationBuilder.CreateTable(
                name: "ProjectArchitect",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ArchitectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectArchitect", x => new { x.ProjectId, x.ArchitectId });
                    table.ForeignKey(
                        name: "FK_ProjectArchitect_Architects_ArchitectId",
                        column: x => x.ArchitectId,
                        principalTable: "Architects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectArchitect_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectArchitect_ArchitectId",
                table: "ProjectArchitect",
                column: "ArchitectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReviews_AspNetUsers_UserId",
                table: "ProjectReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReviews_Projects_ProjectId",
                table: "ProjectReviews",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Architects_ArchitectId",
                table: "Projects",
                column: "ArchitectId",
                principalTable: "Architects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReviews_AspNetUsers_UserId",
                table: "ProjectReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReviews_Projects_ProjectId",
                table: "ProjectReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Architects_ArchitectId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectArchitect");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReviews_AspNetUsers_UserId",
                table: "ProjectReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReviews_Projects_ProjectId",
                table: "ProjectReviews",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Architects_ArchitectId",
                table: "Projects",
                column: "ArchitectId",
                principalTable: "Architects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
