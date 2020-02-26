using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOwnStore.Libraries.FileUpload;

namespace MyOwnStore.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class ImageController : Controller
    {
        public IActionResult RegisterImage(IFormFile file)
        {//Armazena o arquivo
            var filePath = UploadManager.StoreLocalImage(file);
            if(filePath.Length > 0)
            {
                return Json(new { Message = filePath });
            }
            else
            {
                return Json(new { Message = "Error" });
            }
        }
        [HttpPost]
        public IActionResult DeleteImage(string path)
        {
            if (UploadManager.RemoveLocalImage(path))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}