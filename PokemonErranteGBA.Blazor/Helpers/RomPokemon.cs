using PokemonGBAFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonErranteGBA.Blazor2.Helpers
{
    public class RomPokemon
    {
        public List<PokemonGBAFramework.Pokemon.Sprites.Frontales> ImagenesPokemon { get; set; }
        public List<PokemonGBAFramework.Pokemon.StatsPokemon> StatsPokemon { get; set; }
        public bool EstaCargado => ImagenesPokemon != null;
    }
}
