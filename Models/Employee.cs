namespace SGSTest.Models;

public class Employee {
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public City City { get; set; } = new();
  public Shop Shop { get; set; } = new();
}