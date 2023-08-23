namespace SGSTest.DTO;

public class Team {
  public int Id { get; set; }
  public string Name { get; set; } = "";

  public static Team From(Models.Team team) {
    return new() {
      Id = team.Id,
      Name = team.Name
    };
  }
}