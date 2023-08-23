namespace SGSTest.DTO;

public class Shift {
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public static Shift From(Models.Shift shift) {
    return new() {
      Id = shift.Id,
      Name = shift.Name
    };
  }
}
