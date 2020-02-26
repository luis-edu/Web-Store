using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyOwnStore.Database;
using MyOwnStore.Libraries.Const;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyOwnStore.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private IConfiguration _config;
        private Context _db;
        public CollaboratorRepository(Context db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public void Delete(int id)
        {
            Collaborator data = GetCollaboratorById(id);
            _db.Remove(data);
            _db.SaveChanges();
        }

        public IPagedList<Collaborator> GetAllCollaborator(int? page, string search)
        {
            int PageNumber = page ?? 1;
            var query = _db.Collaborator.Where(x => x.Type != ConstTypes.Manager && x.Type != ConstTypes.Administrator).ToPagedList(PageNumber, _config.GetValue<int>("PageSize"));
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Email.Contains(search.Trim()) || x.Name.Contains(search.Trim())).ToPagedList(PageNumber, _config.GetValue<int>("PageSize"));
            }
            return query;
        }

        public IEnumerable<Collaborator> GetAllCollabotaros()
        {
            return  _db.Collaborator.AsNoTracking().ToList();
        }

        public IEnumerable<Collaborator> GetByEmail(string email)
        {
            return _db.Collaborator.AsNoTracking().Where(x => x.Email == email).ToList();
        }

        public Collaborator GetCollaboratorById(int id)
        {
            return _db.Collaborator.Find(id);
        }

        public Collaborator Login(string Email, string Password)
        {
            return _db.Collaborator.FirstOrDefault(x => x.Email == Email && x.Password == Password);
        }

        public void Register(Collaborator data)
        {
            _db.Add(data);
            _db.SaveChanges();
        }

        public void Update(Collaborator data)
        {
            _db.Update(data);
            _db.Entry(data).Property(a => a.Password).IsModified = false;
            _db.SaveChanges();
        }

        public void UpdatePassword(Collaborator collaborator)
        {
            _db.Update(collaborator);
            _db.Entry(collaborator).Property(a => a.Name).IsModified = false;
            _db.Entry(collaborator).Property(a => a.Email).IsModified = false;
            _db.Entry(collaborator).Property(a => a.Type).IsModified = false;
            _db.SaveChanges();
        }
    }
}
