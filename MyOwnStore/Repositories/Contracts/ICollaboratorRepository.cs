using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyOwnStore.Repositories.Contracts
{
    public interface ICollaboratorRepository
    {
        void Register(Collaborator data);
        void Update(Collaborator data);
        void Delete(int id);
        Collaborator GetCollaboratorById(int id);
        IEnumerable<Collaborator> GetAllCollabotaros();
        Collaborator Login(string Email, string Password);
        IPagedList<Collaborator> GetAllCollaborator(int? page, string search);
        void UpdatePassword(Collaborator collaborator);
        IEnumerable<Collaborator> GetByEmail(string email);
    }
}
