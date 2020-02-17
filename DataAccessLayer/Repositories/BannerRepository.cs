using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        public BannerRepository(ECommerceDb context):base(context)
        {  
        }
    }

    public interface IBannerRepository : IGenericRepository<Banner>
    {

    }
}
