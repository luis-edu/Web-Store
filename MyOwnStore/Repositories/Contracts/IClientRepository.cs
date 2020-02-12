using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Repositories.Contracts
{
    public interface IClientRepository
    {
        //Crud

        void Register(Client data);
        void Update(Client data);
        void Delete(int id);
        Client GetClientById(int id);
        IEnumerable<Client> GetAll();
        Client Login(string Email, string Password);
    }
}
