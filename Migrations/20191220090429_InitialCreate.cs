using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcquisitionTermProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    MovieTitle = table.Column<string>(nullable: true),
                    IMDBUrl = table.Column<string>(nullable: true),
                    MovieRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    UserPassword = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "MovieRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    MovieId = table.Column<long>(nullable: false),
                    Rate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieRates_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieRates_MovieId",
                table: "MovieRates",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRates_UserId",
                table: "MovieRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_IMDBUrl",
                table: "Movies",
                column: "IMDBUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieRate",
                table: "Movies",
                column: "MovieRate");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieTitle",
                table: "Movies",
                column: "MovieTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieRates");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
