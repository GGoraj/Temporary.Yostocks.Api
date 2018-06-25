using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yostocks.Api.Domain.Fragments;
using Yostocks.Api.Domain.Stocks;
using Yostocks.Api.Domain.YostocksUsers;

namespace Yostocks.Api.Application.Interfaces
{
    public interface IDatabaseService
    {
        DbSet<YostocksUser> YostocksUsers { get; set; }
        DbSet<Stock> Stocks { get; set; }
        DbSet<Fragment> Fragments { get; set; }
    }
}
