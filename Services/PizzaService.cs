using PizzaApi.Models;

namespace PizzaApi.Services;

public static class PizzaService {
  static List<Pizza> Pizzas { get; }
  static int _nextId = 3;

  static PizzaService() {
    Pizzas = new List<Pizza>() {
      new Pizza() { Id = 1, Name = "Pepperoni", GlutenFree = false },
      new Pizza() { Id = 2, Name = "Cheese", GlutenFree = true }
    };
  }

  public static List<Pizza> GetAll() => Pizzas;
  public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

  public static void Add(Pizza pizza) {
    pizza.Id = _nextId++;
    Pizzas.Add(pizza);
  }

  public static void Delete(int id) {
    var pizza = Get(id);
    if (pizza is not null) {
      Pizzas.Remove(pizza);
    }
  }

  public static void Update(Pizza pizza) {
    var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
    if (index >= 0) {
      Pizzas[index] = pizza;
    }
  }
}
