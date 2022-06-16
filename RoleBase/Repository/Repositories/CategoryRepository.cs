using DTOModel;
using Model;
using Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{

    public interface ICategoryRepository : IRepository<Category>
    {

    }
    public class CatrgoryRepository : Repository<Category>, ICategoryRepository
    {
        public CatrgoryRepository(Contex contex) : base(contex)
        {

        }
    }
}
