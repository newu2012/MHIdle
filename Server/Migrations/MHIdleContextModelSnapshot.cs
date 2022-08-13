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

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("RegionDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .IsFixedLength();

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ResourceId"));

                    b.Property<string>("ResourceDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("ResourceImagePath")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("ResourceMaximumInInventory")
                        .HasColumnType("integer");

                    b.Property<int>("ResourceMaximumInStorage")
                        .HasColumnType("integer");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("ResourceRarity")
                        .HasColumnType("integer");

                    b.Property<string>("ResourceType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("ResourceValue")
                        .HasColumnType("integer");

                    b.HasKey("ResourceId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("EntityModels.Postgresql.Territory", b =>
                {
                    b.Property<string>("TerritoryId")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("id");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer")
                        .HasColumnName("RegionID");

                    b.Property<string>("TerritoryDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .IsFixedLength();

                    b.HasKey("TerritoryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Territory");
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

            modelBuilder.Entity("EntityModels.Postgresql.Region", b =>
                {
                    b.Navigation("Territories");
                });
#pragma warning restore 612, 618
        }
    }
}
