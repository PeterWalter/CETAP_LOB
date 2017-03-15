// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.writers.VenueViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using CETAP_LOB.BDO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Spatial;

namespace CETAP_LOB.ViewModel.writers
{
  public class VenueViewModel : ViewModelBase, INotifyDataErrorInfo
  {
    public Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
    public const string IsDirtyPropertyName = "IsDirty";
    public const string VenueCodePropertyName = "VenueCode";
    public const string VenueNamePropertyName = "VenueName";
    public const string ShortNamePropertyName = "ShortName";
    public const string WebSiteNamePropertyName = "WebSiteName";
    public const string RoomPropertyName = "Room";
    public const string VenueTypePropertyName = "VenueType";
    public const string ProvinceIDPropertyName = "ProvinceID";
    public const string AvailablePropertyName = "Available";
    public const string CapacityPropertyName = "Capacity";
    public const string DescriptionPropertyName = "Description";
    private bool _isDirty;
    private int _code;
    private string _venue;
    private string _sname;
    private string _webname;
    private string _room;
    private string _venueType;
    private int? _province;
    private bool _available;
    private int? _capacity;
    private string _comments;

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
        bool isDirty = this._isDirty;
        this._isDirty = value;
        this.RaisePropertyChanged<bool>("IsDirty", isDirty, value, true);
      }
    }

    public int VenueCode
    {
      get
      {
        return this._code;
      }
      set
      {
        if (this._code == value)
          return;
        int code = this._code;
        this._code = value;
        this.IsDirty = true;
        if (this._code <= 0)
          this.AddError("VenueCode", "Venue Codes should be positive numbers");
        else
          this.RemoveError("VenueCode");
        this.RaisePropertyChanged<int>("VenueCode", code, value, true);
      }
    }

    public string VenueName
    {
      get
      {
        return this._venue;
      }
      set
      {
        if (this._venue == value)
          return;
        string venue = this._venue;
        this._venue = value;
        this.IsDirty = true;
        this.RaisePropertyChanged<string>("VenueName", venue, value, true);
      }
    }

    public string ShortName
    {
      get
      {
        return this._sname;
      }
      set
      {
        if (this._sname == value)
          return;
        this._sname = value;
        this.IsDirty = true;
        this.RaisePropertyChanged("ShortName");
      }
    }

    public string WebSiteName
    {
      get
      {
        return this._webname;
      }
      set
      {
        if (this._webname == value)
          return;
        this._webname = value;
        this.IsDirty = true;
        this.RaisePropertyChanged("WebSiteName");
      }
    }

    public string Room
    {
      get
      {
        return this._room;
      }
      set
      {
        if (this._room == value)
          return;
        this._room = value;
        this.IsDirty = true;
        this.RaisePropertyChanged("Room");
      }
    }

    public string VenueType
    {
      get
      {
        return this._venueType;
      }
      set
      {
        if (this._venueType == value)
          return;
        this._venueType = value;
        this.IsDirty = true;
        this.RaisePropertyChanged("VenueType");
      }
    }

    public int? ProvinceID
    {
      get
      {
        return this._province;
      }
      set
      {
        int? province = this._province;
        int? nullable = value;
        if ((province.GetValueOrDefault() != nullable.GetValueOrDefault() ? 0 : (province.HasValue == nullable.HasValue ? 1 : 0)) != 0)
          return;
        this._province = value;
        this.RaisePropertyChanged("ProvinceID");
      }
    }

    public bool Available
    {
      get
      {
        return this._available;
      }
      set
      {
        if (this._available == value)
          return;
        this._available = value;
        this.RaisePropertyChanged("Available");
      }
    }

    public int? Capacity
    {
      get
      {
        return this._capacity;
      }
      set
      {
        int? capacity = this._capacity;
        int? nullable = value;
        if ((capacity.GetValueOrDefault() != nullable.GetValueOrDefault() ? 0 : (capacity.HasValue == nullable.HasValue ? 1 : 0)) != 0)
          return;
        this._capacity = value;
        this.RaisePropertyChanged("Capacity");
      }
    }

    public string Description
    {
      get
      {
        return this._comments;
      }
      set
      {
        if (this._comments == value)
          return;
        this._comments = value;
        this.RaisePropertyChanged("Description");
      }
    }

    public DateTime DateModified { get; set; }

    public DbGeography Place { get; set; }

    public VenueBDO Model { get; private set; }

    public bool HasErrors
    {
      get
      {
        return this._errors.Count > 0;
      }
    }

    public bool IsValid
    {
      get
      {
        return !this.HasErrors;
      }
    }

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public VenueViewModel(VenueBDO model)
    {
      this.Model = model;
    }

    public IEnumerable GetErrors(string propertyName)
    {
      if (string.IsNullOrEmpty(propertyName) || !this._errors.ContainsKey(propertyName))
        return (IEnumerable) null;
      return (IEnumerable) this._errors[propertyName];
    }

    public void AddError(string propertyName, string error)
    {
      this._errors[propertyName] = new List<string>()
      {
        error
      };
      this.NotifyErrorsChanged(propertyName);
    }

    public void RemoveError(string propertyName)
    {
      if (this._errors.ContainsKey(propertyName))
        this._errors.Remove(propertyName);
      this.NotifyErrorsChanged(propertyName);
    }

    private void NotifyErrorsChanged(string propertyName)
    {
      if (this.ErrorsChanged == null)
        return;
      this.ErrorsChanged((object) this, new DataErrorsChangedEventArgs(propertyName));
    }
  }
}
