using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validator
{
    public class IngredientsQuantityValidator : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "La pizza doit comprendre entre 2 et 5 ingredients";
        }

        public override bool IsValid(object value)
        {
            List<int> listeIdsIngredients = value as List<int>;
            bool isOk = true;
            if(listeIdsIngredients.Count()<2 || listeIdsIngredients.Count()>5)
            {
                isOk = false;
            }
            return isOk;
        }
    }
}
