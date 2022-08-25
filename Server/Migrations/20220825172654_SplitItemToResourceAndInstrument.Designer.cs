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
    [Migration("20220825172654_SplitItemToResourceAndInstrument")]
    partial class SplitItemToResourceAndInstrument
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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("integer");

                    b.Property<int>("InstrumentExpectedLevel")
                        .HasColumnType("integer");

                    b.Property<int>("InstrumentRequiredLevel")
                        .HasColumnType("integer");

                    b.Property<string>("InstrumentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("EntityModels.Postgresql.RecipeMaterial", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeMaterial");
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

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("integer");

                    b.Property<int>("InstrumentExpectedLevel")
                        .HasColumnType("integer");

                    b.Property<int>("InstrumentRequiredLevel")
                        .HasColumnType("integer");

                    b.Property<string>("InstrumentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ResourceNodeEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("MaximumQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("MinimumQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("ResourceNodeEventId")
                        .HasColumnType("integer");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ResourceNodeEventId");

                    b.ToTable("ResourceNodeItem");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeProportion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("ResourceNodeEventId")
                        .HasColumnType("integer");

                    b.Property<int>("TerritoryId")
                        .HasColumnType("integer");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ResourceNodeEventId");

                    b.HasIndex("TerritoryId");

                    b.ToTable("ResourceNodeProportion");
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

                    b.Property<int>("DurationSecondsExploreInTerritory")
                        .HasColumnType("integer");

                    b.Property<int>("DurationSecondsExploreOnEnter")
                        .HasColumnType("integer");

                    b.Property<int>("InstrumentExpectedLevel")
                        .HasColumnType("integer");

                    b.Property<int>("InstrumentRequiredLevel")
                        .HasColumnType("integer");

                    b.Property<string>("InstrumentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

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

            modelBuilder.Entity("EntityModels.Postgresql.Instrument", b =>
                {
                    b.HasBaseType("EntityModels.Postgresql.Item");

                    b.Property<double>("ChanceToBreak")
                        .HasColumnType("double precision");

                    b.Property<int>("InstrumentLevel")
                        .HasColumnType("integer");

                    b.Property<string>("InstrumentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.ToTable("Item");

                    b.HasDiscriminator().HasValue("Instrument");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Resource", b =>
                {
                    b.HasBaseType("EntityModels.Postgresql.Item");

                    b.ToTable("Item");

                    b.HasDiscriminator().HasValue("Resource");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Recipe", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("EntityModels.Postgresql.RecipeMaterial", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.Recipe", "Recipe")
                        .WithMany("RecipeMaterials")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeItem", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.ResourceNodeEvent", "ResourceNodeEvent")
                        .WithMany("ResourceNodeItems")
                        .HasForeignKey("ResourceNodeEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ResourceNodeEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeProportion", b =>
                {
                    b.HasOne("EntityModels.Postgresql.ResourceNodeEvent", "ResourceNodeEvent")
                        .WithMany("ResourceNodeProportions")
                        .HasForeignKey("ResourceNodeEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.Territory", "Territory")
                        .WithMany("ResourceNodeProportions")
                        .HasForeignKey("TerritoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourceNodeEvent");

                    b.Navigation("Territory");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Recipe", b =>
                {
                    b.Navigation("RecipeMaterials");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Navigation("Territories");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNodeEvent", b =>
                {
                    b.Navigation("ResourceNodeItems");

                    b.Navigation("ResourceNodeProportions");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.Navigation("ResourceNodeProportions");
                });
#pragma warning restore 612, 618
        }
    }
}
