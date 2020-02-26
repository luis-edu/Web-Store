using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyOwnStore.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        void Register(Category category);
        void Update(Category category);
        void Delete(int id);
        Category GetById(int id);
        IPagedList <Category> GetAll(int? page, string search);

        IEnumerable<Category> GetAll();
    }
}
