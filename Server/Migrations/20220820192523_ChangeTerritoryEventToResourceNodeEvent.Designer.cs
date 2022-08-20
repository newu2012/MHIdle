﻿// <auto-generated />
using System;
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
    [Migration("20220820192523_ChangeTerritoryEventToResourceNodeEvent")]
    partial class ChangeTerritoryEventToResourceNodeEvent
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
                        .HasColumnType("integer")
                        .HasColumnName("id");

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
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeEvent", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ResourceNodeItemsId")
                        .HasColumnType("integer");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ResourceNodeEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeEventProportion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("ProportionValue")
                        .HasColumnType("double precision");

                    b.Property<int>("ResourceNodeItemsId")
                        .HasColumnType("integer");

                    b.Property<int>("TerritoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResourceNodeItemsId");

                    b.ToTable("ResourceNodeEventProportion");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Territory");
                });

            modelBuilder.Entity("ResourceNodeEventTerritory", b =>
                {
                    b.Property<int>("TerritoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("TerritoryId")
                        .HasColumnType("integer");

                    b.HasKey("TerritoriesId", "TerritoryId");

                    b.HasIndex("TerritoryId");

                    b.ToTable("ResourceNodeEventTerritory");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeEventProportion", b =>
                {
                    b.HasOne("EntityModels.Postgresql.ResourceNodeEvent", "ResourceNodeEvent")
                        .WithMany("ResourceNodeItemsWithProportions")
                        .HasForeignKey("ResourceNodeItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourceNodeEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("ResourceNodeEventTerritory", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Territory", null)
                        .WithMany()
                        .HasForeignKey("TerritoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.ResourceNodeEvent", null)
                        .WithMany()
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Navigation("Territories");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeEvent", b =>
                {
                    b.Navigation("ResourceNodeItemsWithProportions");
                });
#pragma warning restore 612, 618
        }
    }
}
