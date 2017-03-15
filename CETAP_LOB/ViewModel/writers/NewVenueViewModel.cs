// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.writers.NewVenueViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using System;
using System.Collections.Generic;

namespace CETAP_LOB.ViewModel.writers
{
  public class NewVenueViewModel : ViewModelBase
  {
    public const string ProvincesPropertyName = "Provinces";
    public const string VenuePropertyName = "Venue";
    private List<ProvinceBDO> _myprovs;
    private VenueBDO _myvenue;
    private IDataService _service;

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

    public VenueBDO Venue
    {
      get
      {
        return this._myvenue;
      }
      set
      {
        if (this._myvenue == value)
          return;
        this._myvenue = value;
        this.RaisePropertyChanged("Venue");
      }
    }

    public RelayCommand SaveVenueCommand { get; private set; }

    public NewVenueViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModel();
      this.registerCommands();
    }

    private void InitializeModel()
    {
      this.Venue = new VenueBDO();
      this.Provinces = this._service.getAllProvinces();
    }

    private void registerCommands()
    {
      this.SaveVenueCommand = new RelayCommand((Action) (() => this.SaveVenue()), (Func<bool>) (() => this.canSaveVenue()));
    }

    private bool canSaveVenue()
    {
      return this.Venue.VenueCode > 0;
    }

    private void SaveVenue()
    {
      string message = "";
      this._service.addTestVenue(this.Venue, ref message);
      Messenger.Default.Send<NotificationMessageAction<string>>(new NotificationMessageAction<string>(message, new Action<string>(this.SendMessageCallback)));
    }

    private void SendMessageCallback(string message)
    {
      int num = message == "Refresh Venues" ? 1 : 0;
    }
  }
}
