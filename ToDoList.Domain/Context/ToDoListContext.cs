using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Context
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext()
        {
        }

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(@"Data Source=C:\ToDoDatabase.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .ToTable("TO_DO_TASK");
            modelBuilder.Entity<ToDoTask>()
                .HasKey(x => x.TaskId);
            modelBuilder.Entity<ToDoTask>()
                .OwnsMany(x => x.SubTasks);
            modelBuilder.Entity<ToDoTask>()
                .HasQueryFilter(x => !x.IsDeleted);
        }
    }
}