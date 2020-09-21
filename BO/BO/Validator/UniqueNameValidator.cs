using BO.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validator
{
    public class UniqueNameValidator : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Ce nom de pizza est déjà pris!";
        }

        public override bool IsValid(object value)
        {
            String nomNouvellePizza = value as string;
            foreach (var pizza in FakeDB.Instance.Pizzas)
            {
                if (pizza.Nom.ToLower().Equals(nomNouvellePizza.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
