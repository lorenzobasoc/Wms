using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wms.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    data = table.Column<byte[]>(type: "bytea", nullable: false),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_floors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    photo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_files_photo_id",
                        column: x => x.photo_id,
                        principalTable: "files",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    photo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    floor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rooms", x => x.id);
                    table.ForeignKey(
                        name: "fk_rooms_files_photo_id",
                        column: x => x.photo_id,
                        principalTable: "files",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_rooms_floors_floor_id",
                        column: x => x.floor_id,
                        principalTable: "floors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tables",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    photo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tables", x => x.id);
                    table.ForeignKey(
                        name: "fk_tables_files_photo_id",
                        column: x => x.photo_id,
                        principalTable: "files",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tables_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    table_id = table.Column<Guid>(type: "uuid", nullable: false),
                    photo_id = table.Column<Guid>(type: "uuid", nullable: true),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_seats", x => x.id);
                    table.ForeignKey(
                        name: "fk_seats_files_photo_id",
                        column: x => x.photo_id,
                        principalTable: "files",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_seats_tables_table_id",
                        column: x => x.table_id,
                        principalTable: "tables",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    note = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    seat_id = table.Column<Guid>(type: "uuid", nullable: true),
                    room_id = table.Column<Guid>(type: "uuid", nullable: true),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookings", x => x.id);
                    table.ForeignKey(
                        name: "fk_bookings_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_bookings_seats_seat_id",
                        column: x => x.seat_id,
                        principalTable: "seats",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_bookings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "invitations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    outcome = table.Column<string>(type: "text", nullable: false),
                    from_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    to_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    table_id = table.Column<Guid>(type: "uuid", nullable: true),
                    booking_id = table.Column<Guid>(type: "uuid", nullable: true),
                    added = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    modified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invitations", x => x.id);
                    table.ForeignKey(
                        name: "fk_invitations_bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_invitations_tables_table_id",
                        column: x => x.table_id,
                        principalTable: "tables",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_invitations_users_from_user_id",
                        column: x => x.from_user_id,
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_invitations_users_to_user_id",
                        column: x => x.to_user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_bookings_room_id",
                table: "bookings",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_seat_id",
                table: "bookings",
                column: "seat_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_user_id",
                table: "bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_invitations_booking_id",
                table: "invitations",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "ix_invitations_from_user_id",
                table: "invitations",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_invitations_table_id",
                table: "invitations",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "ix_invitations_to_user_id",
                table: "invitations",
                column: "to_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_floor_id",
                table: "rooms",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "ix_rooms_photo_id",
                table: "rooms",
                column: "photo_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_seats_photo_id",
                table: "seats",
                column: "photo_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_seats_table_id",
                table: "seats",
                column: "table_id");

            migrationBuilder.CreateIndex(
                name: "ix_tables_photo_id",
                table: "tables",
                column: "photo_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tables_room_id",
                table: "tables",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_photo_id",
                table: "users",
                column: "photo_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invitations");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "tables");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "floors");
        }
    }
}
