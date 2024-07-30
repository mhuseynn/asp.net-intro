using Microsoft.AspNetCore.Mvc;
using ProductTask.Models;

namespace ProductTask.Controllers;

public class ProductController : Controller
{

    public static List<Product> Products { get; set; }


    static ProductController()
    {
        Products = new List<Product>();

        for (int i = 1; i <= 20; i++)
        {
            Products.Add(new Product
            {
                Id = i,
                Name = "Product " + i,
                Price = 10
            });
        }
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult GetAllProducts()
    {
        return View(Products);
    }


    public IActionResult GetProductById(int id)
    {

        var product = Products?.FirstOrDefault(p => p.Id == id);
        return View(product);

    }

    public IActionResult DeleteProductById(int id)
    {
        var product = Products?.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            Products?.Remove(product);
        }
        return RedirectToAction("GetAllProducts");
    }


}
