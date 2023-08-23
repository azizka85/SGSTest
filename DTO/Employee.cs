namespace SGSTest.DTO;

public class Employee {
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public static Employee From(Models.Employee employee) {
    return new() {
      Id = employee.Id,
      Name = employee.Name
    };
  }
}