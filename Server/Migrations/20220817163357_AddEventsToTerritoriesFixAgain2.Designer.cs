﻿// <auto-generated />
using DataContext.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(MHIdleContext))]
    [Migration("20220817163357_AddEventsToTerritoriesFixAgain2")]
    partial class AddEventsToTerritoriesFixAgain2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityModels.Postgresql.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("MaximumInInventory")
                        .HasColumnType("integer");

                    b.Property<int>("MaximumInStorage")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Rarity")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character(1000)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .IsFixedLength();

                    b.Property<int>("RegionId")
                        .HasColumnType("integer")
                        .HasColumnName("RegionId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Territory");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("ProportionValue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("TerritoryEvent");
                });

            modelBuilder.Entity("TerritoryTerritoryEvent", b =>
                {
                    b.Property<int>("TerritoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("TerritoryEventsId")
                        .HasColumnType("integer");

                    b.HasKey("TerritoriesId", "TerritoryEventsId");

                    b.HasIndex("TerritoryEventsId");

                    b.ToTable("TerritoryTerritoryEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionId")
                        .IsRequired()
                        .HasConstraintName("FK_Territories_Region");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("TerritoryTerritoryEvent", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Territory", null)
                        .WithMany()
                        .HasForeignKey("TerritoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.TerritoryEvent", null)
                        .WithMany()
                        .HasForeignKey("TerritoryEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Navigation("Territories");
                });
#pragma warning restore 612, 618
        }
    }
}
