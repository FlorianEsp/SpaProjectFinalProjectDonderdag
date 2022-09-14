using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpaProjectFinalProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdoptionCenter",
                columns: table => new
                {
                    AdoptionCenterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionCenter", x => x.AdoptionCenterId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsVaccinated = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    NamePath = table.Column<string>(nullable: true),
                    Terms = table.Column<bool>(nullable: false),
                    IsLost = table.Column<bool>(nullable: false),
                    AdoptionCenterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animal_AdoptionCenter_AdoptionCenterId",
                        column: x => x.AdoptionCenterId,
                        principalTable: "AdoptionCenter",
                        principalColumn: "AdoptionCenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    AnimalId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    HaveAnimal = table.Column<bool>(nullable: false),
                    PostCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    AnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Persons_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animal",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalsLost",
                columns: table => new
                {
                    AnimalLostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalLostName = table.Column<string>(nullable: true),
                    AnimalLostDescription = table.Column<string>(nullable: true),
                    DateLost = table.Column<DateTime>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    NamePath = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalsLost", x => x.AnimalLostId);
                    table.ForeignKey(
                        name: "FK_AnimalsLost_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdoptionCenter",
                columns: new[] { "AdoptionCenterId", "Name", "PhoneNumber", "Place", "PostCode", "Rate" },
                values: new object[,]
                {
                    { 1, "Moeskroen DierenAsiel", "05645555", "Moeskroen", "8000", 3 },
                    { 2, "Brussel DierenAsiel", "056789345", "Brussel", "8000", 3 },
                    { 3, "Antwerpen DierenAsiel", "04262722", "Antwerpen", "8000", 3 },
                    { 4, "Luik DierenAsiel", "0468787976", "Luik", "8000", 3 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Address", "Age", "AnimalId", "Email", "Gender", "HaveAnimal", "Name", "Number", "PostCode" },
                values: new object[,]
                {
                    { 1, "Kortrijk", 22, null, "Florian@", false, false, "Florian", "0492535211", "8587" },
                    { 2, "Moeskroen", 20, null, "celia@", true, false, "Celia", "056457176", "7700" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "AnimalId", "AdoptionCenterId", "BirthDate", "Description", "IsLost", "IsVaccinated", "Name", "NamePath", "Path", "Race", "Terms" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(925), "Beautiful Dog", false, true, "Iris", "Iris.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Iris.jpg", "Shepherd", false },
                    { 6, 1, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2732), "Beautiful Rabbit", false, true, "Walter", "Rabbit3.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Rabbit3.jpg", "Rabbit", false },
                    { 10, 1, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2740), "Beautiful Cat", false, true, "Ibrahim", "Cat4.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Cat4.jpg", "Cat", false },
                    { 2, 2, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2679), "Beautiful Dog", false, true, "Ultia", "Dog2.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Dog2.jpg", "Bulldog", false },
                    { 5, 2, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2731), "Beautiful Rabbit", false, true, "Sasuke", "Rabbit2.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Rabbit2.jpg", "Rabbit", false },
                    { 9, 2, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2738), "Beautiful Cat", false, true, "Ibrahim", "Cat3.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Cat3.jpg", "Cat", false },
                    { 3, 3, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2726), "Beautiful Dog", false, true, "Gon", "Dog3.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Dog3.jpg", "Golden retriever", false },
                    { 8, 3, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2736), "Beautiful Cat", false, true, "Ibrahim", "Cat2.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Cat2.jpg", "Cat", false },
                    { 4, 4, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2728), "Beautiful Rabbit", false, true, "Lea", "Rabbit1.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Rabbit1.jpg", "Rabbit", false },
                    { 7, 4, new DateTime(2022, 9, 14, 16, 28, 15, 472, DateTimeKind.Utc).AddTicks(2734), "Beautiful Cat", false, true, "Snowball", "Zaho.jpg", "C:\\Users\\florian\\source\\repos\\SpaProject\\SpaProject\\wwwroot\\images\\Zaho.jpg", "Cat", false }
                });

            migrationBuilder.InsertData(
                table: "AnimalsLost",
                columns: new[] { "AnimalLostId", "AnimalLostDescription", "AnimalLostName", "DateLost", "NamePath", "Path", "PersonId" },
                values: new object[,]
                {
                    { 1, "IsLost", "iris", new DateTime(2022, 9, 14, 18, 28, 15, 472, DateTimeKind.Local).AddTicks(6238), "LostDog.jpg", "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostDog.jpg", 1 },
                    { 2, "IsLost", "iris", new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4687), "LostRabbit.jpg", "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostRabbit.jpg", 1 },
                    { 3, "IsLost", "iris", new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4748), "Lostrabbit2.jpg", "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostRabbit2.jpg", 1 },
                    { 4, "IsLost", "iris", new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4754), "LostRabbit3.jpg", "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostRabbit3.jpg", 1 },
                    { 5, "IsLost", "iris", new DateTime(2022, 9, 14, 18, 28, 15, 475, DateTimeKind.Local).AddTicks(4757), "LostDog.jpg", "C:\\Intec\\Data\\SpaProjectFinalProjectcsss-master\\wwwroot\\images\\LostDog.jpg", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AdoptionCenterId",
                table: "Animal",
                column: "AdoptionCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalsLost_PersonId",
                table: "AnimalsLost",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_AnimalId",
                table: "Event",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserId",
                table: "Event",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_AnimalId",
                table: "Persons",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalsLost");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "AdoptionCenter");
        }
    }
}
