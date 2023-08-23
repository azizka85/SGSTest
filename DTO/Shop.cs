namespace SGSTest.DTO;

public class Shop {
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public static Shop From(Models.Shop shop) {
    return new() {
      Id = shop.Id,
      Name = shop.Name
    };
  }
}