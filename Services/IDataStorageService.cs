using SGSTest.DTO;

namespace SGSTest.Services;

public interface IDataStorageService {
  void Save(string path, City city, Shop shop, Employee employee, Team team, Shift shift);
}