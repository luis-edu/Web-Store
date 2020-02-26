using MyOwnStore.Libraries.Lang;
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

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [EmailAddress(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E004")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
