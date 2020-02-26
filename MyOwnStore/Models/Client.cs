using MyOwnStore.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Models
{
    public class Client
    {
        /* PK */
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [MinLength(4,ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName ="MSG_E001")]
        [MaxLength(64, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [DataType(DataType.Date)]
        [Display(Name = "Aniversário")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [EmailAddress(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E004")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [MinLength(8, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E001")]
        [MaxLength(64, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E005")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Sexo")]
        public string Sex { get; set; }

        [Display(Name ="Situação")]
        public string Status { get; set; }
    }
}
