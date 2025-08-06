using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("/api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ItemsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("search")]
    public IActionResult SearchForItem(string query)
    {
        var result = _context.Items
            .Where(i => i.Name.ToLower().Contains(query.ToLower()))
            .Select(c => new
            {
                Name = c.Name,
                Price = c.Price,
                ImageUrl = c.ImageUrl,
                Link = c.Link
            }).Take(5).ToList();

        return Ok(result);
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