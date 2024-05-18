namespace Products.DB;

public record Product
{
  public int Id { get; set; }
  public string ? Name { get; set; }
  public string ? Description { get; set; }
  public decimal ? Price { get; set; }
}

public class ProductDB {

  private static List<Product> data = new List<Product> {
    new Product { Id = 1, Name = "Product 1", Description = "Product 1 description", Price = 1.00m },
    new Product { Id = 2, Name = "Product 2", Description = "Product 2 description", Price = 2.00m },
    new Product { Id = 3, Name = "Product 3", Description = "Product 3 description", Price = 3.00m },
  };

  public static List<Product> GetProducts() {
    return data;
  }

  public static Product ? GetProduct(int id) {
    return data.SingleOrDefault(product => product.Id == id);
  }

  public static Product CreateProduct(Product product) {
    data.Add(product);
    return product;
  }

  public static Product UpdateProduct(int id, Product product) {
    data = data.Select(product => product.Id == id ? product = product : product).ToList();
    return product;
  }

  public static void RemoveProduct(int id) {
    data = data.FindAll(product => product.Id != id).ToList();
  }
}
