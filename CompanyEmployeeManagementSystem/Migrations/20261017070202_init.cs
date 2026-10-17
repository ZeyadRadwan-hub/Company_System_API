using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployeeManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    SartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Cairo", "Software Development" },
                    { 2, "Giza", "Human Resources" },
                    { 3, "Alexandria", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "EmailAddress", "FullName", "HireDate", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "ahmed@company.com", "Ahmed Mohamed", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12000 },
                    { 2, 1, "omar@company.com", "Omar Ali", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000 },
                    { 3, 1, "mona@company.com", "Mona Hassan", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11000 },
                    { 4, 2, "sara@company.com", "Sara Ahmed", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9000 },
                    { 5, 2, "youssef@company.com", "Youssef Samir", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 10000 },
                    { 6, 3, "nour@company.com", "Nour Khaled", new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000 },
                    { 7, 3, "ali@company.com", "Ali Mahmoud", new DateTime(2021, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000 },
                    { 8, 1, "salma@company.com", "Salma Tarek", new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 14000 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "DepartmentId", "Description", "Name", "SartDate" },
                values: new object[,]
                {
                    { 1, 150000, 1, "Develop the company website", "Company Website", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 250000, 1, "Internal employee management portal", "Employee Portal", new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 80000, 2, "Manage recruitment processes", "Recruitment System", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 200000, 3, "Financial reports and analytics", "Financial Dashboard", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "Id", "AssignedDate", "AssignedRole", "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backend Developer", 1, 1 },
                    { 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frontend Developer", 2, 1 },
                    { 3, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Database Developer", 3, 2 },
                    { 4, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR Specialist", 4, 3 },
                    { 5, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Financial Analyst", 6, 4 },
                    { 6, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Manager", 7, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId_ProjectId",
                table: "EmployeeProjects",
                columns: new[] { "EmployeeId", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
