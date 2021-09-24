using System.Collections.Generic;

namespace ApiCampeonatos.Entities
{
    public class Campeonato
    {
        public int Id { get; set; }
        public ICollection<Jogo> Jogadas { get; set; }        
    }
}
