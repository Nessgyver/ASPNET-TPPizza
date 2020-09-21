using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO.Database
{
    public class FakeDB
    {
        private static readonly Lazy<FakeDB> lazy =
           new Lazy<FakeDB>(() => new FakeDB());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDB Instance { get { return lazy.Value; } }

        private FakeDB()
        {
            InitialiserDatas();
        }

        public List<Ingredient> IngredientsDisponibles { get; private set; } = null;
        public List<Pate> PatesDisponibles { get; private set; } = null;
        public List<Pizza> Pizzas { get; private set; } = null;

        private void InitialiserDatas()
        {
            //initialisation de la liste des ingrédients
            this.IngredientsDisponibles = new List<Ingredient>
            {
                new Ingredient{Id=1,Nom="Mozzarella"},
                new Ingredient{Id=2,Nom="Jambon"},
                new Ingredient{Id=3,Nom="Tomate"},
                new Ingredient{Id=4,Nom="Oignon"},
                new Ingredient{Id=5,Nom="Cheddar"},
                new Ingredient{Id=6,Nom="Saumon"},
                new Ingredient{Id=7,Nom="Champignon"},
                new Ingredient{Id=8,Nom="Poulet"}
            };

            //initialisation de la liste des pâtes
            this.PatesDisponibles = new List<Pate>
            {
                new Pate{ Id=1,Nom="Pate fine, base crême"},
                new Pate{ Id=2,Nom="Pate fine, base tomate"},
                new Pate{ Id=3,Nom="Pate épaisse, base crême"},
                new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            };

            //ajout d'une pizza à la liste pour avoir des données à afficher 
            //au lancement de l'application
            this.Pizzas = new List<Pizza>()
            {
                new Pizza{Id=1, Nom="Reine", 
                                Pate=this.PatesDisponibles.ElementAt(1), 
                                Ingredients= new List<Ingredient>
                                {
                                    this.IngredientsDisponibles.ElementAt(0),
                                    this.IngredientsDisponibles.ElementAt(1),
                                    this.IngredientsDisponibles.ElementAt(6)
                                }
                   
                }
            };               
        }
    }
}
