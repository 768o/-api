using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerData.Core.Products
{
    [Table("t_bi_product")]
    public class Product : Entity<int>
    {

    }
}
