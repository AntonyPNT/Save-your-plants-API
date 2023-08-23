using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class Fixdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HasApprovedTermsAndConditions = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plants_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlantActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_PlantActions_PlantActionId",
                        column: x => x.PlantActionId,
                        principalTable: "PlantActions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "HasApprovedTermsAndConditions", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "28859311-f3d0-4bc5-ac5e-ca5639aed3ae", "admin@imi.be", true, false, false, null, "ADMIN@IMI.BE", "IMIADMIN", "AQAAAAEAACcQAAAAEBS4MuhR1t/ireSQ/se+mOy6nuZSZINoRQHnEoZskOGxOh3iRt2ZiKlMKX7LYYEhhg==", null, false, "2ba7f385-6d1a-425d-969a-129d8430bac5", false, "ImiAdmin" },
                    { "00000000-0000-0000-0000-000000000002", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b73e9cd0-b0dc-4952-9833-a8e2a34249c4", "user@imi.be", true, true, false, null, "USER@IMI.BE", "IMIUSER", "AQAAAAEAACcQAAAAEPCiXRRNFJLJYEa06AIhPsS9mWyxQvRCpGaMt28nznY5vXQ8db7pFjgG8gSHWp1A2Q==", null, false, "5c02f9fa-099b-4086-819b-a16178a1752f", false, "ImiUser" },
                    { "00000000-0000-0000-0000-000000000003", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ac4effc6-388d-448b-9efe-6f1ff5783dd8", "refuser@imi.be", true, false, false, null, "REFUSER@IMI.BE", "IMIREFUSER", "AQAAAAEAACcQAAAAEPFMvFFB+POI4yVGQJxnPevKZXQmoBHYsJQt78T1wTQWZjsjaAGeco8W0NjKRj3lBA==", null, false, "70211367-bd98-43a1-a4a3-bcda62e40d1c", false, "ImiRefuser" },
                    { "00000000-0000-0000-0000-000000000004", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2378fa9b-8c5c-4f35-a033-56aa6b0e3cf1", "antony.p.moreira@gmail.com", true, true, false, null, "ANTONY.P.MOREIRA@GMAIL.COM", "ANTONY.P.MOREIRA@GMAIL.COM", "AQAAAAEAACcQAAAAEFEe27HlrwTagzG8d8vHcciswn0B0w2NqWNWm18bSzXu7fGjh8MCNmq9Z+ujT78PiA==", null, false, "1c890a84-c1c5-4fe2-b72f-441dfb0be875", false, "antony.p.moreira@gmail.com" },
                    { "00000000-0000-0000-0000-000000000005", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "22470416-2fcf-42da-8c24-10461637c57a", "terence.joiris@protonmail.com", true, true, false, null, "TERENCE.JOIRIS@PROTONMAIL.COM", "TERENCE.JOIRIS@PROTONMAIL.COM", "AQAAAAEAACcQAAAAEK6k9gjd+D0VT0qbY3kn5KS3JnMABX7Bif6YcWaZHCrF9fAYSv4O3545lDjlsLVtnw==", null, false, "095d850c-eaf5-4b4c-ab23-270092350740", false, "terence.joiris@protonmail.com" }
                });

            migrationBuilder.InsertData(
                table: "PlantActions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "water" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "fertilize" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "repot" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin", "00000000-0000-0000-0000-000000000001" },
                    { 2, "id", "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001" },
                    { 3, "nickname", "ImiAdmin", "00000000-0000-0000-0000-000000000001" },
                    { 4, "email", "admin@imi.be", "00000000-0000-0000-0000-000000000001" },
                    { 5, "aproved", "False", "00000000-0000-0000-0000-000000000001" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user", "00000000-0000-0000-0000-000000000002" },
                    { 7, "id", "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002" },
                    { 8, "nickname", "ImiUser", "00000000-0000-0000-0000-000000000002" },
                    { 9, "email", "user@imi.be", "00000000-0000-0000-0000-000000000002" },
                    { 10, "aproved", "True", "00000000-0000-0000-0000-000000000002" },
                    { 11, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "user", "00000000-0000-0000-0000-000000000003" },
                    { 12, "id", "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000003" },
                    { 13, "nickname", "ImiRefuser", "00000000-0000-0000-0000-000000000003" },
                    { 14, "email", "refuser@imi.be", "00000000-0000-0000-0000-000000000003" },
                    { 15, "aproved", "False", "00000000-0000-0000-0000-000000000003" },
                    { 16, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin", "00000000-0000-0000-0000-000000000004" },
                    { 17, "id", "00000000-0000-0000-0000-000000000004", "00000000-0000-0000-0000-000000000004" },
                    { 18, "nickname", "antony.p.moreira@gmail.com", "00000000-0000-0000-0000-000000000004" },
                    { 19, "email", "antony.p.moreira@gmail.com", "00000000-0000-0000-0000-000000000004" },
                    { 20, "aproved", "True", "00000000-0000-0000-0000-000000000004" },
                    { 21, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin", "00000000-0000-0000-0000-000000000005" },
                    { 22, "id", "00000000-0000-0000-0000-000000000005", "00000000-0000-0000-0000-000000000005" },
                    { 23, "nickname", "terence.joiris@protonmail.com", "00000000-0000-0000-0000-000000000005" },
                    { 24, "email", "terence.joiris@protonmail.com", "00000000-0000-0000-0000-000000000005" },
                    { 25, "aproved", "True", "00000000-0000-0000-0000-000000000005" }
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "ApplicationUserId", "Condition", "DateOfPurchase", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1333), "images/plant/Anthurium.jpg", "Anthurium" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000001", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1368), "images/plant/Bamboo.jpg", "Lucky-Bamboo" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000001", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1372), "images/plant/Croton.jpg", "Croton" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000002", "Unhealthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1375), "images/plant/Dracaena.jpg", "Dracaena" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "00000000-0000-0000-0000-000000000002", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1378), "images/plant/Dracaena-Marginata.jpg", "Dracaena-Marginata" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "00000000-0000-0000-0000-000000000002", "Unhealthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1381), "images/plant/Orchid.jpg", "Orchid" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "00000000-0000-0000-0000-000000000003", "Unhealthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1384), "images/plant/Peace-Lily.jpg", "Peace-Lily" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "00000000-0000-0000-0000-000000000003", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1387), "images/plant/Ponytail.jpg", "Ponytail" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "00000000-0000-0000-0000-000000000004", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1389), "images/plant/Pothos.jpg", "Pothos" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "00000000-0000-0000-0000-000000000004", "Healthy", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1392), "images/plant/Snake-Plant.jpg", "Snake-Plant" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ApplicationUserId", "Date", "PlantActionId", "PlantId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "00000000-0000-0000-0000-000000000001", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1443), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "00000000-0000-0000-0000-000000000001", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1449), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "00000000-0000-0000-0000-000000000001", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1453), new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "00000000-0000-0000-0000-000000000002", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1457), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000004") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "00000000-0000-0000-0000-000000000002", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1461), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000005") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "00000000-0000-0000-0000-000000000002", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1465), new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000006") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "00000000-0000-0000-0000-000000000003", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1469), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000007") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "00000000-0000-0000-0000-000000000003", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1473), new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000008") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "00000000-0000-0000-0000-000000000004", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1476), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000009") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "00000000-0000-0000-0000-000000000004", new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1480), new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000010") }
                });

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
                name: "IX_Plants_ApplicationUserId",
                table: "Plants",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ApplicationUserId",
                table: "Schedules",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PlantActionId",
                table: "Schedules",
                column: "PlantActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PlantId",
                table: "Schedules",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PlantActions");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
