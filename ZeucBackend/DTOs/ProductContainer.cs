using System.Collections.Generic;

public class ProductContainer
{
    public required string Name { get; set; }
    public required List<ItemDisplay> Items { get; set; }
}