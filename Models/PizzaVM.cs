using BO;
using BO.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPPizza.Models
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        [IngredientsQuantityValidator]
        [UniqueListeIngredients]
        public List<int> IdsIngredients { get; set; }
        public List<Pate> Pates { get; set; }
        [Required]
        public int? IdPate { get; set; }
    }
}