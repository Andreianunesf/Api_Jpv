using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Data.Mapping;

namespace Api.Data.Context 
{
    public class MyContext : DbContext
    {

        public DbSet<Pessoa> TB_Pessoa { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pessoa>(new PessoaMap().Configure);
        }
    }
}
