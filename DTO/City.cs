namespace SGSTest.DTO;

public class City {
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public static City From(Models.City city) {
    return new() { 
      Id = city.Id,
      Name = city.Name
    };
  }
}