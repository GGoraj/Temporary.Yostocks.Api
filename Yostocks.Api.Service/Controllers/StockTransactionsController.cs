using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Yostocks.Api.Service.Models;
using Yostocks.Api.Service.Models.Repositories;

namespace Yostocks.Api.Service.Controllers
{
    public class StockTransactionsController : ApiController
    {


        private IStockRepository _stockRepository;
        private IFragmentRepository _fragmentRepository;


        //CONSTRUCTOR
        //dependency injection config file in Yostocks.Api.Service/App_Start/UnityConfig.cs
        public StockTransactionsController(IStockRepository stockRepository,
                                            IFragmentRepository fragmentRepository)
        {
            _stockRepository = stockRepository;
            _fragmentRepository = fragmentRepository;
        }


        // GET: api/Stocks
        [HttpGet]
        public IQueryable<Stock> GetStocks()
        {
            // mobile app requests all stacks
            // to display images, stock names and description
            //in ListView, so the user can choose stock to invest in
            return _stockRepository.GetStocks();
        }


        //POST
        [Route("api/StockTransactions/BuyStockFragment")]
        public IHttpActionResult BuyFragment([FromBody] BuyStockFragmentBindingModel buyFragmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // calculate Percent Value of user request
            double requestedPercentage = (buyFragmentModel.RequiredAmount / buyFragmentModel.CurrentStockPrice) * 100;
            string stringRequestedPercentage = String.Format("{0:0.##}", requestedPercentage);
            requestedPercentage = Convert.ToDouble(stringRequestedPercentage);

            String time = DateTime.Now.ToLongTimeString();
            String date = DateTime.Now.ToLongDateString();
            
            while (true)
            {

                Stock stock = _stockRepository.GetStock(buyFragmentModel.Brand, 0);

                //checking if stock wasn't found
                if (stock.Equals(null))
                {
                    return Ok("Error - No such stock available");
                }

                double remainingStockPercent = stock.RemainingPercentage;
                //if stock.RemainingPercentage is > requested
                if (remainingStockPercent > requestedPercentage)
                {

                    Fragment fragment = new Fragment
                    {
                        YostocksUserId = buyFragmentModel.YostocksUserId,
                        StockId = stock.Id,
                        PercentValue = requestedPercentage
                    };

                    _fragmentRepository.AddFragmentAsync(fragment);

                    //trim remaining percentage before adding to Stock column
                    double newStockPercentage = remainingStockPercent - requestedPercentage;
                    _stockRepository.ModifyRemainingPercentage(stock.Id, newStockPercentage);
                    return StatusCode(HttpStatusCode.Accepted);

                }

                //if stock.RemainingPercentage is just enough == requested
                //then create new stock of required brand - to fill the vacancy after the fragmented stock.
                if (remainingStockPercent == requestedPercentage)
                {
                    Fragment fragment = new Fragment
                    {
                        YostocksUserId = buyFragmentModel.YostocksUserId,
                        StockId = stock.Id,
                        PercentValue = requestedPercentage
                    };
                    db.Fragments.Add(fragment);

                    //create new stock of the same brand
                    Stock newStock = new Stock()
                    {
                        Brand = buyFragmentModel.Brand,
                        RemainingPercentage = 100,
                        PriceWhenPurchased = 6300.3434,
                        DateGenerated = date,
                        TimeGenerated = time,
                        LogoImagePath = stock.LogoImagePath

                    };
                    db.Stocks.Add(newStock);
                    db.SaveChanges();
                    return StatusCode(HttpStatusCode.Created);
                }
                //if stock.RemainingPercentage is NOT ENOUGH
                if (remainingStockPercent < requestedPercentage)
                {

                    Fragment fragment = new Fragment
                    {
                        YostocksUserId = buyFragmentModel.YostocksUserId,
                        StockId = stock.Id,
                        PercentValue = remainingStockPercent
                    };
                    db.Fragments.Add(fragment);

                    //set remaining stock %
                    stock.RemainingPercentage = 0;

                    //calculate new required percent value
                    requestedPercentage = Math.Abs(remainingStockPercent - requestedPercentage);

                    //trim this value to 2 places from coma
                    string trimmedStockPercentage = String.Format("{0:0.##}", requestedPercentage);

                    //double value of new request
                    requestedPercentage = Convert.ToDouble(trimmedStockPercentage);


                    //create new stock of the same brand
                    Stock newStock = new Stock()
                    {
                        Brand = buyFragmentModel.Brand,
                        RemainingPercentage = 100,
                        PriceWhenPurchased = 6300.3434,
                        DateGenerated = date,
                        TimeGenerated = time,
                        LogoImagePath = stock.LogoImagePath

                    };
                    db.Stocks.Add(newStock);
                    db.SaveChanges();

                    //if its true, request can return
                    if (requestedPercentage == 0)
                    {
                        StatusCode(HttpStatusCode.Created);
                    }
                    //While(true) - stil true
                }
            }

        }




        // GET: api/Stocks/5
        [ResponseType(typeof(Stock))]
        public async Task<IHttpActionResult> GetStock(int id)
        {
            Stock stock = await db.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
       
        


    }
}
/*
{"YostocksUserId":"1", "Brand":"Amazon", "Currency":"DKK", "CurrentStockPrice":624.56, "RequiredAmount":0,
"Date":"11-06-2018", "Time":"22:54:00", "City":"Copenhagen", "Country":"Denmark"}

    */
