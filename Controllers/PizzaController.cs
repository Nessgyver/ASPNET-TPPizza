using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPPizza.Database;
using TPPizza.Models;

namespace TPPizza.Controllers
{
    public class PizzaController : Controller
    {
     
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDB.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            
            return View(Getpizza(id));
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM pizzaVM = new PizzaVM() {   Pizza = new Pizza(), 
                                                Ingredients = FakeDB.Instance.IngredientsDisponibles, 
                                                Pates = FakeDB.Instance.PatesDisponibles}; 

            return View(pizzaVM);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM pizzaVM)
        {
            try
            {
                pizzaVM.Pizza.Pate = FakeDB.Instance.PatesDisponibles.FirstOrDefault(p => p.Id == pizzaVM.IdPate);
                foreach (var ingredient in pizzaVM.IdsIngredients)
                {
                    pizzaVM.Pizza.Ingredients.Add(FakeDB.Instance.IngredientsDisponibles.FirstOrDefault(i=>i.Id == ingredient));
                }
                FakeDB.Instance.Pizzas.Add(pizzaVM.Pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Getpizza(id));
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Méthode privée permettant de récupérer la pizza demandée par l'utilisateur
        private Pizza Getpizza(int id)
        {
            return FakeDB.Instance.Pizzas.Where(p => p.Id == id).FirstOrDefault();
        }

    }
}
