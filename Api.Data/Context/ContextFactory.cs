using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=MJV-28861;Initial Catalog=ApiJPV;Integrated Security=True";
            var OptionsBuilder = new DbContextOptionsBuilder<MyContext>();
            OptionsBuilder.UseSqlServer(connectionString);
            return new MyContext(OptionsBuilder.Options);
        }
    }
}
