namespace SGSTest.Models;

public class Shop {
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public City City { get; set; } = new();
}
