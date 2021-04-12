﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendaWebMVC.Data;

namespace VendaWebMVC.Migrations
{
    [DbContext(typeof(SellerWebMVCContext))]
    [Migration("20210402162639_DepartamentoComChavePrimaria")]
    partial class DepartamentoComChavePrimaria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendaWebMVC.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("VendaWebMVC.Models.RecordVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int>("Status");

                    b.Property<double>("Total");

                    b.Property<int?>("VendedorId");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("RecordVendas");
                });

            modelBuilder.Entity("VendaWebMVC.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("VendaWebMVC.Models.RecordVendas", b =>
                {
                    b.HasOne("VendaWebMVC.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorId");
                });

            modelBuilder.Entity("VendaWebMVC.Models.Vendedor", b =>
                {
                    b.HasOne("VendaWebMVC.Models.Department", "Department")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}