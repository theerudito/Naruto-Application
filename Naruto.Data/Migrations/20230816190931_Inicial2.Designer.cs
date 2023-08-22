﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Naruto.Data;

#nullable disable

namespace Naruto.Data.Migrations
{
    [DbContext(typeof(Application_ContextDB))]
    [Migration("20230816190931_Inicial2")]
    partial class Inicial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Naruto.Models.Model.Auth", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdUser");

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("Naruto.Models.Model.Character", b =>
                {
                    b.Property<int>("IdCharacter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClanIdClan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdClan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCharacter");

                    b.HasIndex("ClanIdClan");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Naruto.Models.Model.Clan", b =>
                {
                    b.Property<int>("IdClan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClanName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdClan");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("Naruto.Models.Model.Character", b =>
                {
                    b.HasOne("Naruto.Models.Model.Clan", "Clan")
                        .WithMany("Characters")
                        .HasForeignKey("ClanIdClan");

                    b.Navigation("Clan");
                });

            modelBuilder.Entity("Naruto.Models.Model.Clan", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
