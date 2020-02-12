using Microsoft.EntityFrameworkCore;
using MyOwnStore.Database;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private Context _db;
        public ClientRepository(Context db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            Client instance = GetClientById(id);
            _db.Remove(instance);
            _db.SaveChanges();

        }

        public IEnumerable<Client> GetAll()
        {
            return _db.Client.AsNoTracking().ToList();
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
