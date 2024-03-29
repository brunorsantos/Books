﻿// <auto-generated />
using System;
using Books.api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Books.api.Migrations
{
    [DbContext(typeof(BooksContext))]
    partial class BooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Books.api.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new { Id = new Guid("02d0be85-7064-4446-a3f3-00000cb31f46"), FirstName = "George", LastName = "Orwell" },
                        new { Id = new Guid("b29f845e-62cc-4aa6-b764-000010082f62"), FirstName = "Jack", LastName = "Kureoak" },
                        new { Id = new Guid("2492cf4e-e468-4b32-b77a-0000538842a8"), FirstName = "Dan", LastName = "Brown" }
                    );
                });

            modelBuilder.Entity("Books.api.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Description")
                        .HasMaxLength(2500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new { Id = new Guid("c5f57cf7-0dfb-4bac-9419-00007d690626"), AuthorId = new Guid("02d0be85-7064-4446-a3f3-00000cb31f46"), Description = "Duplipensar", Title = "1984" },
                        new { Id = new Guid("a08b083d-cf52-4641-a6f9-000087b26762"), AuthorId = new Guid("02d0be85-7064-4446-a3f3-00000cb31f46"), Description = "Pigs", Title = "Animal Farm" },
                        new { Id = new Guid("8b833dbe-7d3e-4567-a332-0000b06950ef"), AuthorId = new Guid("b29f845e-62cc-4aa6-b764-000010082f62"), Description = "Beatniks", Title = "On the Road" },
                        new { Id = new Guid("d5c261a7-b5e5-4552-8a8b-0000c514e724"), AuthorId = new Guid("2492cf4e-e468-4b32-b77a-0000538842a8"), Description = "Amon and Isis", Title = "da Vinci code" },
                        new { Id = new Guid("d54d6591-629e-43df-8b9e-0000f7f4c73b"), AuthorId = new Guid("2492cf4e-e468-4b32-b77a-0000538842a8"), Description = "Vatican", Title = "Angels and Deamons" }
                    );
                });

            modelBuilder.Entity("Books.api.Entities.Book", b =>
                {
                    b.HasOne("Books.api.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
