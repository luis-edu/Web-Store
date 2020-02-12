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
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private Context _db;
        public CollaboratorRepository(Context db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            Collaborator data = GetCollaboratorById(id);
            _db.Remove(data);
            _db.SaveChanges();
        }

        public IEnumerable<Collaborator> GetAllCollabotaros()
        {
            return  _db.Collaborator.AsNoTracking().ToList();
        }

        public Collaborator GetCollaboratorById(int id)
        {
            return _db.Collaborator.Find(id);
        }

        public void Register(Collaborator data)
        {
            _db.Add(data);
            _db.SaveChanges();
        }

        public void Update(Collaborator data)
        {
            _db.Update(data);
            _db.SaveChanges();
        }
    }
}
