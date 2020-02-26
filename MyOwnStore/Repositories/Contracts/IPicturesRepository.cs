using MyOwnStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Repositories.Contracts
{
    public interface IPicturesRepository
    {
        public void Register(Image image);
        public void Delete(int id);
        public void DeleteImagesOfProduct(int productId);
    }
}
