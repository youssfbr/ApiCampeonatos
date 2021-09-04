using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCampeonatos.Data
{
    public class Campeonato
    {
        public int Id { get; set; }
        public IEnumerable<Jogo> Jogadas { get; set; }
    }
}
