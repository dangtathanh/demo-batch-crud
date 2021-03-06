﻿using Microsoft.EntityFrameworkCore;
using NetCore.BatchCRUD.Infrastructures.Models;

namespace NetCore.BatchCRUD.Infrastructures.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }

        public BookContext()
        {

        }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
