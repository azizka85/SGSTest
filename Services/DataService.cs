using SGSTest.DTO;

namespace SGSTest.Services;

public sealed class DataService : IDataService {
  private readonly List<Models.City> cities;
  private readonly List<Models.Shop> shops;
  private readonly List<Models.Employee> employees;
  private readonly List<Models.Team> teams;
  private readonly List<Models.Shift> shifts;

  public DataService() {
    cities = new List<Models.City>();
    shops = new List<Models.Shop>();
    employees = new List<Models.Employee>();
    teams = new List<Models.Team>();
    shifts = new List<Models.Shift>();

    SeedData();
  }

  public List<City> CitiesList() {
    return cities
      .Select(city => City.From(city))
      .ToList();
  }
  public List<Shop> ShopsList(int? cityId) {
    IEnumerable<Models.Shop> res = shops;

    if (cityId.HasValue)
      res = res
        .Where(shop => shop.City.Id == cityId.Value);        

    return res
      .Select(shop => Shop.From(shop))
      .ToList();
  }
  public List<Employee> EmployeesList(int? cityId, int? shopId) {
    IEnumerable<Models.Employee> res = employees;

    if (cityId.HasValue)
      res = res
        .Where(employee => employee.City.Id == cityId.Value);

    if (shopId.HasValue)
      res = res
        .Where(employee => employee.Shop.Id == shopId.Value);    

    return res
      .Select(employee => Employee.From(employee))
      .ToList();
  }
  public List<Team> TeamsList() {        
    return teams
      .Select(team => Team.From(team))
      .ToList();
  }
  public List<Shift> ShiftsList() {
    return shifts
      .Select(shift => Shift.From(shift))
      .ToList();
  }   

  private void SeedData() {
    cities.AddRange(
      new Models.City[] {
        new() { Id = 1, Name = "Almaty" },
        new() { Id = 2, Name = "Astana" },
        new() { Id = 3, Name = "Karagandy" },
        new() { Id = 4, Name = "Oskemen" },
        new() { Id = 5, Name = "Semei" },
        new() { Id = 6, Name = "Atyrau" },
        new() { Id = 7, Name = "Aktobe" },
        new() { Id = 8, Name = "Shymkent" }
      }
    );

    var citiesDic = cities.ToDictionary(city => city.Id);

    shops.AddRange(
      new Models.Shop[] {
        new() { Id = 1, Name = "Almaty shop #1", City = citiesDic[1] },
        new() { Id = 2, Name = "Almaty shop #2", City = citiesDic[1] },
        new() { Id = 3, Name = "Almaty shop #3", City = citiesDic[1] },
        new() { Id = 4, Name = "Astana shop #1", City = citiesDic[2] },
        new() { Id = 5, Name = "Astana shop #2", City = citiesDic[2] },
        new() { Id = 6, Name = "Astana shop #3", City = citiesDic[2] },
        new() { Id = 7, Name = "Karagandy shop #1", City = citiesDic[3] },
        new() { Id = 8, Name = "Karagandy shop #2", City = citiesDic[3] },
        new() { Id = 9, Name = "Oskemen shop #1", City = citiesDic[4] },
        new() { Id = 10, Name = "Semei shop #1", City = citiesDic[5] },
        new() { Id = 11, Name = "Atyrau shop #1", City = citiesDic[6] },
        new() { Id = 12, Name = "Aktobe shop #1", City = citiesDic[7] },
        new() { Id = 13, Name = "Shymkent shop #1", City = citiesDic[8] }
      }
    );

    var shopsDic = shops.ToDictionary(shop => shop.Id);

    employees.AddRange(
      new Models.Employee[] {
        new() { Id = 1, Name = "Almaty Employee #1", City = citiesDic[1], Shop = shopsDic[1] },
        new() { Id = 2, Name = "Almaty Employee #2", City = citiesDic[1], Shop = shopsDic[2] },
        new() { Id = 3, Name = "Almaty Employee #3", City = citiesDic[1], Shop = shopsDic[3] },
        new() { Id = 4, Name = "Astana Employee #1", City = citiesDic[2], Shop = shopsDic[4] },
        new() { Id = 5, Name = "Astana Employee #2", City = citiesDic[2], Shop = shopsDic[5] },
        new() { Id = 6, Name = "Astana Employee #3", City = citiesDic[2], Shop = shopsDic[6] },
        new() { Id = 7, Name = "Karagandy Employee #1", City = citiesDic[3], Shop = shopsDic[7] },
        new() { Id = 8, Name = "Karagandy Employee #2", City = citiesDic[3], Shop = shopsDic[8] },
        new() { Id = 9, Name = "Oskemen Employee #1", City = citiesDic[4], Shop = shopsDic[9] },
        new() { Id = 10, Name = "Semei Employee #1", City = citiesDic[5], Shop = shopsDic[10] },
        new() { Id = 11, Name = "Atyrau Employee #1", City = citiesDic[6], Shop = shopsDic[11] },
        new() { Id = 12, Name = "Aktobe Employee #1", City = citiesDic[7], Shop = shopsDic[12] },
        new() { Id = 13, Name = "Shymkent Employee #1", City = citiesDic[8], Shop = shopsDic[13] }
      }
    );

    teams.AddRange(
      new Models.Team[] {
        new() { Id = 1, Name = "Team #1" },
        new() { Id = 2, Name = "Team #2" },
        new() { Id = 3, Name = "Team #3" }
      }
    );

    shifts.AddRange(
      new Models.Shift[] {
        new() { Id = 1, Name = "Shift #1" },
        new() { Id = 2, Name = "Shift #2" },
        new() { Id = 3, Name = "Shift #3" }
      }
    );
  }
}