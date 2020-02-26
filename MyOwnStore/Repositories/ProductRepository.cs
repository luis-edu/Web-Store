using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyOwnStore.Database;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyOwnStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private Context _db;
        private IConfiguration _config;
        public ProductRepository(Context db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public void Delete(int id)
        {
            var product = GetById(id);
            _db.Remove(product);
            _db.SaveChanges();
        }

        public IPagedList<Product> GetAll(int? page, string search)
        {
            int PageNumber = page ?? 1;

            var data = _db.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(a => a.Name.Contains(search.Trim() ) );
            }
            return data.Include(a => a.Images).ToPagedList(PageNumber, _config.GetValue<int>("PageSize"));
        }

        public Product GetById(int id)
        {
            return _db.Products.Include(a => a.Images).Where(a => a.Id == id).FirstOrDefault();
        }

        public void Register(Product product)
        {
            _db.Add(product);
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }
    }
}
