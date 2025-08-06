// Models/User.cs
using System.Collections.Generic;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
    public List<Subcategory> Subcategories { get; set; }
}