using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting
{
    public class ConfigureService
    {
        public static void ConfigureDependencies(IServiceCollection serviceCollection) 
        {
            serviceCollection.AddTransient<IPessoaService, PessoaService>(); // transienty em cada request cria uma instancia de PessoaService
        }
    }
}
