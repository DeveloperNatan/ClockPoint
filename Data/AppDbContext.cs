using Clock_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Clock_API.Data
{
    public class AppDbContext : DbContext
    {
        //holds database settings
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Ponto> Pontos { get; set; }
    }
}
