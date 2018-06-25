using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yostocks.Api.Application.Interfaces;
using Yostocks.Api.Domain.Fragments;
using Yostocks.Api.Domain.Stocks;
using Yostocks.Api.Domain.YostocksUsers;

namespace Yostocks.Api.Persistence
{
    public class YostocksDbContext : DbContext, IDatabaseService
    {
        public DbSet<YostocksUser> YostocksUsers { get ; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Fragment> Fragments { get; set; }


    }
}
