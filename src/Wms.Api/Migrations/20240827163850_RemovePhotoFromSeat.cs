using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wms.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovePhotoFromSeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_rooms_files_photo_id",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_seats_files_photo_id",
                table: "seats");

            migrationBuilder.DropForeignKey(
                name: "fk_tables_files_photo_id",
                table: "tables");

            migrationBuilder.DropForeignKey(
                name: "fk_users_files_photo_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_seats_photo_id",
                table: "seats");

            migrationBuilder.DropPrimaryKey(
                name: "pk_files",
                table: "files");

            migrationBuilder.DropColumn(
                name: "photo_id",
                table: "seats");

            migrationBuilder.RenameTable(
                name: "files",
                newName: "app_files");

            migrationBuilder.AddColumn<Guid>(
                name: "seat_id",
                table: "app_files",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_app_files",
                table: "app_files",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_app_files_seat_id",
                table: "app_files",
                column: "seat_id");

            migrationBuilder.AddForeignKey(
                name: "fk_app_files_seats_seat_id",
                table: "app_files",
                column: "seat_id",
                principalTable: "seats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_rooms_app_files_photo_id",
                table: "rooms",
                column: "photo_id",
                principalTable: "app_files",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tables_app_files_photo_id",
                table: "tables",
                column: "photo_id",
                principalTable: "app_files",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_app_files_photo_id",
                table: "users",
                column: "photo_id",
                principalTable: "app_files",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_app_files_seats_seat_id",
                table: "app_files");

            migrationBuilder.DropForeignKey(
                name: "fk_rooms_app_files_photo_id",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "fk_tables_app_files_photo_id",
                table: "tables");

            migrationBuilder.DropForeignKey(
                name: "fk_users_app_files_photo_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_app_files",
                table: "app_files");

            migrationBuilder.DropIndex(
                name: "ix_app_files_seat_id",
                table: "app_files");

            migrationBuilder.DropColumn(
                name: "seat_id",
                table: "app_files");

            migrationBuilder.RenameTable(
                name: "app_files",
                newName: "files");

            migrationBuilder.AddColumn<Guid>(
                name: "photo_id",
                table: "seats",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_files",
                table: "files",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_seats_photo_id",
                table: "seats",
                column: "photo_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_rooms_files_photo_id",
                table: "rooms",
                column: "photo_id",
                principalTable: "files",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_seats_files_photo_id",
                table: "seats",
                column: "photo_id",
                principalTable: "files",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tables_files_photo_id",
                table: "tables",
                column: "photo_id",
                principalTable: "files",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_users_files_photo_id",
                table: "users",
                column: "photo_id",
                principalTable: "files",
                principalColumn: "id");
        }
    }
}
