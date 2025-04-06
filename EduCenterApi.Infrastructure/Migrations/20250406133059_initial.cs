using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduCenterApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    father_phone = table.Column<string>(type: "text", nullable: true),
                    mother_phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "centers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    admin_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centers", x => x.id);
                    table.ForeignKey(
                        name: "FK_centers_users_admin_id",
                        column: x => x.admin_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sinces",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    center_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sinces", x => x.id);
                    table.ForeignKey(
                        name: "FK_sinces_centers_center_id",
                        column: x => x.center_id,
                        principalTable: "centers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_center",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    center_id = table.Column<int>(type: "integer", nullable: false),
                    teacher_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_center", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teacher_center_centers_center_id",
                        column: x => x.center_id,
                        principalTable: "centers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_center_users_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    teacher_id = table.Column<int>(type: "integer", nullable: false),
                    center_id = table.Column<int>(type: "integer", nullable: false),
                    since_id = table.Column<int>(type: "integer", nullable: false),
                    teacher_portion = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    begin_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    Days = table.Column<int[]>(type: "integer[]", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    times = table.Column<List<TimeOnly>>(type: "time without time zone[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_groups_centers_center_id",
                        column: x => x.center_id,
                        principalTable: "centers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groups_sinces_since_id",
                        column: x => x.since_id,
                        principalTable: "sinces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groups_users_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudent",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "integer", nullable: false),
                    StudentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudent", x => new { x.GroupsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GroupStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStudent_groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_payment_sycle",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    student_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    sycle_begin_date = table.Column<DateOnly>(type: "date", nullable: false),
                    sycle_end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    sycle_next_date = table.Column<DateOnly>(type: "date", nullable: true),
                    group_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_payment_sycle", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_payment_sycle_Students_student_id",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_payment_sycle_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    payed = table.Column<int>(type: "integer", nullable: false),
                    student_payment_sycle_id = table.Column<int>(type: "integer", nullable: false),
                    paid_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_payments_student_payment_sycle_student_payment_sycl~",
                        column: x => x.student_payment_sycle_id,
                        principalTable: "student_payment_sycle",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "SuperAdmin" },
                    { 2, "CenterAdmin" },
                    { 3, "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "full_name", "password", "role_id", "username" },
                values: new object[,]
                {
                    { -1, "Center Admin", "123", 2, "ruslan" },
                    { 1, "Teacher", "123", 3, "teacher" }
                });

            migrationBuilder.InsertData(
                table: "centers",
                columns: new[] { "id", "admin_id", "name" },
                values: new object[] { 1, -1, "Center 1" });

            migrationBuilder.InsertData(
                table: "sinces",
                columns: new[] { "id", "center_id", "name" },
                values: new object[] { 1, 1, "matematika" });

            migrationBuilder.CreateIndex(
                name: "IX_centers_admin_id",
                table: "centers",
                column: "admin_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_center_id",
                table: "groups",
                column: "center_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_since_id",
                table: "groups",
                column: "since_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_teacher_id",
                table: "groups",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudent_StudentsId",
                table: "GroupStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_sinces_center_id",
                table: "sinces",
                column: "center_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_payment_sycle_group_id",
                table: "student_payment_sycle",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_payment_sycle_student_id",
                table: "student_payment_sycle",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_payments_student_payment_sycle_id",
                table: "student_payments",
                column: "student_payment_sycle_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_center_center_id",
                table: "teacher_center",
                column: "center_id");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_center_teacher_id",
                table: "teacher_center",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStudent");

            migrationBuilder.DropTable(
                name: "student_payments");

            migrationBuilder.DropTable(
                name: "teacher_center");

            migrationBuilder.DropTable(
                name: "student_payment_sycle");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "sinces");

            migrationBuilder.DropTable(
                name: "centers");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
