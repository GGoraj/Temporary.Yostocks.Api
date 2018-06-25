using Yostocks.Api.Service.Models.Entities;

namespace Yostocks.Api.Service.Models
{
    public class Fragment : IEntity
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int YostocksUserId { get; set; }
        public double PercentValue { get; set; } //expressed in 00.00% format

        //table definitions - https://msdn.microsoft.com/en-us/library/zed0k41d.aspx

        //navigation property
        public virtual Stock Stock { get; set; }
        public virtual YostocksUser YostocksUser { get; set; }
    }
}