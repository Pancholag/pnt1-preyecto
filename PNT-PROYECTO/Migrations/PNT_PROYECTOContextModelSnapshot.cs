﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PNT_PROYECTO.Data;

#nullable disable

namespace PNT_PROYECTO.Migrations
{
    [DbContext(typeof(PNT_PROYECTOContext))]
    partial class PNT_PROYECTOContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("ExamenMaterial", b =>
                {
                    b.Property<int>("ExamenesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaterialesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExamenesId", "MaterialesId");

                    b.HasIndex("MaterialesId");

                    b.ToTable("ExamenMaterial");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Examen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfeId");

                    b.ToTable("Examen");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Ingreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("horaIngreso")
                        .HasColumnType("TEXT");

                    b.Property<int>("usuarioLegajo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("usuarioLegajo");

                    b.ToTable("Ingreso");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VecesDescargado")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VecesVisto")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfeId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Persona", b =>
                {
                    b.Property<int>("Legajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreApellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Legajo");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.ProfeARegistrar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreApellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("profeARegistrar");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Alumno", b =>
                {
                    b.HasBaseType("PNT_PROYECTO.Models.Persona");

                    b.HasDiscriminator().HasValue("Alumno");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Profesor", b =>
                {
                    b.HasBaseType("PNT_PROYECTO.Models.Persona");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Profesor");
                });

            modelBuilder.Entity("ExamenMaterial", b =>
                {
                    b.HasOne("PNT_PROYECTO.Models.Examen", null)
                        .WithMany()
                        .HasForeignKey("ExamenesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNT_PROYECTO.Models.Material", null)
                        .WithMany()
                        .HasForeignKey("MaterialesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Examen", b =>
                {
                    b.HasOne("PNT_PROYECTO.Models.Profesor", "Profe")
                        .WithMany("Examenes")
                        .HasForeignKey("ProfeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profe");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Ingreso", b =>
                {
                    b.HasOne("PNT_PROYECTO.Models.Persona", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioLegajo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Material", b =>
                {
                    b.HasOne("PNT_PROYECTO.Models.Profesor", "Profe")
                        .WithMany("Materiales")
                        .HasForeignKey("ProfeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profe");
                });

            modelBuilder.Entity("PNT_PROYECTO.Models.Profesor", b =>
                {
                    b.Navigation("Examenes");

                    b.Navigation("Materiales");
                });
#pragma warning restore 612, 618
        }
    }
}
