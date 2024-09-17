using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddTableVacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_EMPLOYEES",
                columns: table => new
                {
                    RegistrationNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", precision: 100, nullable: false),
                    Office = table.Column<int>(type: "integer", nullable: false),
                    Remuneration = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EMPLOYEES", x => x.RegistrationNumber);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    EAN = table.Column<string>(type: "varchar(13)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Available = table.Column<bool>(type: "boolean", nullable: false),
                    Descrition = table.Column<string>(type: "varchar(1024)", nullable: false),
                    MediumPrice = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MOVIMENTS",
                columns: table => new
                {
                    MovimentNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Responsible = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MOVIMENTS", x => x.MovimentNumber);
                    table.ForeignKey(
                        name: "FK_TB_MOVIMENTS_TB_EMPLOYEES_Id_Responsible",
                        column: x => x.Id_Responsible,
                        principalTable: "TB_EMPLOYEES",
                        principalColumn: "RegistrationNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VACATIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    numberOfdays = table.Column<int>(type: "integer", nullable: false),
                    end = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VACATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_VACATIONS_TB_EMPLOYEES_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "TB_EMPLOYEES",
                        principalColumn: "RegistrationNumber");
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT_MOVEMENT",
                columns: table => new
                {
                    ID_PRODUCT = table.Column<int>(type: "integer", nullable: false),
                    ID_MOVEMENT = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT_MOVEMENT", x => new { x.ID_MOVEMENT, x.ID_PRODUCT });
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_MOVEMENT_TB_MOVIMENTS_ID_MOVEMENT",
                        column: x => x.ID_MOVEMENT,
                        principalTable: "TB_MOVIMENTS",
                        principalColumn: "MovimentNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_MOVEMENT_TB_PRODUCTS_ID_PRODUCT",
                        column: x => x.ID_PRODUCT,
                        principalTable: "TB_PRODUCTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MOVIMENTS_Id_Responsible",
                table: "TB_MOVIMENTS",
                column: "Id_Responsible");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_MOVEMENT_ID_PRODUCT",
                table: "TB_PRODUCT_MOVEMENT",
                column: "ID_PRODUCT");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VACATIONS_EmployeeId",
                table: "TB_VACATIONS",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUCT_MOVEMENT");

            migrationBuilder.DropTable(
                name: "TB_VACATIONS");

            migrationBuilder.DropTable(
                name: "TB_MOVIMENTS");

            migrationBuilder.DropTable(
                name: "TB_PRODUCTS");

            migrationBuilder.DropTable(
                name: "TB_EMPLOYEES");
        }
    }
}
