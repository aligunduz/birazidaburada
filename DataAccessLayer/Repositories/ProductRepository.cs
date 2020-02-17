using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceDb context):base(context)
        {  
        }
    }

    public interface IProductRepository : IGenericRepository<Product>
    {

    }
}
