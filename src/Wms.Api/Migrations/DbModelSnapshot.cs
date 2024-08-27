﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wms.Api.DataAccess;

#nullable disable

namespace Wms.Api.Migrations
{
    [DbContext(typeof(Db))]
    partial class DbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wms.Api.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("end_date");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid")
                        .HasColumnName("room_id");

                    b.Property<Guid?>("SeatId")
                        .HasColumnType("uuid")
                        .HasColumnName("seat_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_bookings");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_bookings_room_id");

                    b.HasIndex("SeatId")
                        .HasDatabaseName("ix_bookings_seat_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_bookings_user_id");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("data");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_files");

                    b.ToTable("files", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_floors");

                    b.ToTable("floors", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.Invitation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<Guid?>("BookingId")
                        .HasColumnType("uuid")
                        .HasColumnName("booking_id");

                    b.Property<Guid>("FromUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("from_user_id");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Outcome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("outcome");

                    b.Property<Guid?>("TableId")
                        .HasColumnType("uuid")
                        .HasColumnName("table_id");

                    b.Property<Guid>("ToUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("to_user_id");

                    b.HasKey("Id")
                        .HasName("pk_invitations");

                    b.HasIndex("BookingId")
                        .HasDatabaseName("ix_invitations_booking_id");

                    b.HasIndex("FromUserId")
                        .HasDatabaseName("ix_invitations_from_user_id");

                    b.HasIndex("TableId")
                        .HasDatabaseName("ix_invitations_table_id");

                    b.HasIndex("ToUserId")
                        .HasDatabaseName("ix_invitations_to_user_id");

                    b.ToTable("invitations", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid>("FloorId")
                        .HasColumnType("uuid")
                        .HasColumnName("floor_id");

                    b.Property<bool>("IsMeetingRoom")
                        .HasColumnType("boolean")
                        .HasColumnName("is_meeting_room");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid")
                        .HasColumnName("photo_id");

                    b.HasKey("Id")
                        .HasName("pk_rooms");

                    b.HasIndex("FloorId")
                        .HasDatabaseName("ix_rooms_floor_id");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasDatabaseName("ix_rooms_photo_id");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid")
                        .HasColumnName("photo_id");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uuid")
                        .HasColumnName("table_id");

                    b.HasKey("Id")
                        .HasName("pk_seats");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasDatabaseName("ix_seats_photo_id");

                    b.HasIndex("TableId")
                        .HasDatabaseName("ix_seats_table_id");

                    b.ToTable("seats", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid")
                        .HasColumnName("photo_id");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid")
                        .HasColumnName("room_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_tables");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasDatabaseName("ix_tables_photo_id");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_tables_room_id");

                    b.ToTable("tables", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("added");

                    b.Property<bool>("Disabled")
                        .HasColumnType("boolean")
                        .HasColumnName("disabled");

                    b.Property<DateTime>("DisablingDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("disabling_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid")
                        .HasColumnName("photo_id");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasDatabaseName("ix_users_photo_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Wms.Api.Entities.Booking", b =>
                {
                    b.HasOne("Wms.Api.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_bookings_rooms_room_id");

                    b.HasOne("Wms.Api.Entities.Seat", "Seat")
                        .WithMany("Bookings")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_bookings_seats_seat_id");

                    b.HasOne("Wms.Api.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_users_user_id");

                    b.Navigation("Room");

                    b.Navigation("Seat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wms.Api.Entities.Invitation", b =>
                {
                    b.HasOne("Wms.Api.Entities.Booking", "Booking")
                        .WithMany("Invitations")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_invitations_bookings_booking_id");

                    b.HasOne("Wms.Api.Entities.User", "FromUser")
                        .WithMany("SentInvitations")
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_invitations_users_from_user_id");

                    b.HasOne("Wms.Api.Entities.Table", "Table")
                        .WithMany("Invitations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_invitations_tables_table_id");

                    b.HasOne("Wms.Api.Entities.User", "ToUser")
                        .WithMany("ReceivedInvitations")
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_invitations_users_to_user_id");

                    b.Navigation("Booking");

                    b.Navigation("FromUser");

                    b.Navigation("Table");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("Wms.Api.Entities.Room", b =>
                {
                    b.HasOne("Wms.Api.Entities.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_rooms_floors_floor_id");

                    b.HasOne("Wms.Api.Entities.File", "Photo")
                        .WithOne("Room")
                        .HasForeignKey("Wms.Api.Entities.Room", "PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_rooms_files_photo_id");

                    b.Navigation("Floor");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Wms.Api.Entities.Seat", b =>
                {
                    b.HasOne("Wms.Api.Entities.File", "Photo")
                        .WithOne("Seat")
                        .HasForeignKey("Wms.Api.Entities.Seat", "PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_seats_files_photo_id");

                    b.HasOne("Wms.Api.Entities.Table", "Table")
                        .WithMany("Seats")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_seats_tables_table_id");

                    b.Navigation("Photo");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Wms.Api.Entities.Table", b =>
                {
                    b.HasOne("Wms.Api.Entities.File", "Photo")
                        .WithOne("Table")
                        .HasForeignKey("Wms.Api.Entities.Table", "PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_tables_files_photo_id");

                    b.HasOne("Wms.Api.Entities.Room", "Room")
                        .WithMany("Tables")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_tables_rooms_room_id");

                    b.Navigation("Photo");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Wms.Api.Entities.User", b =>
                {
                    b.HasOne("Wms.Api.Entities.File", "Photo")
                        .WithOne("User")
                        .HasForeignKey("Wms.Api.Entities.User", "PhotoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("fk_users_files_photo_id");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Wms.Api.Entities.Booking", b =>
                {
                    b.Navigation("Invitations");
                });

            modelBuilder.Entity("Wms.Api.Entities.File", b =>
                {
                    b.Navigation("Room")
                        .IsRequired();

                    b.Navigation("Seat")
                        .IsRequired();

                    b.Navigation("Table")
                        .IsRequired();

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Wms.Api.Entities.Floor", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Wms.Api.Entities.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Wms.Api.Entities.Seat", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Wms.Api.Entities.Table", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Wms.Api.Entities.User", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("ReceivedInvitations");

                    b.Navigation("SentInvitations");
                });
#pragma warning restore 612, 618
        }
    }
}
