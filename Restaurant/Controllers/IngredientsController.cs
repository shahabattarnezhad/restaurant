using Microsoft.AspNetCore.Mvc;
using Restaurant.Data;
using Restaurant.Interfaces;
using Restaurant.Models;
using Restaurant.Services;

namespace Restaurant.Controllers;

public class IngredientsController : Controller
{
    private Repository<Ingredient> _ingredients;

    public IngredientsController(ApplicationDbContext context)
    {
        _ingredients = new Repository<Ingredient>(context);
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _ingredients.GetAllAsync();

        return View(result);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var result = 
            await _ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>());

        return View(result);
    }
}
