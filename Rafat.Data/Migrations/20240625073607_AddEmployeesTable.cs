using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rafat.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPromotionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentDegree = table.Column<int>(type: "int", nullable: false),
                    CurrentStage = table.Column<int>(type: "int", nullable: false),
                    CurrentSalary = table.Column<float>(type: "real", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextDegree = table.Column<int>(type: "int", nullable: false),
                    NextStage = table.Column<int>(type: "int", nullable: false),
                    NextSalary = table.Column<float>(type: "real", nullable: false),
                    NextDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
