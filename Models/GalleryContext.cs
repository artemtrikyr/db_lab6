using Microsoft.EntityFrameworkCore;
class GalleryContext : DbContext
{
    public DbSet<Painting> Paintings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Підключення до PostgreSQL
        optionsBuilder.UseNpgsql("Host=localhost;Database=labwork6;Username=postgres;Password=0000");
    }
}
