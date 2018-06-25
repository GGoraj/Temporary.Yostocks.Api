using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yostocks.Api.Domain.Stocks;

namespace Yostocks.Api.Application.Interfaces
{
    public interface IStockRepository
    {
        IQueryable<Stock> GetStocks();
        Stock GetStock(string Brand, double percentage);
        Stock FindStock(int id);
        void CreateStock(Stock stock);
        int ModifyRemainingPercentage(int stockId, double newPercentage);

    }
}
