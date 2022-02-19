using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaProject.DAL.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaPlaces",
                columns: table => new
                {
                    id_cinemaPlace = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false),
                    city = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: false),
                    street = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    number = table.Column<string>(type: "NVARCHAR(8)", maxLength: 8, nullable: true),
                    zipCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaPlaces", x => x.id_cinemaPlace);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id_movie = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "NVARCHAR(128)", maxLength: 128, nullable: false),
                    subTitle = table.Column<string>(type: "NVARCHAR(64)", maxLength: 64, nullable: true),
                    synopsis = table.Column<string>(type: "NVARCHAR(4000)", maxLength: 4000, nullable: false),
                    releaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    duration = table.Column<int>(type: "INTEGER", nullable: false),
                    posterUrl = table.Column<string>(type: "NVARCHAR(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id_movie);
                });

            migrationBuilder.CreateTable(
                name: "CinemaRooms",
                columns: table => new
                {
                    id_cinemaRoom = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sitsCount = table.Column<int>(type: "INTEGER", nullable: false),
                    screenWidth = table.Column<int>(type: "INTEGER", nullable: false),
                    screenHeight = table.Column<int>(type: "INTEGER", nullable: false),
                    can3D = table.Column<bool>(type: "BIT", nullable: false),
                    can4DX = table.Column<bool>(type: "BIT", nullable: false),
                    number = table.Column<int>(type: "INTEGER", nullable: false),
                    id_cinemaPlace = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaRooms", x => x.id_cinemaRoom);
                    table.ForeignKey(
                        name: "FK_CinemaRooms_CinemaPlaces_id_cinemaPlace",
                        column: x => x.id_cinemaPlace,
                        principalTable: "CinemaPlaces",
                        principalColumn: "id_cinemaPlace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diffusions",
                columns: table => new
                {
                    id_diffusion = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diffusionDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    diffusionTime = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    audLang = table.Column<int>(type: "INTEGER", nullable: false),
                    subTitleLang = table.Column<int>(type: "INTEGER", nullable: true),
                    id_cinemaRoom = table.Column<int>(type: "INT", nullable: false),
                    id_movie = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diffusions", x => x.id_diffusion);
                    table.ForeignKey(
                        name: "FK_Diffusions_CinemaRooms_id_cinemaRoom",
                        column: x => x.id_cinemaRoom,
                        principalTable: "CinemaRooms",
                        principalColumn: "id_cinemaRoom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diffusions_Movies_id_movie",
                        column: x => x.id_movie,
                        principalTable: "Movies",
                        principalColumn: "id_movie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CinemaPlaces",
                columns: new[] { "id_cinemaPlace", "city", "name", "number", "street", "zipCode" },
                values: new object[,]
                {
                    { 1, "Charleroi", "Roosevelt", "3Bis", "Rue Jean Mermoz", 6000 },
                    { 2, "Liège", "Le Spectaculaire", "24", "Avenue des cerisiers", 4000 },
                    { 3, "Namur", "Le Parc", null, "Place des Lumières", 5000 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "id_movie", "duration", "posterUrl", "releaseYear", "subTitle", "synopsis", "title" },
                values: new object[,]
                {
                    { 1, 109, "encanto.jpg", 2021, "La fantastique famille Madrigal", "Synopsis : Dans un mystérieux endroit niché au cœur des montagnes de Colombie, la fantastique famille Madrigal habite une maison enchantée dans une cité pleine de vie, un endroit merveilleux appelé Encanto. L’Encanto a doté chacun des enfants de la famille d’une faculté magique allant d’une force surhumaine au pouvoir de guérison.", "Encanto" },
                    { 2, 114, "scream.jpg", 2022, null, "Interdit aux moins de 16 ans Vingt-cinq ans après que la paisible ville de Woodsboro a été frappée par une série de meurtres violents, un nouveau tueur revêt le masque de Ghostface et prend pour cible un groupe d'adolescents. Il est déterminé à faire ressurgir les sombres secrets du passé.", "Scream" },
                    { 3, 116, "uncharted.jpg", 2022, null, "Uncharted est un film américain réalisé par Ruben Fleischer et dont la sortie est prévue en 2022. Il s'agit d'une adaptation cinématographique de la série de jeux vidéo Uncharted développés par Naughty Dog et édités par Sony Interactive Entertainment.", "Uncharted" },
                    { 4, 148, "spiderman.jpg", 2021, "No way home", "Pour la première fois dans son histoire cinématographique, Spider-Man, le héros sympa du quartier est démasqué et ne peut désormais plus séparer sa vie normale de ses lourdes responsabilités de super-héros. Quand il demande de l'aide à Doctor Strange, les enjeux deviennent encore plus dangereux, le forçant à découvrir ce qu'être Spider-Man signifie véritablement.", "Spider-Man" },
                    { 5, 112, "scene.jpg", 2021, null, "Tous en scène 2 ou Chantez ! 2 au Québec ( Sing 2) est un film d'animation réalisé par Garth Jennings et sorti en 2021. C'est la suite de Tous en scène sorti en 2016 . Buster Moon et ses amis essaient de convaincre la star du rock recluse Clay Calloway de rejoindre leur show d'ouverture .", "Tous en scène 2" }
                });

            migrationBuilder.InsertData(
                table: "CinemaRooms",
                columns: new[] { "id_cinemaRoom", "can3D", "can4DX", "id_cinemaPlace", "number", "screenHeight", "screenWidth", "sitsCount" },
                values: new object[,]
                {
                    { 1, true, false, 1, 1, 580, 1362, 206 },
                    { 2, true, false, 1, 2, 580, 1362, 206 },
                    { 7, true, true, 1, 1, 835, 1932, 327 },
                    { 8, false, false, 1, 4, 1021, 2400, 629 },
                    { 3, true, false, 2, 1, 580, 1362, 206 },
                    { 4, true, false, 2, 2, 580, 1362, 206 },
                    { 5, true, false, 2, 3, 580, 1362, 206 },
                    { 6, true, false, 3, 1, 580, 1362, 206 },
                    { 9, false, false, 3, 2, 1021, 2400, 629 },
                    { 10, false, false, 3, 3, 1021, 2400, 629 }
                });

            migrationBuilder.InsertData(
                table: "Diffusions",
                columns: new[] { "id_diffusion", "audLang", "diffusionDate", "diffusionTime", "id_cinemaRoom", "id_movie", "subTitleLang" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 45, 0, 0), 1, 4, null },
                    { 19, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 9, 2, null },
                    { 17, 0, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 9, 2, 1 },
                    { 8, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), 9, 4, null },
                    { 22, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 15, 0, 0), 6, 3, null },
                    { 18, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 6, 2, null },
                    { 7, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 50, 0, 0), 6, 4, null },
                    { 6, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 15, 0, 0), 6, 4, null },
                    { 29, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 15, 0, 0), 5, 5, null },
                    { 28, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 45, 0, 0), 5, 5, null },
                    { 27, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 15, 0, 0), 5, 5, null },
                    { 21, 0, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), 4, 3, 1 },
                    { 20, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 30, 0, 0), 4, 3, null },
                    { 30, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 15, 0, 0), 4, 3, null },
                    { 14, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 3, 1, null },
                    { 13, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 3, 1, null },
                    { 12, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 30, 0, 0), 3, 1, null },
                    { 26, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 45, 0, 0), 8, 5, null },
                    { 25, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 15, 0, 0), 8, 5, null },
                    { 11, 0, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 20, 0, 0, 0), 8, 1, 1 },
                    { 10, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 8, 1, null },
                    { 9, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 30, 0, 0), 8, 1, null },
                    { 5, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 30, 0, 0), 8, 4, null },
                    { 4, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 5, 0, 0), 7, 4, null },
                    { 2, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 30, 0, 0), 7, 4, null },
                    { 16, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 21, 15, 0, 0), 2, 2, null },
                    { 15, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 15, 0, 0), 2, 2, null },
                    { 3, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 50, 0, 0), 1, 4, null },
                    { 23, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 30, 0, 0), 10, 3, null },
                    { 24, 1, new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 15, 0, 0), 10, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaRooms_id_cinemaPlace",
                table: "CinemaRooms",
                column: "id_cinemaPlace");

            migrationBuilder.CreateIndex(
                name: "IX_Diffusions_id_cinemaRoom",
                table: "Diffusions",
                column: "id_cinemaRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Diffusions_id_movie",
                table: "Diffusions",
                column: "id_movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diffusions");

            migrationBuilder.DropTable(
                name: "CinemaRooms");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "CinemaPlaces");
        }
    }
}
