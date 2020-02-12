using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        void Register(NewsletterMail data);
        IEnumerable<NewsletterMail> GetAll();
    }
}
