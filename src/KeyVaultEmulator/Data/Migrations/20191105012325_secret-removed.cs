using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureKeyVaultEmulator.Data.Migrations
{
    public partial class secretremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecretTag");

            migrationBuilder.AddColumn<bool>(
                name: "Removed",
                table: "Secrets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VersionId",
                table: "Secrets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    SecretId = table.Column<long>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => new { x.SecretId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tag_Secrets_SecretId",
                        column: x => x.SecretId,
                        principalTable: "Secrets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropColumn(
                name: "Removed",
                table: "Secrets");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Secrets");

            migrationBuilder.CreateTable(
                name: "SecretTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FkSecretKey = table.Column<int>(type: "INTEGER", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: true),
                    SecretId = table.Column<long>(type: "INTEGER", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
    }
}
