using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mvcMovie.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Pseudo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_Category_category_id",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmUser",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false),
                    Film_id = table.Column<int>(nullable: false),
                    Status_id = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmUser", x => new { x.Film_id, x.Status_id, x.User_id });
                    table.ForeignKey(
                        name: "FK_FilmUser_Film_Film_id",
                        column: x => x.Film_id,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmUser_Status_Status_id",
                        column: x => x.Status_id,
                        principalTable: "Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmUser_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Drame" },
                    { 2, "Comédie" },
                    { 3, "Thriller" },
                    { 4, "Action" },
                    { 5, "Fantastique" },
                    { 6, "Horreur" },
                    { 7, "Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "A voir" },
                    { 2, "Vu" },
                    { 3, "Pas intéressé" },
                    { 4, "Favoris / coup de coeur" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Email", "Firstname", "Lastname", "Password", "Pseudo" },
                values: new object[,]
                {
                    { 1, "pierre.andre@gmail.com", "Pierre", "André", "Rfc2898DeriveBytes$50000$+Cy3mW/JYCc+Eq/UkZeMRQ==$ITkpD61uH1atv1Ff41qPEfa9MYoyKXqGCrVDuiNXsBg=", "Pierre03" },
                    { 2, "jean.marc@gmail.com", "Jean", "Marc", "Rfc2898DeriveBytes$50000$AMhllGXPBqDcSy7fV+hKVQ==$1ICFSALWHrvWrJRHluQxDtBgbW4ZCBPWrpiJM4+T1R8=", "jeanJean" }
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "ID", "Description", "Image", "Name", "Year", "category_id" },
                values: new object[,]
                {
                    { 2, "Three former parapsychology professors set up shop as a unique ghost removal service.", "https://m.media-amazon.com/images/M/MV5BMTkxMjYyNzgwMl5BMl5BanBnXkFtZTgwMTE3MjYyMTE@._V1_SX300.jpg", "Ghostbusters", new DateTime(1984, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "A small-town sheriff in the American West enlists the help of a cripple, a drunk, and a young gunfighter in his efforts to hold in jail the brother of the local bad guy.", "https://m.media-amazon.com/images/M/MV5BZDVhMTk1NjUtYjc0OS00OTE1LTk1NTYtYWMzMDI5OTlmYzU2XkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_SX300.jpg", "Rio Bravo", new DateTime(1959, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 1, "In 1938, after his father Professor Henry Jones, Sr.goes missing while pursuing the Holy Grail, Professor Henry \"Indiana\" Jones, Jr. finds himself up against Adolf Hitler's Nazis again to stop them from obtaining its powers.", "https://m.media-amazon.com/images/M/MV5BMjNkMzc2N2QtNjVlNS00ZTk5LTg0MTgtODY2MDAwNTMwZjBjXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_SX300.jpg", "Indiana Jones and the Last Crusade", new DateTime(1989, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 3, "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee and two droids to save the galaxy from the Empire's world-destroying battle station, while also attempting to rescue Princess Leia from the mysterious Darth Vader.", "https://m.media-amazon.com/images/M/MV5BNzVlY2MwMjktM2E4OS00Y2Y3LWE3ZjctYzhkZGM3YzA1ZWM2XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SX300.jpg", "Star Wars: Episode IV - A New Hope", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "FilmUser",
                columns: new[] { "Film_id", "Status_id", "User_id", "ID", "Rating" },
                values: new object[] { 4, 3, 1, 2, 5 });

            migrationBuilder.InsertData(
                table: "FilmUser",
                columns: new[] { "Film_id", "Status_id", "User_id", "ID", "Rating" },
                values: new object[] { 1, 2, 1, 1, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Film_category_id",
                table: "Film",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_FilmUser_Status_id",
                table: "FilmUser",
                column: "Status_id");

            migrationBuilder.CreateIndex(
                name: "IX_FilmUser_User_id",
                table: "FilmUser",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmUser");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
