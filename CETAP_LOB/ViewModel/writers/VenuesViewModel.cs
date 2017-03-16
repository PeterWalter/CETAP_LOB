// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.writers.VenuesViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FeserWard.Controls;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using CETAP_LOB.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using LOB.Search;

namespace CETAP_LOB.ViewModel.writers
{
  public class VenuesViewModel : ViewModelBase
  {
    private string _mystatus = "";
    public const string StatusPropertyName = "Status";
    public const string ProvincesPropertyName = "Provinces";
    public const string IsDirtyPropertyName = "IsDirty";
    public const string SelectedVenuePropertyName = "SelectedVenue";
    public const string SpecialSessionPropertyName = "SpecialSession";
    public const string RemoteVenuesPropertyName = "RemoteVenues";
    public const string NationalVenuesPropertyName = "NationalVenues";
    public const string TestVenuesPropertyName = "TestVenues";
    private List<ProvinceBDO> _myprovs;
    private bool _isDirty;
    private VenueBDO _selectedVenue;
    private ObservableCollection<VenueBDO> _specialSession;
    private ObservableCollection<VenueBDO> _remotes;
    private ObservableCollection<VenueBDO> _national;
    private ObservableCollection<VenueBDO> _venues;
    private IDataService _service;

    public RelayCommand CreateVenueCommand { get; private set; }

    public RelayCommand DeleteVenueCommand { get; private set; }

    public RelayCommand SaveVenueCommand { get; private set; }

    public RelayCommand UpdateVenueCommand { get; private set; }

    public RelayCommand<VenueBDO> SelectedVenueCommand { get; private set; }

    public IIntelliboxResultsProvider VenueProvider { get; private set; }

    public string Status
    {
      get
      {
        return this._mystatus;
      }
      set
      {
        if (this._mystatus == value)
          return;
        this._mystatus = value;
        this.RaisePropertyChanged("Status");
      }
    }

    public bool canCreateVenue { get; private set; }

    public List<ProvinceBDO> Provinces
    {
      get
      {
        return this._myprovs;
      }
      set
      {
        if (this._myprovs == value)
          return;
        this._myprovs = value;
        this.RaisePropertyChanged("Provinces");
      }
    }

    public bool IsDirty
    {
      get
      {
        return this._isDirty;
      }
      set
      {
        if (this._isDirty == value)
          return;
        this._isDirty = value;
        this.RaisePropertyChanged("IsDirty");
      }
    }

    public VenueBDO SelectedVenue
    {
      get
      {
        return this._selectedVenue;
      }
      set
      {
        if (this._selectedVenue == value)
          return;
        this._selectedVenue = value;
        this.RaisePropertyChanged("SelectedVenue");
        this.DeleteVenueCommand.RaiseCanExecuteChanged();
        this.UpdateVenueCommand.RaiseCanExecuteChanged();
        this.SaveVenueCommand.RaiseCanExecuteChanged();
      }
    }

    public ObservableCollection<VenueBDO> SpecialSession
    {
      get
      {
        return this._specialSession;
      }
      set
      {
        if (this._specialSession == value)
          return;
        this._specialSession = value;
        this.RaisePropertyChanged("SpecialSession");
      }
    }

    public ObservableCollection<VenueBDO> RemoteVenues
    {
      get
      {
        return this._remotes;
      }
      set
      {
        if (this._remotes == value)
          return;
        this._remotes = value;
        this.RaisePropertyChanged("RemoteVenues");
      }
    }

    public ObservableCollection<VenueBDO> NationalVenues
    {
      get
      {
        return this._national;
      }
      set
      {
        if (this._national == value)
          return;
        this._national = value;
        this.RaisePropertyChanged("NationalVenues");
      }
    }

    public ObservableCollection<VenueBDO> TestVenues
    {
      get
      {
        return this._venues;
      }
      set
      {
        if (this._venues == value)
          return;
        this._venues = value;
        this.RaisePropertyChanged("TestVenues");
      }
    }

    public VenuesViewModel(IDataService Service)
    {
      this._service = Service;
      this.registerCommands();
      this.InitializeModel();
    }

    private void InitializeModel()
    {
      this.Provinces = new List<ProvinceBDO>();
      this.VenueProvider = (IIntelliboxResultsProvider) new VenueResultsProvider(this._service);
      this.TestVenues = new ObservableCollection<VenueBDO>();
      this.Provinces = this._service.getAllProvinces();
      this.canCreateVenue = false;
      this.TestVenues = new ObservableCollection<VenueBDO>(this._service.GetAllvenues());
    }

    private void registerCommands()
    {
      this.UpdateVenueCommand = new RelayCommand((Action) (() => this.UpdateVenues()), (Func<bool>) (() => this.canDelete()));
      this.DeleteVenueCommand = new RelayCommand((Action) (() => this.DeleteVenue()), (Func<bool>) (() => this.canDelete()));
      this.CreateVenueCommand = new RelayCommand((Action) (() => this.CreateVenue()));
      this.SaveVenueCommand = new RelayCommand((Action) (() => this.SaveVenue()), (Func<bool>) (() => this.canSaveVenue()));
      this.SelectedVenueCommand = new RelayCommand<VenueBDO>((Action<VenueBDO>) (e => this.SelectVenue(e)));
    }

    private void SelectVenue(VenueBDO venue)
    {
      this.SelectedVenue = venue;
    }

    private bool canDelete()
    {
      if (this.SelectedVenue != null && this.SelectedVenue.VenueCode > 0)
        return !string.IsNullOrWhiteSpace(this.SelectedVenue.VenueName);
      return false;
    }

    private bool canSaveVenue()
    {
      if (this.SelectedVenue != null && !string.IsNullOrWhiteSpace(this.SelectedVenue.VenueName) && !string.IsNullOrWhiteSpace(this.SelectedVenue.ShortName))
        return this.canCreateVenue;
      return false;
    }

    private void SaveVenue()
    {
      string message = "";
      bool flag = this._service.addTestVenue(this.SelectedVenue, ref message);
      this.canCreateVenue = false;
      if (!flag)
      {
        int num = (int) ModernDialog.ShowMessage(message, "Add Test Venue", MessageBoxButton.OK, (Window) null);
      }
      this.Status = message;
      this.RefreshAsync();
    }

    private void UpdateVenues()
    {
      string message = "";
      if (!this._service.updateTestVenue(this.SelectedVenue, ref message))
      {
        int num = (int) ModernDialog.ShowMessage(message, "Update Test Venue", MessageBoxButton.OK, (Window) null);
      }
      this.IsDirty = false;
      this.Status = message;
      this.RefreshAsync();
    }

    private void DeleteVenue()
    {
      if (ModernDialog.ShowMessage("Do you really want to delete this Test Site?", "Test Venue: " + this.SelectedVenue.ShortName.ToString() + " | Code: " + this.SelectedVenue.VenueCode.ToString(), MessageBoxButton.YesNo, (Window) null).ToString() == "Yes")
      {
        string message = "";
        this._service.deleteTestVenue(this.SelectedVenue.VenueCode, ref message);
        this.Status = message;
      }
      this.RefreshAsync();
    }

    private void CreateVenue()
    {
      this.SelectedVenue = (VenueBDO) null;
      this.SelectedVenue = new VenueBDO();
      this.canCreateVenue = true;
    }

    public void RefreshAsync()
    {
      this.TestVenues.Clear();
      this.TestVenues = new ObservableCollection<VenueBDO>(this._service.GetAllvenues());
    }
  }
}
