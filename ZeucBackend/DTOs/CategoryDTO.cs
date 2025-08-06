using System.Collections.Generic;

public class CategoryDto
{
    public string Name { get; set; }
    public string Link { get; set; }
    public List<SubcategoryDto> Subcategories { get; set; }
}