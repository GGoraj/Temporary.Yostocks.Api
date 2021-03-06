﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Yostocks.Api.Application.Interfaces;
using Yostocks.Api.Domain.Stocks;
using Yostocks.Api.Persistence;

namespace Yostocks.Api.Service.Models.Repositories
{
    public class CompanyStockRepository : IStockRepository
    {
        private YostocksDbContext _db;
        private DbSet<Stock> _companyStocks;

        //CONSTRUCTOR
        public CompanyStockRepository(YostocksDbContext dbContext)
        {
            _db = dbContext;
            _companyStocks = dbContext.Stocks;
        }

        //CREATE STOCK
        public void CreateStock(Stock stock)
        {
            _companyStocks.Add(stock);
            _db.SaveChangesAsync();
        }

        // FIND STOCK with BRAND and PERCENTAGE
        public Stock GetStock(string brand, double percentage)
        {
            Stock stock = _companyStocks
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
            return _companyStocks;
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