using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GymBackend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:file_fdw", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("subscription_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying", nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    phone = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    id_user = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("client_pkey", x => x.id);
                    table.ForeignKey(
                        name: "client_id_user_fkey",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "coach",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    qualification = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    id_user = table.Column<int>(type: "integer", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    termination_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("coach_pkey", x => x.id);
                    table.ForeignKey(
                        name: "coach_id_user_fkey",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "progress",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<byte[]>(type: "bytea", nullable: false),
                    hip_chest = table.Column<byte[]>(type: "bytea", nullable: false),
                    hip_arm = table.Column<byte[]>(type: "bytea", nullable: false),
                    hip_girth = table.Column<byte[]>(type: "bytea", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("progress_pkey", x => x.id);
                    table.ForeignKey(
                        name: "progress_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchase_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    id_subscription = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("purchase_history_pkey", x => x.id);
                    table.ForeignKey(
                        name: "purchase_history_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "purchase_history_id_subscription_fkey",
                        column: x => x.id_subscription,
                        principalTable: "subscription",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "schedule_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_coach = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    type_of_training = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    max_people = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("schedule_group_pkey", x => x.id);
                    table.ForeignKey(
                        name: "schedule_group_id_coach_fkey",
                        column: x => x.id_coach,
                        principalTable: "coach",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    id_schedule_group = table.Column<int>(type: "integer", nullable: false),
                    from_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    deleted = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("registration_pkey", x => x.id);
                    table.ForeignKey(
                        name: "registration_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "registration_id_schedule_group_fkey",
                        column: x => x.id_schedule_group,
                        principalTable: "schedule_group",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "visit",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_client = table.Column<int>(type: "integer", nullable: false),
                    id_schedule_group = table.Column<int>(type: "integer", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("visit_pkey", x => x.id);
                    table.ForeignKey(
                        name: "visit_id_client_fkey",
                        column: x => x.id_client,
                        principalTable: "client",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "visit_id_schedule_group_fkey",
                        column: x => x.id_schedule_group,
                        principalTable: "schedule_group",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_id_user",
                table: "client",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_coach_id_user",
                table: "coach",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_progress_id_client",
                table: "progress",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_history_id_client",
                table: "purchase_history",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_history_id_subscription",
                table: "purchase_history",
                column: "id_subscription");

            migrationBuilder.CreateIndex(
                name: "IX_registration_id_client",
                table: "registration",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_registration_id_schedule_group",
                table: "registration",
                column: "id_schedule_group");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_group_id_coach",
                table: "schedule_group",
                column: "id_coach");

            migrationBuilder.CreateIndex(
                name: "unique_login",
                table: "user",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_visit_start_date",
                table: "visit",
                column: "start_date");

            migrationBuilder.CreateIndex(
                name: "IX_visit_id_client",
                table: "visit",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_visit_id_schedule_group",
                table: "visit",
                column: "id_schedule_group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "progress");

            migrationBuilder.DropTable(
                name: "purchase_history");

            migrationBuilder.DropTable(
                name: "registration");

            migrationBuilder.DropTable(
                name: "visit");

            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "schedule_group");

            migrationBuilder.DropTable(
                name: "coach");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
