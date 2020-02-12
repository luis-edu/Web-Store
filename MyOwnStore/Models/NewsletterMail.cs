using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Models
{
    public class NewsletterMail
    {
        /* PK */
        public int Id { get; set; }

        [Required(ErrorMessage = "Você precisa preencher este campo para continuar!")]
        public string Email { get; set; }
    }
}
