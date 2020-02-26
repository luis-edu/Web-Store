using Microsoft.EntityFrameworkCore;
using MyOwnStore.Models;

namespace MyOwnStore.Database
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Client> Client { get; set; }
        public DbSet<NewsletterMail> NewsletterMails { get; set; }
        public DbSet<Collaborator> Collaborator { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
