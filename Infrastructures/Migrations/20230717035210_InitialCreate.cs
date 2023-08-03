using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    accountid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    username = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    hashPassword = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    birthday = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    lastName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    language = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.accountid);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminId);
                    table.ForeignKey(
                        name: "FK__Admin__accountid__3E52440B",
                        column: x => x.accountid,
                        principalTable: "Account",
                        principalColumn: "accountid");
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    candidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    accountid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.candidateId);
                    table.ForeignKey(
                        name: "FK__Candidate__accou__412EB0B6",
                        column: x => x.accountid,
                        principalTable: "Account",
                        principalColumn: "accountid");
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    size = table.Column<int>(type: "int", nullable: true),
                    foundingYear = table.Column<DateTime>(type: "date", nullable: true),
                    logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    benefits = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    industry = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    website = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    contactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameCompany = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    accountid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyId);
                    table.ForeignKey(
                        name: "FK__Company__account__3B75D760",
                        column: x => x.accountid,
                        principalTable: "Account",
                        principalColumn: "accountid");
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    cvID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    creationDate = table.Column<DateTime>(type: "date", nullable: false),
                    urlFile = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    candidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.cvID);
                    table.ForeignKey(
                        name: "FK__CV__candidateId__52593CB8",
                        column: x => x.candidateId,
                        principalTable: "Candidate",
                        principalColumn: "candidateId");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    startEvent = table.Column<DateTime>(type: "date", nullable: false),
                    endEvent = table.Column<DateTime>(type: "date", nullable: false),
                    description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    img = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    candidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.eventId);
                    table.ForeignKey(
                        name: "FK__Event__candidate__4F7CD00D",
                        column: x => x.candidateId,
                        principalTable: "Candidate",
                        principalColumn: "candidateId");
                    table.ForeignKey(
                        name: "FK__Event__companyId__4E88ABD4",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    jobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    nameSkill = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.jobId);
                    table.ForeignKey(
                        name: "FK__Job__companyId__4BAC3F29",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    positionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    namePosition = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.positionId);
                    table.ForeignKey(
                        name: "FK_Position_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                });

            migrationBuilder.CreateTable(
                name: "HR",
                columns: table => new
                {
                    hrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameHr = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    positionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    accountid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR", x => x.hrId);
                    table.ForeignKey(
                        name: "FK__HR__accountid__5629CD9C",
                        column: x => x.accountid,
                        principalTable: "Account",
                        principalColumn: "accountid");
                    table.ForeignKey(
                        name: "FK__HR__companyId__571DF1D5",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                    table.ForeignKey(
                        name: "FK__HR__positionId__5535A963",
                        column: x => x.positionId,
                        principalTable: "Position",
                        principalColumn: "positionId");
                });

            migrationBuilder.CreateTable(
                name: "Interviewer",
                columns: table => new
                {
                    interviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameInterviewer = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    positionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    accountid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewer", x => x.interviewerId);
                    table.ForeignKey(
                        name: "FK__Interview__accou__47DBAE45",
                        column: x => x.accountid,
                        principalTable: "Account",
                        principalColumn: "accountid");
                    table.ForeignKey(
                        name: "FK__Interview__compa__48CFD27E",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                    table.ForeignKey(
                        name: "FK__Interview__posit__46E78A0C",
                        column: x => x.positionId,
                        principalTable: "Position",
                        principalColumn: "positionId");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    postId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    periodDate = table.Column<DateTime>(type: "date", nullable: false),
                    expiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    employmentType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    requirements = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    jobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.postId);
                    table.ForeignKey(
                        name: "FK__Post__companyId__59FA5E80",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                    table.ForeignKey(
                        name: "FK__Post__hrId__5BE2A6F2",
                        column: x => x.hrId,
                        principalTable: "HR",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK__Post__jobId__5AEE82B9",
                        column: x => x.jobId,
                        principalTable: "Job",
                        principalColumn: "jobId");
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    operationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    cvID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    postId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.operationId);
                    table.ForeignKey(
                        name: "FK__Operation__compa__6383C8BA",
                        column: x => x.companyId,
                        principalTable: "Company",
                        principalColumn: "companyId");
                    table.ForeignKey(
                        name: "FK__Operation__cvID__619B8048",
                        column: x => x.cvID,
                        principalTable: "CV",
                        principalColumn: "cvID");
                    table.ForeignKey(
                        name: "FK__Operation__hrId__6477ECF3",
                        column: x => x.hrId,
                        principalTable: "HR",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK__Operation__postI__628FA481",
                        column: x => x.postId,
                        principalTable: "Post",
                        principalColumn: "postId");
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    meetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    linkMeet = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    startTime = table.Column<DateTime>(type: "date", nullable: false),
                    endTime = table.Column<DateTime>(type: "date", nullable: false),
                    operationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    interviewerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    hrId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Meeting__0ED7DF1BCFB2BFA1", x => x.meetID);
                    table.ForeignKey(
                        name: "FK__Meeting__hrId__693CA210",
                        column: x => x.hrId,
                        principalTable: "HR",
                        principalColumn: "hrId");
                    table.ForeignKey(
                        name: "FK__Meeting__intervi__68487DD7",
                        column: x => x.interviewerId,
                        principalTable: "Interviewer",
                        principalColumn: "interviewerId");
                    table.ForeignKey(
                        name: "FK__Meeting__operati__6754599E",
                        column: x => x.operationId,
                        principalTable: "Operation",
                        principalColumn: "operationId");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Account__AB6E6164F3C8BD9A",
                table: "Account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Account__F3DBC57293F3B493",
                table: "Account",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_accountid",
                table: "Admin",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_accountid",
                table: "Candidate",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_Company_accountid",
                table: "Company",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_CV_candidateId",
                table: "CV",
                column: "candidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_candidateId",
                table: "Event",
                column: "candidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_companyId",
                table: "Event",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_accountid",
                table: "HR",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_HR_companyId",
                table: "HR",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_HR_positionId",
                table: "HR",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewer_accountid",
                table: "Interviewer",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewer_companyId",
                table: "Interviewer",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewer_positionId",
                table: "Interviewer",
                column: "positionId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_companyId",
                table: "Job",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_hrId",
                table: "Meeting",
                column: "hrId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_interviewerId",
                table: "Meeting",
                column: "interviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_operationId",
                table: "Meeting",
                column: "operationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_companyId",
                table: "Operation",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_cvID",
                table: "Operation",
                column: "cvID");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_hrId",
                table: "Operation",
                column: "hrId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_postId",
                table: "Operation",
                column: "postId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_CompanyId",
                table: "Position",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_companyId",
                table: "Post",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_hrId",
                table: "Post",
                column: "hrId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_jobId",
                table: "Post",
                column: "jobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Interviewer");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "HR");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
