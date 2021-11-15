using Microsoft.EntityFrameworkCore.Migrations;

namespace InfrastructureNew.Migrations.EFApplicationDB
{
    public partial class Applications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Applications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "service_id",
                table: "Applications",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "petsitter_id",
                table: "Applications",
                newName: "PetsitterId");

            migrationBuilder.RenameColumn(
                name: "pet_id",
                table: "Applications",
                newName: "PetId");

            migrationBuilder.AddColumn<long>(
                name: "PetId1",
                table: "Applications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PetsitterId1",
                table: "Applications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId1",
                table: "Applications",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MyPetsitter",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPetsitter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PetId1",
                table: "Applications",
                column: "PetId1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PetsitterId1",
                table: "Applications",
                column: "PetsitterId1");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ServiceId1",
                table: "Applications",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_UserId1",
                table: "Pet",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_MyPetsitter_PetsitterId1",
                table: "Applications",
                column: "PetsitterId1",
                principalTable: "MyPetsitter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Pet_PetId1",
                table: "Applications",
                column: "PetId1",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Service_ServiceId1",
                table: "Applications",
                column: "ServiceId1",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_MyPetsitter_PetsitterId1",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Pet_PetId1",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Service_ServiceId1",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "MyPetsitter");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Applications_PetId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_PetsitterId1",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ServiceId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PetId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "PetsitterId1",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applications",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Applications",
                newName: "service_id");

            migrationBuilder.RenameColumn(
                name: "PetsitterId",
                table: "Applications",
                newName: "petsitter_id");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Applications",
                newName: "pet_id");
        }
    }
}
