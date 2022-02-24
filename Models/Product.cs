using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}
        [Required]
        [Display(Name ="Name")]
        [MinLength(2)]
        public string Name {get;set;}
        [Required]
        [Display(Name ="Description")]
        [MinLength(2)]
        public string Description {get;set;}
        [Required]
        [Display(Name ="Price")]
        [DataType(DataType.Currency)]
        public float Price {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public List<Association> Categories {get;set;}
    }
}