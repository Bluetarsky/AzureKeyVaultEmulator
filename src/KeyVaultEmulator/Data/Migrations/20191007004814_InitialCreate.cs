using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureKeyVaultEmulator.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PublicKey = table.Column<string>(nullable: true),
                    ActivationDateUtc = table.Column<DateTime>(nullable: true),
                    ExpirationDateUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Secrets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: true),
                    NotBefore = table.Column<DateTime>(nullable: true),
                    RecoveryLevel = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secrets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecretTag",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    FkSecretKey = table.Column<int>(nullable: false),
                    SecretId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretTag_Secrets_SecretId",
                        column: x => x.SecretId,
                        principalTable: "Secrets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecretTag_SecretId",
                table: "SecretTag",
                column: "SecretId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "SecretTag");

            migrationBuilder.DropTable(
                name: "Secrets");
        }
    }
}
