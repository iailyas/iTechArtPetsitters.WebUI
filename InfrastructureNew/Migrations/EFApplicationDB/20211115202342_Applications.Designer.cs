﻿// <auto-generated />
using System;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InfrastructureNew.Migrations.EFApplicationDB
{
    [DbContext(typeof(EFApplicationDBContext))]
    [Migration("20211115202342_Applications")]
    partial class Applications
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainNew.Models.Application", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<long?>("PetId1")
                        .HasColumnType("bigint");

                    b.Property<int>("PetsitterId")
                        .HasColumnType("int");

                    b.Property<long?>("PetsitterId1")
                        .HasColumnType("bigint");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<long?>("ServiceId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PetId1");

                    b.HasIndex("PetsitterId1");

                    b.HasIndex("ServiceId1");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("DomainNew.Models.MyPetsitter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MyPetsitter");
                });

            modelBuilder.Entity("DomainNew.Models.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("DomainNew.Models.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("DomainNew.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DomainNew.Models.Application", b =>
                {
                    b.HasOne("DomainNew.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId1");

                    b.HasOne("DomainNew.Models.MyPetsitter", "Petsitter")
                        .WithMany()
                        .HasForeignKey("PetsitterId1");

                    b.HasOne("DomainNew.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId1");

                    b.Navigation("Pet");

                    b.Navigation("Petsitter");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DomainNew.Models.Pet", b =>
                {
                    b.HasOne("DomainNew.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
