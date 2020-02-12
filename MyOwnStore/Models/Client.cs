using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Models
{
    public class Client
    {
        /* PK */
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MinLength(4, ErrorMessage ="Este campo precisa ter ao menos {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [EmailAddress(ErrorMessage ="Digite um email válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        [MinLength(8,ErrorMessage = "Este campo deve ter no minimo {1} caracteres")]
        [MaxLength(32, ErrorMessage ="Este campo deve ter no máximo {1} caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Este campo é obrigatório")]
        public string Sex { get; set; }
    }
}
