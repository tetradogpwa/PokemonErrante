using PokemonGBAFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonErranteGBA.Blazor2.Helpers
{
    public class RomPokemon
    {
        IList<PokemonCompleto> pokedex = null;
        private RomGba rom;

        public RomGba Rom { get => rom; set { rom = value; pokedex = null; } }
        public bool EstaCargada => Rom != null;
        public IList<PokemonCompleto> Pokedex
        {

            get
            {
                if (pokedex == null)
                    pokedex = PokemonCompleto.GetPokedex(Rom);
                return pokedex;
            }
        }
    }
}
