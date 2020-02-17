using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ECommerceDb context):base(context)
        {  
        }
    }

    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {

    }
}
