using BO.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validator
{
    public class UniqueListeIngredients : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Cette combinaison d'ingredients existe déjà";
        }

        public override bool IsValid(object value)
        {
            List<int> idsIngredientsValue = value as List<int>;
           
            foreach (var pizza in FakeDB.Instance.Pizzas)
            {
                int comparator = 0;
                if (pizza.Ingredients.Count() == idsIngredientsValue.Count())
                {
                    List<int> idsIngredientsPizza = pizza.Ingredients.Select(x => x.Id).ToList();
                    foreach (var idIngredient in idsIngredientsPizza)
                    {
                        if (idsIngredientsValue.Contains(idIngredient)){
                            comparator++;
                        }
                    }
                    if (comparator == idsIngredientsValue.Count())
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
