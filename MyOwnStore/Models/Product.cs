using MyOwnStore.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyOwnStore.Models
{
    public class Product
    {
        /*PK*/
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Quantidade")]
        [Range(0, 100000, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E006")]
        public int Quantity { get; set; }


        //Informações necessarias para calcular o frete
        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Peso")]
        [Range(0.001, 30, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E006")]
        public double Weight { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Largura")]
        [Range(11, 105, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E006")]
        public int Width { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Altura")]
        [Range(2, 105, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E006")]
        public int Height { get; set; }

        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Comprimento")]
        [Range(16, 105, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E006")]
        public int Length { get; set; }


        //Banco de dados - Relacionamento de tabelas
        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }


        //POO - Associação entre objetos
        [ForeignKey("CategoryId")]
        public virtual Category category { get; set; }

        /*
         * EF - ORM Biblioteca Unir - Banco de dados e POO. (ORM - Mapeamento de Objetos <-> Relacionamento)*
         * - Fluent API - Attributes
         */

        public virtual ICollection<Image> Images { get; set; }
    }
}
