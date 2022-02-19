using Api.Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>)); // scoped em cada escopo cria uma instancia de baseRepository (se der f5 por exemplo ele muda)
            serviceCollection.AddDbContext<MyContext>(cs => cs.UseSqlServer(@"Data Source=MJV-28861;Initial Catalog=ApiJPV;Integrated Security=True")) ;

        }

       
    }
}
