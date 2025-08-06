using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class SitesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SitesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{category}/{subcategory}")]
    public IActionResult GetProductsSite(string category, string subcategory)
    {
        var categoryId = _context.Categories
            .Where(c => c.Link == category)
            .Select(c => c.Id)
            .FirstOrDefault();
        
        Console.WriteLine($"Category: {_context.Categories.FirstOrDefault()}");

        var subcategoryId = _context.Subcategories
            .Where(s => s.Link == subcategory && s.CategoryId == categoryId)
            .Select(s => s.Id)
            .FirstOrDefault();

        Console.WriteLine($"Category: {_context.Subcategories.FirstOrDefault()}");

        Console.WriteLine($"Category: {category}, Subcategory: {subcategory}");
        Console.WriteLine($"Category ID: {categoryId}, Subcategory ID: {subcategoryId}");

        if (subcategoryId == 0)
        {
            return NotFound("Subcategory not found");
        }

        SubcategoryDto subcategoryData = GetSubcategoryData(subcategoryId);

        SiteDescription siteDescription = new SiteDescription
        {
            Header = subcategoryData.Name,
            Description = subcategoryData.Description,
            ProductContainers = new List<ProductContainer>()
        };

        List<Item> items = GetItemsBySubcategoryId(subcategoryId);

        siteDescription.ProductContainers.Add(
            new ProductContainer
            {
                Name = "Produkty",
                Items = items.Select(i => new ItemDisplay
                {
                    Name = i.Name,
                    Link = i.Link,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl
                }).ToList()
            }
        );

        return Ok(siteDescription);
    }

    private List<Item> GetItemsBySubcategoryId(int subcategoryId)
    {
        var items = _context.Items
            .Where(i => i.SubcategoryId == subcategoryId)
            .ToList();

        return items;
    }

    public class SubcategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    private SubcategoryDto GetSubcategoryData(int subcategoryId)
    {
        var subcategoryDescription = _context.Subcategories
            .Where(s => s.Id == subcategoryId)
            .Select(s => new { s.Name, s.Description })
            .FirstOrDefault();

        return new SubcategoryDto
        {
            Name = subcategoryDescription.Name,
            Description = subcategoryDescription.Description
        };
    }

    [HttpGet("bestsellers")]
    public IActionResult GetBestsellers()
    {
        var result = _context.SoldItemEntries
        .GroupBy(s => s.Item.Id)
        .Select(g => new
        {
            Count = g.Count(),
            Name = g.First().Item.Name,
            Link = g.First().Item.Link,
            Price = g.First().Item.Price,
            ImageUrl = g.First().Item.ImageUrl
        }).OrderByDescending(x => x.Count)
        .Take(5)
        .ToList();

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
        return Ok(item);
    }
}