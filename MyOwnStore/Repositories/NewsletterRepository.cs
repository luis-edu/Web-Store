using MyOwnStore.Database;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MyOwnStore.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {
        private Context _db;
        public NewsletterRepository(Context db)
        {
            _db = db;
        }
        public IEnumerable<NewsletterMail> GetAll()
        {
            return _db.NewsletterMails.AsNoTracking().ToList();
        }

        public void Register(NewsletterMail data)
        {
            _db.Add(data);
            _db.SaveChanges();
        }

    }
}
