using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("Pizza")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

     // GET all action
     [HttpGet]
     public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.getAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;   
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.id},pizza);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult update(int id, Pizza pizza){
        if(id != pizza.id){
            return BadRequest();
        }

        var existingPizza = PizzaService.Get(id);
        if(existingPizza == null){
            return NotFound();
        }
        PizzaService.Update(pizza);
        return NoContent();
    }
    // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            {
                var pizza = PizzaService.Get(id);
   
                    if (pizza is null)
                       return NotFound();
       
                 PizzaService.Delete(id);
   
                 return NoContent();
              }
}