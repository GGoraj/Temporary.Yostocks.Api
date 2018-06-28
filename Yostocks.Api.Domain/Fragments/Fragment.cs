using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yostocks.Api.Domain.Common;
using Yostocks.Api.Domain.Stocks;
using Yostocks.Api.Domain.YostocksUsers;

namespace Yostocks.Api.Domain.Fragments
{
    public class Fragment : IEntity
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int YostocksUserId { get; set; }
        public double PercentValue { get; set; } //expressed in 00.00% format

        //table definitions - https://msdn.microsoft.com/en-us/library/zed0k41d.aspx

        //navigation property
        public virtual Stock CompanyStock { get; set; }
        public virtual YostocksUser YostocksUser { get; set; }
    }
}
