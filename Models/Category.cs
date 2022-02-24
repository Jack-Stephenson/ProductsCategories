using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace ProductsCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}
        [Required]
        [Display(Name ="Name")]
        [MinLength(2)]
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Association> Products {get;set;}
    }
}