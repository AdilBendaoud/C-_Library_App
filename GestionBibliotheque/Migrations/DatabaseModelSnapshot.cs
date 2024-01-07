﻿// <auto-generated />
using System;
using GestionBibliotheque.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionBibliotheque.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GestionBibliotheque.Model.Auteur", b =>
                {
                    b.Property<int>("AuteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AuteurId"));

                    b.Property<DateTime?>("DateNaissance")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AuteurId");

                    b.ToTable("Auteurs");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategorieId"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategorieId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Emprunte", b =>
                {
                    b.Property<int>("EmprunteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmprunteId"));

                    b.Property<DateTime>("DateEmprunte")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateRetourPrevue")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateRetourReelle")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LivreId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrixPaye")
                        .HasColumnType("numeric");

                    b.Property<string>("UserCIN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("EmprunteId");

                    b.HasIndex("LivreId");

                    b.HasIndex("UserCIN");

                    b.ToTable("Empruntes");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Livre", b =>
                {
                    b.Property<int>("LivreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LivreId"));

                    b.Property<int>("AuteurId")
                        .HasColumnType("integer");

                    b.Property<int>("CategorieId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateDistrubution")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Edition")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Prix")
                        .HasColumnType("double precision");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LivreId");

                    b.HasIndex("AuteurId");

                    b.HasIndex("CategorieId");

                    b.ToTable("Livres");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.User", b =>
                {
                    b.Property<string>("CIN")
                        .HasColumnType("text");

                    b.Property<string>("Adresse")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSuperAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Tel")
                        .HasColumnType("integer");

                    b.HasKey("CIN");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            CIN = "EE123456",
                            Email = "test@gmail.com",
                            IsAdmin = true,
                            IsSuperAdmin = false,
                            Nom = "Mark",
                            Password = "admin1234",
                            Prenom = "Alex"
                        });
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Emprunte", b =>
                {
                    b.HasOne("GestionBibliotheque.Model.Livre", "Livre")
                        .WithMany()
                        .HasForeignKey("LivreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionBibliotheque.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserCIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Livre", b =>
                {
                    b.HasOne("GestionBibliotheque.Model.Auteur", "Auteur")
                        .WithMany("Livres")
                        .HasForeignKey("AuteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionBibliotheque.Model.Categorie", "Categorie")
                        .WithMany("Livres")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auteur");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Auteur", b =>
                {
                    b.Navigation("Livres");
                });

            modelBuilder.Entity("GestionBibliotheque.Model.Categorie", b =>
                {
                    b.Navigation("Livres");
                });
#pragma warning restore 612, 618
        }
    }
}
