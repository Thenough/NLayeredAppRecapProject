using NorthwindEntities.Concrete;
using NrthwindDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NrthwindDataAccess.Concrete.NHibernate
{
    public class NHProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>
            {
                new Product(){
                ProductId = 1,
                ProductName = "Test",
                UnitPrice = 1500,
                CategoryId = 4,
                QuantityPerUnit = "4",
                UnitsInStock = 3}
            };

            return products;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
