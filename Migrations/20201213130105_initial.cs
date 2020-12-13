using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace NTR20Z.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classgroup",
                columns: table => new
                {
                    classgroupID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classgroup", x => x.classgroupID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    roomID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.roomID);
                });

            migrationBuilder.CreateTable(
                name: "Slot",
                columns: table => new
                {
                    slotID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slot", x => x.slotID);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subjectID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.subjectID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherID);
                });

            migrationBuilder.CreateTable(
                name: "ActivityBis",
                columns: table => new
                {
                    activityID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    teacherID = table.Column<int>(nullable: true),
                    subjectID = table.Column<int>(nullable: true),
                    classgroupID = table.Column<int>(nullable: true),
                    roomID = table.Column<int>(nullable: true),
                    slotID = table.Column<int>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityBis", x => x.activityID);
                    table.ForeignKey(
                        name: "FK_ActivityBis_Classgroup_classgroupID",
                        column: x => x.classgroupID,
                        principalTable: "Classgroup",
                        principalColumn: "classgroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityBis_Room_roomID",
                        column: x => x.roomID,
                        principalTable: "Room",
                        principalColumn: "roomID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityBis_Slot_slotID",
                        column: x => x.slotID,
                        principalTable: "Slot",
                        principalColumn: "slotID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityBis_Subject_subjectID",
                        column: x => x.subjectID,
                        principalTable: "Subject",
                        principalColumn: "subjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityBis_Teacher_teacherID",
                        column: x => x.teacherID,
                        principalTable: "Teacher",
                        principalColumn: "teacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBis_classgroupID",
                table: "ActivityBis",
                column: "classgroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBis_roomID",
                table: "ActivityBis",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBis_slotID",
                table: "ActivityBis",
                column: "slotID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBis_subjectID",
                table: "ActivityBis",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityBis_teacherID",
                table: "ActivityBis",
                column: "teacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityBis");

            migrationBuilder.DropTable(
                name: "Classgroup");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Slot");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
