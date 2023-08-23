using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class Addbooleantoschedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Schedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "962f198d-5cf0-4182-bc6c-18c43f366fde", "AQAAAAEAACcQAAAAEMI/wNxOS2EM8YmwXaNcYvrHrhUDQEpJ9VB0n+ET6LUf9sN/qPDnAAEm9SqLhum+Mg==", "094735ab-d9b7-4fbc-a025-c90c01efc343" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b46bd05-28bb-495a-a214-91840eff8a16", "AQAAAAEAACcQAAAAEN6cu18AXAl7Ke8Jxe10LsgEwysq3/zAALajTOyWzd9T/d+fLzoZOBlLeMAEte7qdg==", "ae6945e1-35a1-481e-ad9f-9bb2c986a66b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f107f341-1e0b-4f5e-b079-0b9e518ea6cf", "AQAAAAEAACcQAAAAENlOiZtnrTNLcC60kjOGdm2mqD1RGkMtvagSJATM1pSRV+cybQm+r1PKmET4HZtHJw==", "b8cf9852-a7c7-4dd9-8872-e520401de4da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d65b376e-8ed7-4c2d-8dc7-eb1373fb6b62", "AQAAAAEAACcQAAAAEAISlbQMKXPzXbeyh0iG9SD6LC1aXQUy1MrPD9j8mfTJxNA974tJrLiYcsSRP8QX3A==", "0c41754d-4ba7-45a7-8775-c90ffde3353d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04f38ff6-4dc3-4747-a849-022cbe9419ef", "AQAAAAEAACcQAAAAEPv2YLll51WFJabW4M5TpoAw7v60TiYrP98SJDMhdxu882lh2Y8EfBi3uaoohFCEZg==", "30fe9e46-f1f8-4b03-afbb-79802dd04c05" });

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2634));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2638));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2655));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2657));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2715));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2719));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2732));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2743));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "Date",
                value: new DateTime(2023, 1, 12, 23, 11, 19, 78, DateTimeKind.Local).AddTicks(2751));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28859311-f3d0-4bc5-ac5e-ca5639aed3ae", "AQAAAAEAACcQAAAAEBS4MuhR1t/ireSQ/se+mOy6nuZSZINoRQHnEoZskOGxOh3iRt2ZiKlMKX7LYYEhhg==", "2ba7f385-6d1a-425d-969a-129d8430bac5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b73e9cd0-b0dc-4952-9833-a8e2a34249c4", "AQAAAAEAACcQAAAAEPCiXRRNFJLJYEa06AIhPsS9mWyxQvRCpGaMt28nznY5vXQ8db7pFjgG8gSHWp1A2Q==", "5c02f9fa-099b-4086-819b-a16178a1752f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac4effc6-388d-448b-9efe-6f1ff5783dd8", "AQAAAAEAACcQAAAAEPFMvFFB+POI4yVGQJxnPevKZXQmoBHYsJQt78T1wTQWZjsjaAGeco8W0NjKRj3lBA==", "70211367-bd98-43a1-a4a3-bcda62e40d1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2378fa9b-8c5c-4f35-a033-56aa6b0e3cf1", "AQAAAAEAACcQAAAAEFEe27HlrwTagzG8d8vHcciswn0B0w2NqWNWm18bSzXu7fGjh8MCNmq9Z+ujT78PiA==", "1c890a84-c1c5-4fe2-b72f-441dfb0be875" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22470416-2fcf-42da-8c24-10461637c57a", "AQAAAAEAACcQAAAAEK6k9gjd+D0VT0qbY3kn5KS3JnMABX7Bif6YcWaZHCrF9fAYSv4O3545lDjlsLVtnw==", "095d850c-eaf5-4b4c-ab23-270092350740" });

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1372));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1375));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1381));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "Plants",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "DateOfPurchase",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1392));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1476));

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                column: "Date",
                value: new DateTime(2023, 1, 4, 12, 13, 46, 240, DateTimeKind.Local).AddTicks(1480));
        }
    }
}
