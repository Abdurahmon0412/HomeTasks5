﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notifications.Persistance.DataContexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Notifications.Persistance.Migrations
{
    [DbContext(typeof(NotificationDbContext))]
    [Migration("20231114090614_InitialHistory")]
    partial class InitialHistory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Notifications.Domain.Entities.NotificationHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NotificationType")
                        .HasColumnType("integer");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("NotificationHistory");

                    b.HasDiscriminator<int>("NotificationType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Notifications.Domain.Entities.NotificationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("NotificationType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplate");

                    b.HasDiscriminator<int>("NotificationType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Notifications.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Notifications.Domain.Entities.EmailHistory", b =>
                {
                    b.HasBaseType("Notifications.Domain.Entities.NotificationHistory");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Notifications.Domain.Entities.SmsHistory", b =>
                {
                    b.HasBaseType("Notifications.Domain.Entities.NotificationHistory");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Notifications.Domain.Entities.EmailTemplate", b =>
                {
                    b.HasBaseType("Notifications.Domain.Entities.NotificationTemplate");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Notifications.Domain.Entities.SmsTemplate", b =>
                {
                    b.HasBaseType("Notifications.Domain.Entities.NotificationTemplate");

                    b.HasDiscriminator().HasValue(0);
                });
#pragma warning restore 612, 618
        }
    }
}
