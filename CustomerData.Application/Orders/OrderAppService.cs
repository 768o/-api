using CustomerData.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace CustomerData.Application.Orders
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderAppService : IApplicationService
    {
        private readonly ProductContext db;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public OrderAppService(ProductContext db)
        {
            this.db = db;
        }
        /// <summary>
        /// 获取订单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return db.Products.Select(d => d.Id.ToString()).ToList();
        }
    }
}
