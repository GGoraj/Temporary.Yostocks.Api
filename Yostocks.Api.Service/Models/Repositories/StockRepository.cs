using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Yostocks.Api.Service.Models.Repositories
{
    public class StockRepository : IStockRepository
    {
        private ApplicationDbContext _db;
        private DbSet<Stock> _stocks;

        //CONSTRUCTOR
        public StockRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            _stocks = dbContext.Stocks;
        }

        //CREATE STOCK
        public void CreateStock(Stock stock)
        {
            _stocks.Add(stock);
            _db.SaveChangesAsync();
        }

        // FIND STOCK with BRAND and PERCENTAGE
        public Stock GetStock(string brand, double percentage)
        {
            Stock stock = _stocks
                        .Where(b => b.Brand == brand)
                        .Where(a => a.RemainingPercentage > percentage)
                        .FirstOrDefault();
            return stock;
        }


        // GET TASK BY ID
        public Stock FindStock(int id)
        {
            return _db.Stocks.Find(id);
        }

        


        // GET ALL STOCKS
        public IQueryable<Stock> GetStocks()
        {
            // mobile app requests all stacks
            // to display images, stock names and description
            //in ListView, so the user can choose stock to invest in
            return _stocks;
        }

        public int ModifyRemainingPercentage(int stockId, double newPercentage)
        {
            string trimmedStockPercentage = String.Format("{0:0.##}", newPercentage);
            Stock stock = FindStock(stockId);
            stock.RemainingPercentage = Convert.ToDouble(trimmedStockPercentage);
            return  _db.SaveChanges();
        }
    }
}