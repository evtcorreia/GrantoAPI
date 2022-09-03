﻿// <auto-generated />
using System;
using Granto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Granto.Migrations
{
    [DbContext(typeof(AppGrantoContext))]
    partial class AppGrantoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Granto.Models.Oportunidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Oportunidades");
                });

            modelBuilder.Entity("Granto.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dataUltimaOprtunidade")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("regiao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Granto.Models.Oportunidade", b =>
                {
                    b.HasOne("Granto.Models.User", "User")
                        .WithMany("Oportunidades")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Granto.Models.User", b =>
                {
                    b.Navigation("Oportunidades");
                });
#pragma warning restore 612, 618
        }
    }
}
