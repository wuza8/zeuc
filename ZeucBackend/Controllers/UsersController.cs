using System.Linq;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Items.ToList());

    [HttpPost]
    public IActionResult Create(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
        return Ok(item);
    }
}