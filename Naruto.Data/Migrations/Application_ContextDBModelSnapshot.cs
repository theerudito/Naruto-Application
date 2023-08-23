﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Naruto.Data;

#nullable disable

namespace Naruto.Data.Migrations
{
    [DbContext(typeof(Application_ContextDB))]
    partial class Application_ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("IdJutsu")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdOcupation")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IdVillage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("JutsusIdJutsu")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OcupationsIdOcupation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RefImage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StatusIdStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VillagesIdVillage")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdCharacter");

                    b.HasIndex("ClanIdClan");

                    b.HasIndex("JutsusIdJutsu");

                    b.HasIndex("OcupationsIdOcupation");

                    b.HasIndex("StatusIdStatus");

                    b.HasIndex("VillagesIdVillage");

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

            modelBuilder.Entity("Naruto.Models.Model.Jutsus", b =>
                {
                    b.Property<int>("IdJutsu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("JutsuName")
                        .HasColumnType("TEXT");

                    b.HasKey("IdJutsu");

                    b.ToTable("Jutsu");
                });

            modelBuilder.Entity("Naruto.Models.Model.Ocupations", b =>
                {
                    b.Property<int>("IdOcupation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OcupationName")
                        .HasColumnType("TEXT");

                    b.HasKey("IdOcupation");

                    b.ToTable("Ocupation");
                });

            modelBuilder.Entity("Naruto.Models.Model.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Alive")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdStatus");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Naruto.Models.Model.Villages", b =>
                {
                    b.Property<int>("IdVillage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("VillageName")
                        .HasColumnType("TEXT");

                    b.HasKey("IdVillage");

                    b.ToTable("Village");
                });

            modelBuilder.Entity("Naruto.Models.Model.Character", b =>
                {
                    b.HasOne("Naruto.Models.Model.Clan", "Clan")
                        .WithMany("Characters")
                        .HasForeignKey("ClanIdClan");

                    b.HasOne("Naruto.Models.Model.Jutsus", "Jutsus")
                        .WithMany("Characters")
                        .HasForeignKey("JutsusIdJutsu");

                    b.HasOne("Naruto.Models.Model.Ocupations", "Ocupations")
                        .WithMany("Characters")
                        .HasForeignKey("OcupationsIdOcupation");

                    b.HasOne("Naruto.Models.Model.Status", "Status")
                        .WithMany("Characters")
                        .HasForeignKey("StatusIdStatus");

                    b.HasOne("Naruto.Models.Model.Villages", "Villages")
                        .WithMany("Characters")
                        .HasForeignKey("VillagesIdVillage");

                    b.Navigation("Clan");

                    b.Navigation("Jutsus");

                    b.Navigation("Ocupations");

                    b.Navigation("Status");

                    b.Navigation("Villages");
                });

            modelBuilder.Entity("Naruto.Models.Model.Clan", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Naruto.Models.Model.Jutsus", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Naruto.Models.Model.Ocupations", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Naruto.Models.Model.Status", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Naruto.Models.Model.Villages", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
