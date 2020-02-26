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
    public class ClientRepository : IClientRepository
    {
        private Context _db;
        private IConfiguration _config;
        public ClientRepository(Context db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public void Delete(int id)
        {
            Client instance = GetClientById(id);
            _db.Remove(instance);
            _db.SaveChanges();

        }

        public IPagedList<Client> GetAll(int? page,string search)
        {
            int PageNumber = page ?? 1;

            var data = _db.Client.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(a => a.Name.Contains(search.Trim()) || a.Email.Contains(search.Trim() ));
            }
            return data.ToPagedList(PageNumber, _config.GetValue<int>("PageSize"));
        }

        public Client GetClientById(int id)
        {
            return _db.Client.Find(id);
        }

        public Client Login(string Email, string Password)
        {
            return _db.Client.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }

        public void Register(Client data)
        {
            _db.Add(data);
            _db.SaveChanges();
        }

        public void Update(Client data)
        {
            _db.Update(data);
            _db.SaveChanges();
        }
    }
}
