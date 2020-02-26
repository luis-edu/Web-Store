using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyOwnStore.Repositories.Contracts
{
    public interface IProductRepository
    {
        public void Register(Product product);
        public void Update(Product product);
        public void Delete(int id);
        public Product GetById(int id);
        public IPagedList<Product> GetAll(int? page, string search);
    }
}
