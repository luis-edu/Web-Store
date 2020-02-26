using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyOwnStore.Repositories.Contracts
{
    public interface IClientRepository
    {
        //Crud

        void Register(Client data); //Registra um cliente
        void Update(Client data); // Atualiza um cliente        
        void Delete(int id);//Remove um cliente
        Client GetClientById(int id);//Procura um cliente por ID
        Client Login(string Email, string Password);//Verifica as credenciais do cliente
        public IPagedList<Client> GetAll(int? page, string search);//Retorna todos os clientes e uma lista Paginada
    }
}
