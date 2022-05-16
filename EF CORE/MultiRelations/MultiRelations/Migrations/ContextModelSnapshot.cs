﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiRelations.Models.Data;

#nullable disable

namespace MultiRelations.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EgitmenOgrenci", b =>
                {
                    b.Property<int>("EgitmenlerId")
                        .HasColumnType("int");

                    b.Property<int>("OgrencilerId")
                        .HasColumnType("int");

                    b.HasKey("EgitmenlerId", "OgrencilerId");

                    b.HasIndex("OgrencilerId");

                    b.ToTable("EgitmenOgrenci");
                });

            modelBuilder.Entity("MultiRelations.Models.Data.Context+Egitmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EgitmenAd")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Egitmenler");
                });

            modelBuilder.Entity("MultiRelations.Models.Data.Context+Ogrenci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("EgitmenOgrenci", b =>
                {
                    b.HasOne("MultiRelations.Models.Data.Context+Egitmen", null)
                        .WithMany()
                        .HasForeignKey("EgitmenlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MultiRelations.Models.Data.Context+Ogrenci", null)
                        .WithMany()
                        .HasForeignKey("OgrencilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}