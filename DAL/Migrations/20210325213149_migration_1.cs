using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class migration_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    LabelPhotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Raiting = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    Born = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhotoPath = table.Column<string>(type: "TEXT", nullable: true),
                    Deliverydate = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
