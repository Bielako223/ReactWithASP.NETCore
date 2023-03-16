using Microsoft.EntityFrameworkCore;
namespace aspnetserver.Data
{
    internal sealed class appDBContext: DbContext
    {
        public DbSet<Post> Post { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Post[] poststoSeed = new Post[6];
            for (int i = 1; i <=6; i++)
            {
                poststoSeed[i-1] = new Post {
                        PostId = i,
                        Title = $"Post {i}",
                        Content = $" This is post number: {i}"
                    };
            }

            modelBuilder.Entity<Post>().HasData(data: poststoSeed);
        }
    }
}
