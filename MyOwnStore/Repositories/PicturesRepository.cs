using MyOwnStore.Database;
using MyOwnStore.Models;
using MyOwnStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Repositories
{
    public class PicturesRepository : IPicturesRepository
    {
        private Context _db;
        public PicturesRepository(Context db)
        {
            _db = db;
        }
        public void Delete(int id)
        {
            Image img = _db.Images.Find(id);
            _db.Remove(img);
            _db.SaveChanges();
        }

        public void DeleteImagesOfProduct(int productId)
        {
            List<Image> img = _db.Images.Where(a => a.productId == productId).ToList();
            _db.RemoveRange(img);
            _db.SaveChanges();
        }

        public void Register(Image image)
        {
            _db.Add(image);
            _db.SaveChanges();
        }
    }
}
