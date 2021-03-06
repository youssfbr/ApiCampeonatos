using Microsoft.EntityFrameworkCore;

namespace ApiCampeonatos.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :  base(options) { }
                
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }        
    }
}
