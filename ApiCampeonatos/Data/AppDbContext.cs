using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCampeonatos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :  base(options) { }
                
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }        
    }
}
