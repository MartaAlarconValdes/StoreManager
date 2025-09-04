using LinqToDB.Mapping;

[Table(Name = "product")]
public class Product
{
    [PrimaryKey, Identity]
    [Column(Name = "nid")]
    public int nid { get; set; }

    [Column(Name = "ID")]
    public int ID { get; set; }

    [Column(Name = "Name")]
    public string Name { get; set; }

    [Column(Name = "Price")]
    public decimal Price { get; set; }

    [Column(Name = "Stock")]
    public int Stock { get; set; }
}
