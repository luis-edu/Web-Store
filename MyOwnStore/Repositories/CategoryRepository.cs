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
    public class CategoryRepository : ICategoryRepository
    {
        private IConfiguration _config;
        private Context _db;
        public CategoryRepository(Context db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public void Delete(int id)
        {
            Category instace = GetById(id);
            _db.Remove(instace);
            _db.SaveChanges();
        }

        public IPagedList<Category> GetAll(int? page, string search)
        {
            int PageNumber = page ?? 1;

            var query = _db.Category.AsNoTracking().Include(a => a.ParentCategory).ToPagedList(PageNumber, _config.GetValue<int>("PageSize"));
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search.Trim())).ToPagedList(PageNumber, _config.GetValue<int>("PageSize"));
            }
            return query;
        }
        public IEnumerable<Category> GetAll()
        {
            return _db.Category.AsNoTracking().ToList();
        }

        public Category GetById(int id)
        {
            return _db.Category.Find(id);
        }

        public void Register(Category category)
        {
            _db.Add(category);
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Update(category);
            _db.SaveChanges();
        }
    }
}
