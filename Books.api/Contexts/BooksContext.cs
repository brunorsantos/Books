using Books.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.api.Contexts
{
    public class BooksContext :DbContext
    {

        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("02D0BE85-7064-4446-A3F3-00000CB31F46"),
                    FirstName = "George",
                    LastName = "Orwell"
                },
                new Author()
                {
                    Id = Guid.Parse("B29F845E-62CC-4AA6-B764-000010082F62"),
                    FirstName = "Jack",
                    LastName = "Kureoak"
                },
                new Author()
                {
                    Id = Guid.Parse("2492CF4E-E468-4B32-B77A-0000538842A8"),
                    FirstName = "Dan",
                    LastName = "Brown"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book() {
                    Id =       Guid.Parse("C5F57CF7-0DFB-4BAC-9419-00007D690626"),
                    AuthorId = Guid.Parse("02D0BE85-7064-4446-A3F3-00000CB31F46"),
                    Title = "1984",
                    Description = "Duplipensar"
                },
                new Book()
                {
                    Id =       Guid.Parse("A08B083D-CF52-4641-A6F9-000087B26762"),
                    AuthorId = Guid.Parse("02D0BE85-7064-4446-A3F3-00000CB31F46"),
                    Title = "Animal Farm",
                    Description = "Pigs"
                },
                new Book()
                {
                    Id =       Guid.Parse("8B833DBE-7D3E-4567-A332-0000B06950EF"),
                    AuthorId = Guid.Parse("B29F845E-62CC-4AA6-B764-000010082F62"),
                    Title = "On the Road",
                    Description = "Beatniks"
                },
                new Book()
                {
                    Id =       Guid.Parse("D5C261A7-B5E5-4552-8A8B-0000C514E724"),
                    AuthorId = Guid.Parse("2492CF4E-E468-4B32-B77A-0000538842A8"),
                    Title = "da Vinci code",
                    Description = "Amon and Isis"
                },
                new Book()
                {
                    Id =       Guid.Parse("D54D6591-629E-43DF-8B9E-0000F7F4C73B"),
                    AuthorId = Guid.Parse("2492CF4E-E468-4B32-B77A-0000538842A8"),
                    Title = "Angels and Deamons",
                    Description = "Vatican"
                }
            );


             base.OnModelCreating(modelBuilder);
        }
    }
}
