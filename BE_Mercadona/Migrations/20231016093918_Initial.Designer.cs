﻿// <auto-generated />
using System;
using BE_Mercadona.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BE_Mercadona.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20231016093918_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BE_Mercadona.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CatId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CatId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BE_Mercadona.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduct"));

                    b.Property<int>("CatId")
                        .HasColumnType("integer");

                    b.Property<string>("DescriptionProduct")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PromotionsIdPromotion")
                        .HasColumnType("integer");

                    b.HasKey("IdProduct");

                    b.HasIndex("CatId");

                    b.HasIndex("PromotionsIdPromotion");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("BE_Mercadona.Models.Promotion", b =>
                {
                    b.Property<int>("IdPromotion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdPromotion"));

                    b.Property<DateOnly>("DateToEnd")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateToStart")
                        .HasColumnType("date");

                    b.Property<decimal>("TauxPromotion")
                        .HasColumnType("numeric");

                    b.HasKey("IdPromotion");

                    b.ToTable("Promotion", (string)null);
                });

            modelBuilder.Entity("BE_Mercadona.Models.Product", b =>
                {
                    b.HasOne("BE_Mercadona.Models.Category", "Cat")
                        .WithMany()
                        .HasForeignKey("CatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BE_Mercadona.Models.Promotion", "Promotions")
                        .WithMany()
                        .HasForeignKey("PromotionsIdPromotion");

                    b.Navigation("Cat");

                    b.Navigation("Promotions");
                });
#pragma warning restore 612, 618
        }
    }
}
