using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorWhyUseDbContextFactory.Components.Data
{
    /*
     * Add-Migration InitialCreate
     * Update-Database
     */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem { Id = 1, Priority = 2, TaskDesc = "Get gift for Mom" },
                new ToDoItem { Id = 2, Priority = 1, TaskDesc = "Make flight reservations for Christmas" },
                new ToDoItem { Id = 3, Priority = 3, TaskDesc = "Oil change for truck" }
            );
        }
    }
}
