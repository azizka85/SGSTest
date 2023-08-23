using SGSTest.DTO;
using System.Text.Json;

namespace SGSTest.Services;

public sealed class DataStorageService : IDataStorageService {
  public void Save(string path, City city, Shop shop, Employee employee, Team team, Shift shift) {
    var data = new { 
      city = city.Name,
      shop = shop.Name,
      employee = employee.Name,
      team = team.Name,
      shift = shift.Name
    };

    File.WriteAllText(
      path, 
      JsonSerializer.Serialize(data)
    );
  }
}