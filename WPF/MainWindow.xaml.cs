using Microsoft.Win32;
using SGSTest.DTO;
using SGSTest.Services;
using System;
using System.Threading;
using System.Windows;

namespace SGSTest.WPF;

public partial class MainWindow : Window {
  private readonly IDataService _dataService;
  private readonly IDataStorageService _storageService;

  private City? _selectedCity;
  private Shop? _selectedShop;
  private Employee? _selectedEmployee;
  private Team? _selectedTeam;
  private Shift? _selectedShift;

  public MainWindow(IDataService dataService, IDataStorageService storageService) {
    _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
    _storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));

    InitializeComponent();

    FillData();
  }

  private void FillData() {
    CityCB.ItemsSource = _dataService.CitiesList();
    TeamCB.ItemsSource = _dataService.TeamsList();
    ShiftCB.ItemsSource = _dataService.ShiftsList();

    SelectCity(null);
  }
  private void SelectCity(int? cityId) {
    ShopCB.ItemsSource = _dataService.ShopsList(cityId);

    SelectShop(cityId, null);
  }
  private void SelectShop(int? cityId, int? shopId) {
    EmployeeCB.ItemsSource = _dataService.EmployeesList(cityId, shopId);
  }

  private void CityCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
    _selectedCity = CityCB.SelectedItem as City;

    CityTB.Text = _selectedCity?.Name;

    SelectCity(_selectedCity?.Id);
  }
  private void ShopCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
    _selectedShop = ShopCB.SelectedItem as Shop;

    ShopTB.Text = _selectedShop?.Name;

    SelectShop(_selectedCity?.Id, _selectedShop?.Id);
  }
  private void EmployeeCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
    _selectedEmployee = EmployeeCB.SelectedItem as Employee;

    EmployeeTB.Text = _selectedEmployee?.Name;

    CheckSaveButton();
  }
  private void TeamCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
    _selectedTeam = TeamCB.SelectedItem as Team;

    TeamTB.Text = _selectedTeam?.Name;

    CheckSaveButton();
  }
  private void ShiftCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
    _selectedShift = ShiftCB.SelectedItem as Shift;

    ShiftTB.Text = _selectedShift?.Name;

    CheckSaveButton();
  }

  private void SaveBtn_Click(object sender, RoutedEventArgs e) {
    var dialog = new SaveFileDialog();

    dialog.Title = "Please, choose file to save";
    dialog.DefaultExt = "json";

    if (dialog.ShowDialog() == true)
      _storageService.Save(
        dialog.FileName, 
        _selectedCity!, _selectedShop!, _selectedEmployee!, 
        _selectedTeam!, _selectedShift!
      );
  }

  private void CheckSaveButton() {
    SaveBtn.IsEnabled =
      _selectedCity != null &&
      _selectedShop != null &&
      _selectedEmployee != null &&
      _selectedTeam != null &&
      _selectedShift != null;
  }  
}
