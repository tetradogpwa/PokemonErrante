using Gabriel.Cat.S.Extension;
using PokemonGBAFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PokemonErranteGBA.Blazor2.Helpers
{
    public class RomPokemon
    {
       public bool EstaCargado { get; private set; } = false;
        public Edicion Edicion => RomData.Edicion;
        public IList<Pokemon> Pokemon { get; private set; }
        public RomGba RomData { get; set; }

        public void LoadPokemon()
        {
            Pokemon =  PokemonGBAFramework.Core.Pokemon.Get(RomData);
            EstaCargado = true;
            Console.WriteLine("Se ha cargado la rom correctamente");
        }
    }
}
