using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MyOwnStore.Libraries.Lang;

namespace MyOwnStore.Models
{
    public class Category
    {
        /* PK */
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [MinLength(4, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E001")]
        public string Name { get; set; }
        /*
         * Nome: Telefone sem fio
         * Slug: 
         * 
         *www.loja.com.br/categoria/1 (url não amigavél/ normal)
         *www.loja.com.br/categoria/informatica (url amigável/ com Slug)
         * 
         * 
         */
        [Display(Name = "Slug")]
        [Required(ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E003")]
        [MinLength(2, ErrorMessageResourceType = typeof(lang_pt), ErrorMessageResourceName = "MSG_E001")]
        public string Slug { get; set; }
        /*
         *Auto-Relacionamento
         * 1 Informatica - p:null
         * - 2 Mouse p:1
         * -- 3 Mouse sem fio p:2
         * -- 4 Mouse Gamer p:2
         */
        [Display(Name = "Id Categoria pai")]
        public int? ParentCategoryId { get; set; }
        /*
         * ORM - Entity Framwork Core
         * 
         */
         [ForeignKey("ParentCategoryId")]
        [Display(Name = "Categoria Pai")]
        public virtual Category ParentCategory { get; set; }
    }
}
