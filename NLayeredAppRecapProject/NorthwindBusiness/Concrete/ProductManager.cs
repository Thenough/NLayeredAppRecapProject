using NorthwindBusiness.Abstract;
using NorthwindEntities.Concrete;
using NrthwindDataAccess.Abstract;
using NrthwindDataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll().Where(p=>p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetProductsByName(string productName)
        {
            return _productDal.GetAll().Where(p => p.ProductName.ToLower().Contains(productName)).ToList();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
