using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _context.Categories
            .Include(c => c.Subcategories)
            .Select(c => new CategoryDto
            {
                Name = c.Name,
                Link = c.Link,
                Subcategories = c.Subcategories.Select(sc => new SubcategoryDto
                {
                    Name = sc.Name,
                    Link = sc.Link
                }).ToList()
            })
            .ToList();

        return Ok(categories);
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return Ok(category);
    }
}