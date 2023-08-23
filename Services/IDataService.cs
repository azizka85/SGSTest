using SGSTest.DTO;

namespace SGSTest.Services;

public interface IDataService {
  List<City> CitiesList();
  List<Shop> ShopsList(int? cityId);
  List<Employee> EmployeesList(int? cityId, int? shopId);
  List<Team> TeamsList();
  List<Shift> ShiftsList();
}