using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string path { get; set; }

        public int productId { get; set; }
        [ForeignKey("productId")]
        public virtual Product product { get; set; }
    }
}
