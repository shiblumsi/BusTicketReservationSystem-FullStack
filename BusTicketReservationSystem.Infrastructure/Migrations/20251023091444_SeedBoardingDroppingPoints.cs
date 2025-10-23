using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusTicketReservationSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedBoardingDroppingPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("004e04e9-c500-463c-b7c7-a7689668087b"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("08e5357f-a6ec-4bc2-ad55-72432f78a685"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("0d23cb7a-96c8-4139-9f24-e7a795ce6f8b"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("11873860-8082-4a79-8a87-0de9924654fb"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("190ed106-f5d8-4eaa-9145-464d256fed44"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("194b4e2b-fdb8-4fdc-be9a-be94f3d1c8a4"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("2dd89684-b8f3-43e3-83f4-1ed853d5bd76"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("3374c84b-e6df-4e5e-9178-fbfb6925889f"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("36eadfe1-53b7-4197-8db4-027a3c042664"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("3734d666-8c69-4ff2-86f8-311c6375cae5"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("3cffd3e9-a7d9-4c66-a40a-ad5f71e83149"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("408aaed3-e328-4342-9245-59d6cb0a411e"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("503647da-6a8c-443d-941e-5736e6ece010"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("5441e920-fc1d-452a-b302-c62fc2f6e43a"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("6e5d2ca7-3270-4a26-bb67-42a9f9b057b0"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("76b9f27c-4957-403b-8fcc-1d84ca7f0bd2"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("76db79fc-fa22-4820-97df-2f2ff90f4667"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("94956b63-08d7-4e61-b1c6-ded6ea2488d0"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("bc79328f-02a0-404e-8645-4a5fd571a48c"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("cd0bac18-d205-4055-b3ab-eeff0a4b8d31"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("dd38849d-f09c-4260-ace4-5d7a32f23ffc"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("e3548961-145d-474c-915d-e4935e5588c0"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("f1d9eb04-7aa7-45f2-b693-767e803de199"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("fd9dbe5c-39d9-4f44-8f03-85be3d5182b8"));

            migrationBuilder.InsertData(
                table: "BoardingDroppings",
                columns: new[] { "Id", "CityName", "PointName", "Type" },
                values: new object[,]
                {
                    { new Guid("aaaa0001-1111-2222-3333-abcdef000001"), "Dhaka", "Uttara", 0 },
                    { new Guid("aaaa0002-1111-2222-3333-abcdef000002"), "Dhaka", "Mirpur-10", 0 },
                    { new Guid("aaaa0003-1111-2222-3333-abcdef000003"), "Dhaka", "Mohakhali", 1 },
                    { new Guid("aaaa0004-1111-2222-3333-abcdef000004"), "Dhaka", "Kakrail", 1 },
                    { new Guid("aaaa0005-1111-2222-3333-abcdef000005"), "Dhaka", "Gabtoli", 2 },
                    { new Guid("aaaa0006-1111-2222-3333-abcdef000006"), "Dhaka", "Kallyanpur", 2 },
                    { new Guid("aaaa0007-1111-2222-3333-abcdef000007"), "Dhaka", "Abdullahpur", 2 },
                    { new Guid("aaaa0008-1111-2222-3333-abcdef000008"), "Dhaka", "Syedabad", 2 },
                    { new Guid("aaaa0009-1111-2222-3333-abcdef000009"), "Dhaka", "Arambagh", 2 },
                    { new Guid("bbbb0001-1111-2222-3333-abcdef000001"), "Cox's Bazar", "Dolphin Mor", 0 },
                    { new Guid("bbbb0002-1111-2222-3333-abcdef000002"), "Cox's Bazar", "Kolatoli", 0 },
                    { new Guid("bbbb0003-1111-2222-3333-abcdef000003"), "Cox's Bazar", "Laboni Beach", 1 },
                    { new Guid("bbbb0004-1111-2222-3333-abcdef000004"), "Cox's Bazar", "Sugandha Beach", 1 },
                    { new Guid("bbbb0005-1111-2222-3333-abcdef000005"), "Cox's Bazar", "Inani", 2 },
                    { new Guid("cccc0001-1111-2222-3333-abcdef000001"), "Sylhet", "Ambarkhana", 0 },
                    { new Guid("cccc0002-1111-2222-3333-abcdef000002"), "Sylhet", "Shibgonj", 0 },
                    { new Guid("cccc0003-1111-2222-3333-abcdef000003"), "Sylhet", "Zindabazar", 1 },
                    { new Guid("cccc0004-1111-2222-3333-abcdef000004"), "Sylhet", "Mirabazar", 1 },
                    { new Guid("cccc0005-1111-2222-3333-abcdef000005"), "Sylhet", "Kamalbazar", 2 },
                    { new Guid("dddd0001-1111-2222-3333-abcdef000001"), "Khulna", "Khalishpur", 0 },
                    { new Guid("dddd0002-1111-2222-3333-abcdef000002"), "Khulna", "Sonadanga", 0 },
                    { new Guid("dddd0003-1111-2222-3333-abcdef000003"), "Khulna", "Daulatpur", 1 },
                    { new Guid("dddd0004-1111-2222-3333-abcdef000004"), "Khulna", "Teligati", 1 },
                    { new Guid("dddd0005-1111-2222-3333-abcdef000005"), "Khulna", "Khan Jahan Ali", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0001-1111-2222-3333-abcdef000001"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0002-1111-2222-3333-abcdef000002"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0003-1111-2222-3333-abcdef000003"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0004-1111-2222-3333-abcdef000004"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0005-1111-2222-3333-abcdef000005"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0006-1111-2222-3333-abcdef000006"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0007-1111-2222-3333-abcdef000007"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0008-1111-2222-3333-abcdef000008"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("aaaa0009-1111-2222-3333-abcdef000009"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("bbbb0001-1111-2222-3333-abcdef000001"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("bbbb0002-1111-2222-3333-abcdef000002"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("bbbb0003-1111-2222-3333-abcdef000003"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("bbbb0004-1111-2222-3333-abcdef000004"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("bbbb0005-1111-2222-3333-abcdef000005"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("cccc0001-1111-2222-3333-abcdef000001"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("cccc0002-1111-2222-3333-abcdef000002"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("cccc0003-1111-2222-3333-abcdef000003"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("cccc0004-1111-2222-3333-abcdef000004"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("cccc0005-1111-2222-3333-abcdef000005"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("dddd0001-1111-2222-3333-abcdef000001"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("dddd0002-1111-2222-3333-abcdef000002"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("dddd0003-1111-2222-3333-abcdef000003"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("dddd0004-1111-2222-3333-abcdef000004"));

            migrationBuilder.DeleteData(
                table: "BoardingDroppings",
                keyColumn: "Id",
                keyValue: new Guid("dddd0005-1111-2222-3333-abcdef000005"));

            migrationBuilder.InsertData(
                table: "BoardingDroppings",
                columns: new[] { "Id", "CityName", "PointName", "Type" },
                values: new object[,]
                {
                    { new Guid("004e04e9-c500-463c-b7c7-a7689668087b"), "Dhaka", "Mirpur-10", 0 },
                    { new Guid("08e5357f-a6ec-4bc2-ad55-72432f78a685"), "Dhaka", "Mohakhali", 1 },
                    { new Guid("0d23cb7a-96c8-4139-9f24-e7a795ce6f8b"), "Dhaka", "Arambagh", 2 },
                    { new Guid("11873860-8082-4a79-8a87-0de9924654fb"), "Khulna", "Khan Jahan Ali", 2 },
                    { new Guid("190ed106-f5d8-4eaa-9145-464d256fed44"), "Sylhet", "Kamalbazar", 2 },
                    { new Guid("194b4e2b-fdb8-4fdc-be9a-be94f3d1c8a4"), "Sylhet", "Mirabazar", 1 },
                    { new Guid("2dd89684-b8f3-43e3-83f4-1ed853d5bd76"), "Sylhet", "Ambarkhana", 0 },
                    { new Guid("3374c84b-e6df-4e5e-9178-fbfb6925889f"), "Khulna", "Daulatpur", 1 },
                    { new Guid("36eadfe1-53b7-4197-8db4-027a3c042664"), "Dhaka", "Uttara", 0 },
                    { new Guid("3734d666-8c69-4ff2-86f8-311c6375cae5"), "Dhaka", "Syedabad", 2 },
                    { new Guid("3cffd3e9-a7d9-4c66-a40a-ad5f71e83149"), "Khulna", "Sonadanga", 0 },
                    { new Guid("408aaed3-e328-4342-9245-59d6cb0a411e"), "Khulna", "Teligati", 1 },
                    { new Guid("503647da-6a8c-443d-941e-5736e6ece010"), "Sylhet", "Shibgonj", 0 },
                    { new Guid("5441e920-fc1d-452a-b302-c62fc2f6e43a"), "Dhaka", "Gabtoli", 2 },
                    { new Guid("6e5d2ca7-3270-4a26-bb67-42a9f9b057b0"), "Khulna", "Khalishpur", 0 },
                    { new Guid("76b9f27c-4957-403b-8fcc-1d84ca7f0bd2"), "Cox's Bazar", "Laboni Beach", 1 },
                    { new Guid("76db79fc-fa22-4820-97df-2f2ff90f4667"), "Cox's Bazar", "Inani", 2 },
                    { new Guid("94956b63-08d7-4e61-b1c6-ded6ea2488d0"), "Dhaka", "Abdullahpur", 2 },
                    { new Guid("bc79328f-02a0-404e-8645-4a5fd571a48c"), "Cox's Bazar", "Kolatoli", 0 },
                    { new Guid("cd0bac18-d205-4055-b3ab-eeff0a4b8d31"), "Cox's Bazar", "Sugandha Beach", 1 },
                    { new Guid("dd38849d-f09c-4260-ace4-5d7a32f23ffc"), "Cox's Bazar", "Dolphin Mor", 0 },
                    { new Guid("e3548961-145d-474c-915d-e4935e5588c0"), "Sylhet", "Zindabazar", 1 },
                    { new Guid("f1d9eb04-7aa7-45f2-b693-767e803de199"), "Dhaka", "Kallyanpur", 2 },
                    { new Guid("fd9dbe5c-39d9-4f44-8f03-85be3d5182b8"), "Dhaka", "Kakrail", 1 }
                });
        }
    }
}
