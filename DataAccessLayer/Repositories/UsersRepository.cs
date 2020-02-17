using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        public UsersRepository(ECommerceDb context):base(context)
        {  
        }
    }

    public interface IUsersRepository : IGenericRepository<Users>
    {

    }
}
