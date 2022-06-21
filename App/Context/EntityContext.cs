using Microsoft.EntityFrameworkCore;

namespace App.Context;

public sealed class EntityContext : DbContext, IEntityContext
{
        public DbSet<Entity>? Entities { get; set; }
        
        public EntityContext() : base() {}

        public EntityContext(DbContextOptions options) : base(options)
        {
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                if (!optionsBuilder.IsConfigured)
                {
                        optionsBuilder.UseSqlite("Data Source=EntityDb.db");
                }
        }

        public new async Task<int> SaveChanges()
        {
                return await base.SaveChangesAsync();
        }
}
