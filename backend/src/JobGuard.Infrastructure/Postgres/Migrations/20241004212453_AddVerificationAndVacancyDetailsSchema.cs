using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobGuard.Infrastructure.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddVerificationAndVacancyDetailsSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vacancy_details",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    job_title = table.Column<string>(type: "text", nullable: false),
                    job_location = table.Column<string>(type: "text", nullable: true),
                    salary_range = table.Column<string>(type: "text", nullable: true),
                    employment_type = table.Column<string>(type: "text", nullable: true),
                    job_description = table.Column<string>(type: "text", nullable: false),
                    posted_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    application_deadline = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    data_sources = table.Column<List<string>>(type: "text[]", nullable: false),
                    qualifications = table.Column<string>(type: "text", nullable: false),
                    responsibilities = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacancy_details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "verifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    short_id = table.Column<string>(type: "text", nullable: false),
                    provided_details = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    modified_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    provided_links = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "data_pieces",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    verification_id = table.Column<Guid>(type: "uuid", nullable: false),
                    external_id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data_pieces", x => x.id);
                    table.ForeignKey(
                        name: "FK_data_pieces_verifications_verification_id",
                        column: x => x.verification_id,
                        principalTable: "verifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_data_pieces_verification_id",
                table: "data_pieces",
                column: "verification_id");

            migrationBuilder.CreateIndex(
                name: "IX_vacancy_details_id",
                table: "vacancy_details",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_verifications_id",
                table: "verifications",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_verifications_short_id",
                table: "verifications",
                column: "short_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "data_pieces");

            migrationBuilder.DropTable(
                name: "vacancy_details");

            migrationBuilder.DropTable(
                name: "verifications");
        }
    }
}
