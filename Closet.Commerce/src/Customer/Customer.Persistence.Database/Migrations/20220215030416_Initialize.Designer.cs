﻿// <auto-generated />
using Customer.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Customer.Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220215030416_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Customer")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Customer.Domain.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("Clients", "Customer");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Name = "Client 1"
                        },
                        new
                        {
                            ClientId = 2,
                            Name = "Client 2"
                        },
                        new
                        {
                            ClientId = 3,
                            Name = "Client 3"
                        },
                        new
                        {
                            ClientId = 4,
                            Name = "Client 4"
                        },
                        new
                        {
                            ClientId = 5,
                            Name = "Client 5"
                        },
                        new
                        {
                            ClientId = 6,
                            Name = "Client 6"
                        },
                        new
                        {
                            ClientId = 7,
                            Name = "Client 7"
                        },
                        new
                        {
                            ClientId = 8,
                            Name = "Client 8"
                        },
                        new
                        {
                            ClientId = 9,
                            Name = "Client 9"
                        },
                        new
                        {
                            ClientId = 10,
                            Name = "Client 10"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
