﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stage2023.Models;

#nullable disable

namespace Stage2023.Migrations
{
    [DbContext(typeof(McContext))]
    partial class McContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stage2023.Models.FamillePoste", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("FamillePostes");
                });

            modelBuilder.Entity("Stage2023.Models.Poste", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<bool>("Actif")
                        .HasColumnType("bit");

                    b.Property<long>("IdTypeposteFK")
                        .HasColumnType("bigint");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nomreseau")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("IdTypeposteFK");

                    b.HasIndex("Nomreseau")
                        .IsUnique();

                    b.ToTable("Postes");
                });

            modelBuilder.Entity("Stage2023.Models.TypePoste", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long?>("IdFamilleposteFK")
                        .HasColumnType("bigint");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("IdFamilleposteFK");

                    b.ToTable("TypePostes");
                });

            modelBuilder.Entity("Stage2023.Models.Poste", b =>
                {
                    b.HasOne("Stage2023.Models.TypePoste", "typePoste")
                        .WithMany("postes")
                        .HasForeignKey("IdTypeposteFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("typePoste");
                });

            modelBuilder.Entity("Stage2023.Models.TypePoste", b =>
                {
                    b.HasOne("Stage2023.Models.FamillePoste", "famillePoste")
                        .WithMany("Typepostes")
                        .HasForeignKey("IdFamilleposteFK");

                    b.Navigation("famillePoste");
                });

            modelBuilder.Entity("Stage2023.Models.FamillePoste", b =>
                {
                    b.Navigation("Typepostes");
                });

            modelBuilder.Entity("Stage2023.Models.TypePoste", b =>
                {
                    b.Navigation("postes");
                });
#pragma warning restore 612, 618
        }
    }
}