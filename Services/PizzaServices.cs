using API.Models;
namespace API.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas {get;}
    static int nextId = 4;
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { id = 1 ,name = "Classic Margherita" , isGlutenFree = false},
            new Pizza { id = 2 ,name = "Thin Crust" , isGlutenFree = true},
            new Pizza { id = 3, name = "Punjabi Stype", isGlutenFree = true}
        };
    }
    public static List<Pizza> getAll() => Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.id == id);

    public static void Add(Pizza pizza)
    {
        pizza.id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;
            
        Pizzas.Remove(pizza);
    }
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p=>p.id == pizza.id);
        if(index == -1)
            return; 
         Pizzas[index] = pizza;
    }
}