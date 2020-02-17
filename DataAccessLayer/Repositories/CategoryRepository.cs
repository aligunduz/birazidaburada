using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository:BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceDb context):base(context)
        {  
        }
    }

    public interface ICategoryRepository : IGenericRepository<Category>
    {

    }
}
