using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;
using Task = TodoList.Api.Entities.Task;

namespace TodoList.Api.Data;

public class TaskStoreContext(DbContextOptions<TaskStoreContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks => Set<Task>();

    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { Id = 1, Name = "Fighting" },
            new { Id = 2, Name = "Roleplaying" },
            new { Id = 3, Name = "Sports" },
            new { Id = 4, Name = "Racing" },
            new { Id = 5, Name = "Kids and Family" }
        );
    }
}
