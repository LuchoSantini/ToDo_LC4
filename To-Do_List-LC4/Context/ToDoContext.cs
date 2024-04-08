using Microsoft.EntityFrameworkCore;
using To_Do_List_LC4.Data.Entities;

namespace To_Do_List_LC4.Context
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Un usuario puede tener 1 o mas listas, varias listas pueden pertenecer a un usuario.
            modelBuilder.Entity<User>()
                .HasMany(u => u.ToDoItems)
                .WithOne(td => td.User)
                .HasForeignKey(td => td.UserId);
        }
    } 
}
