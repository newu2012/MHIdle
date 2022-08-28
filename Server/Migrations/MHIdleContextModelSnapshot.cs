﻿// <auto-generated />
using DataContext.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(MHIdleContext))]
    partial class MHIdleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityModels.Postgresql.Item", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

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

                    b.Property<int>("Rarity")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("Item");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("EntityModels.Postgresql.MonsterPart", b =>
                {
                    b.Property<string>("PartName")
                        .HasColumnType("text");

                    b.Property<double>("CurrentHealth")
                        .HasColumnType("double precision");

                    b.Property<double>("MaximumHealth")
                        .HasColumnType("double precision");

                    b.Property<string>("MonsterName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PartName");

                    b.HasIndex("MonsterName");

                    b.ToTable("MonsterPart");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Recipe", b =>
                {
                    b.Property<string>("Name")
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

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Name");

                    b.HasIndex("ItemName");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("EntityModels.Postgresql.RecipeMaterial", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ItemName");

                    b.HasIndex("RecipeName");

                    b.ToTable("RecipeMaterial");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

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

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("RegionName");

                    b.ToTable("Territory");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEvent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Discriminator")
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

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Name");

                    b.ToTable("TerritoryEvent");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TerritoryEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEventItem", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MaximumQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("MinimumQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("TerritoryEventName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ItemName");

                    b.HasIndex("TerritoryEventName");

                    b.ToTable("TerritoryEventItem");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEventProportion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("TerritoryEventName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TerritoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("TerritoryEventName");

                    b.HasIndex("TerritoryName");

                    b.ToTable("TerritoryEventProportion");
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

            modelBuilder.Entity("EntityModels.Postgresql.Monster", b =>
                {
                    b.HasBaseType("EntityModels.Postgresql.TerritoryEvent");

                    b.ToTable("TerritoryEvent");

                    b.HasDiscriminator().HasValue("Monster");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Resource", b =>
                {
                    b.HasBaseType("EntityModels.Postgresql.Item");

                    b.Property<string>("ResourceType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.ToTable("Item");

                    b.HasDiscriminator().HasValue("Resource");
                });

            modelBuilder.Entity("EntityModels.Postgresql.ResourceNode", b =>
                {
                    b.HasBaseType("EntityModels.Postgresql.TerritoryEvent");

                    b.ToTable("TerritoryEvent");

                    b.HasDiscriminator().HasValue("ResourceNode");
                });

            modelBuilder.Entity("EntityModels.Postgresql.MonsterPart", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Monster", null)
                        .WithMany("MonsterParts")
                        .HasForeignKey("MonsterName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityModels.Postgresql.Recipe", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("EntityModels.Postgresql.RecipeMaterial", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.Recipe", "Recipe")
                        .WithMany("RecipeMaterials")
                        .HasForeignKey("RecipeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Region", "Region")
                        .WithMany("Territories")
                        .HasForeignKey("RegionName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEventItem", b =>
                {
                    b.HasOne("EntityModels.Postgresql.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.TerritoryEvent", "TerritoryEvent")
                        .WithMany("TerritoryEventItems")
                        .HasForeignKey("TerritoryEventName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("TerritoryEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEventProportion", b =>
                {
                    b.HasOne("EntityModels.Postgresql.TerritoryEvent", "TerritoryEvent")
                        .WithMany("TerritoryEventProportions")
                        .HasForeignKey("TerritoryEventName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityModels.Postgresql.Territory", "Territory")
                        .WithMany("TerritoryEventProportions")
                        .HasForeignKey("TerritoryName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Territory");

                    b.Navigation("TerritoryEvent");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Recipe", b =>
                {
                    b.Navigation("RecipeMaterials");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Navigation("Territories");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.Navigation("TerritoryEventProportions");
                });

            modelBuilder.Entity("EntityModels.Postgresql.TerritoryEvent", b =>
                {
                    b.Navigation("TerritoryEventItems");

                    b.Navigation("TerritoryEventProportions");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Monster", b =>
                {
                    b.Navigation("MonsterParts");
                });
#pragma warning restore 612, 618
        }
    }
}
