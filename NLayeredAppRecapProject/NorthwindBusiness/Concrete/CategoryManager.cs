using NorthwindBusiness.Abstract;
using NorthwindEntities.Concrete;
using NrthwindDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {

            _categoryDal = categoryDal;

        }
        public List<Category> GetAll()
        {
           return _categoryDal.GetAll();
        }
    }
}
