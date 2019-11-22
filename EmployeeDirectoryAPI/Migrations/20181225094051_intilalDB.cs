using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeDirectoryAPI.Migrations
{
    public partial class intilalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthdayMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MessageData = table.Column<string>(maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthdayMessages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MobNumberOff = table.Column<int>(maxLength: 10, nullable: false),
                    MobNumberPersonal = table.Column<int>(maxLength: 10, nullable: false),
                    SkypeID = table.Column<string>(maxLength: 30, nullable: false),
                    SlackID = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    FBLink = table.Column<string>(nullable: true),
                    TwitterLink = table.Column<string>(nullable: true),
                    GitHubLink = table.Column<string>(nullable: true),
                    linkdinLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDetails",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(maxLength: 20, nullable: false),
                    DepartmentDiscription = table.Column<string>(maxLength: 100, nullable: true),
                    DepartmentHeadName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDetails", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBiographies",
                columns: table => new
                {
                    BioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(maxLength: 100, nullable: false),
                    Hobbies = table.Column<string>(maxLength: 100, nullable: true),
                    Interests = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBiographies", x => x.BioId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "EventsDetails",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Venu = table.Column<string>(maxLength: 150, nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventFromTime = table.Column<DateTime>(nullable: false),
                    EventToTime = table.Column<DateTime>(nullable: false),
                    EventTimeZone = table.Column<string>(nullable: true),
                    Organizer = table.Column<string>(maxLength: 50, nullable: false),
                    EventName = table.Column<string>(maxLength: 20, nullable: false),
                    EvenPhotoURL = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsDetails", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                });

            migrationBuilder.CreateTable(
                name: "TeamDetails",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(maxLength: 20, nullable: false),
                    TeamLeadName = table.Column<string>(maxLength: 20, nullable: true),
                    TeamDiscription = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDetails", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Dob = table.Column<DateTime>(maxLength: 10, nullable: false),
                    EmployeePhotoURL = table.Column<string>(maxLength: 300, nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<int>(maxLength: 20, nullable: false),
                    DepartmentId = table.Column<int>(nullable: true),
                    TeamID = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: false),
                    BioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeBiographies_BioId",
                        column: x => x.BioId,
                        principalTable: "EmployeeBiographies",
                        principalColumn: "BioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_ContactDetails_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_DepartmentDetails_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentDetails",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EmployeeRoles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_TeamDetails_TeamID",
                        column: x => x.TeamID,
                        principalTable: "TeamDetails",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillId = table.Column<int>(nullable: false),
                    SkillLevel = table.Column<string>(maxLength: 50, nullable: true),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BioId",
                table: "Employees",
                column: "BioId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactId",
                table: "Employees",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TeamID",
                table: "Employees",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_SkillId",
                table: "EmployeeSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthdayMessages");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EventsDetails");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "EmployeeBiographies");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "DepartmentDetails");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DropTable(
                name: "TeamDetails");
        }
    }
}
