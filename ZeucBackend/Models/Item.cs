using System.Collections.Generic;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int SubcategoryId { get; set; }
    public Dictionary<string, object> metadata { get; set; }
}