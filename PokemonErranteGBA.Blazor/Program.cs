﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Blazor.FileReader;

namespace PokemonErranteGBA.Blazor2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddFileReaderService(options => { options.InitializeOnFirstCall = true;options.UseWasmSharedBuffer = true;/*con esta opción carga rapido :D*/});
            
            await builder.Build().RunAsync();
        }
    }
}
