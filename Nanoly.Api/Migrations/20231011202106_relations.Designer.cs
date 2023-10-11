﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nanoly.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(PostgresDBContext))]
    [Migration("20231011202106_relations")]
    partial class relations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Nanoly.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("SpaceNameId")
                        .HasColumnType("integer");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SpaceNameId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("Nanoly.Entities.SpaceName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SpaceName");
                });

            modelBuilder.Entity("Nanoly.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Nanoly.Entities.Link", b =>
                {
                    b.HasOne("Nanoly.Entities.SpaceName", null)
                        .WithMany("links")
                        .HasForeignKey("SpaceNameId");
                });

            modelBuilder.Entity("Nanoly.Entities.SpaceName", b =>
                {
                    b.HasOne("Nanoly.Entities.User", null)
                        .WithMany("spaceNames")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Nanoly.Entities.SpaceName", b =>
                {
                    b.Navigation("links");
                });

            modelBuilder.Entity("Nanoly.Entities.User", b =>
                {
                    b.Navigation("spaceNames");
                });
#pragma warning restore 612, 618
        }
    }
}
