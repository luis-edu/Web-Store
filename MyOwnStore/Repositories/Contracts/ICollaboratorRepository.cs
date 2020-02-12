using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Repositories.Contracts
{
    interface ICollaboratorRepository
    {
        void Register(Collaborator data);
        void Update(Collaborator data);
        void Delete(int id);
        Collaborator GetCollaboratorById(int id);
        IEnumerable<Collaborator> GetAllCollabotaros();
    }
}
