using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Libraries.FileUpload
{
    public class UploadManager
    {
        public static string StoreLocalImage(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/upload/temp",fileName);

            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine("/uploads/temp", fileName);
        }
        public static bool RemoveLocalImage(string filepath)
        {
            //Deletar imagem
            string _filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filepath.TrimStart('/'));
            if (File.Exists(_filepath))
            {
                File.Delete(_filepath);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
