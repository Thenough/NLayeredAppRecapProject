using NorthwindEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NrthwindDataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {

    }
}
