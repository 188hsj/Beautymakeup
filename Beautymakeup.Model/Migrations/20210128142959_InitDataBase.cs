using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beautymakeup.Model.Migrations
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblLogrecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDate = table.Column<DateTime>(nullable: false),
                    LogLevel = table.Column<string>(maxLength: 50, nullable: false),
                    Logger = table.Column<string>(maxLength: 256, nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    MachineName = table.Column<string>(maxLength: 50, nullable: true),
                    MachineIp = table.Column<string>(maxLength: 50, nullable: true),
                    NetRequestMethod = table.Column<string>(maxLength: 10, nullable: true),
                    NetRequestUrl = table.Column<string>(maxLength: 500, nullable: true),
                    NetUserIsauthenticated = table.Column<string>(maxLength: 10, nullable: true),
                    NetUserAuthtype = table.Column<string>(maxLength: 50, nullable: true),
                    NetUserIdentity = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblLogrecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblProducts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false, defaultValue: 0),
                    Creator = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 16, nullable: false),
                    ProductImgUrl = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    Creator = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 16, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 50, nullable: false),
                    Remark = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false, defaultValue: 0),
                    Creator = table.Column<long>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    Modifier = table.Column<long>(nullable: true),
                    ModifyTime = table.Column<DateTime>(nullable: true),
                    Account = table.Column<string>(maxLength: 16, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblUsers_TblRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TblRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUserLogins",
                columns: table => new
                {
                    Account = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    HashedPassword = table.Column<string>(maxLength: 256, nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false, defaultValue: 0),
                    IsLocked = table.Column<bool>(nullable: false),
                    LockedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserLogins", x => x.Account);
                    table.ForeignKey(
                        name: "FK_TblUserLogins_TblUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TblUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TblRoles",
                columns: new[] { "Id", "CreateTime", "Creator", "DisplayName", "Modifier", "ModifyTime", "Name", "Remark", "StatusCode" },
                values: new object[] { 1219490056771866625L, new DateTime(2021, 1, 28, 22, 29, 59, 186, DateTimeKind.Local).AddTicks(2432), 1219490056771866624L, "超级管理员", null, null, "SuperAdmin", "系统内置超级管理员", 0 });

            migrationBuilder.InsertData(
                table: "TblUsers",
                columns: new[] { "Id", "Account", "CreateTime", "Creator", "Email", "Modifier", "ModifyTime", "Name", "Phone", "RoleId" },
                values: new object[] { 1219490056771866624L, "admin", new DateTime(2021, 1, 28, 22, 29, 59, 190, DateTimeKind.Local).AddTicks(1188), 1219490056771866624L, null, null, null, "admin", null, 1219490056771866625L });

            migrationBuilder.InsertData(
                table: "TblUserLogins",
                columns: new[] { "Account", "HashedPassword", "IsLocked", "LastLoginTime", "LockedTime", "UserId" },
                values: new object[] { "admin", "AQAAAAEAACcQAAAAENf1bz7/+ILF0khgj9/fjxwB2w8CWJj2PaYMask4jmYFrGednyeklJjAIF7Ptvz64g==", false, null, null, 1219490056771866624L });

            migrationBuilder.CreateIndex(
                name: "IX_TblProducts_ProductName",
                table: "TblProducts",
                column: "ProductName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblRoles_Name",
                table: "TblRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblUserLogins_UserId",
                table: "TblUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TblUsers_Account",
                table: "TblUsers",
                column: "Account",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblUsers_RoleId",
                table: "TblUsers",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblLogrecords");

            migrationBuilder.DropTable(
                name: "TblProducts");

            migrationBuilder.DropTable(
                name: "TblUserLogins");

            migrationBuilder.DropTable(
                name: "TblUsers");

            migrationBuilder.DropTable(
                name: "TblRoles");
        }
    }
}
