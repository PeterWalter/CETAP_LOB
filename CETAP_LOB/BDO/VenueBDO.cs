// Decompiled with JetBrains decompiler
// Type: LOB.BDO.VenueBDO
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;
using System;
using System.Data.Entity.Spatial;

namespace CETAP_LOB.BDO
{
  public class VenueBDO : ModelBase
  {
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
    private int _code;
    private string _venue;
    private string _sname;
    private string _webname;
    private string _room;
    private string _venueType;
    private int _province;
    private bool _available;
    private int? _capacity;
    private string _comments;

    public byte[] RowVersion { get; set; }

    public Guid RowGuid { get; set; }

    public DateTime DateModified { get; set; }

    public DbGeography Place { get; set; }

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
        this._code = value;
        if (this._code < 1)
          this.AddError("VenueCode", "Venue Codes should be positive numbers");
        else
          this.RemoveError("VenueCode");
        this.RaisePropertyChanged("VenueCode");
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
        this._venue = value;
        if (string.IsNullOrWhiteSpace(this._venue))
          this.AddError("VenueName", "Venue Name is required");
        else
          this.RemoveError("VenueName");
        this.RaisePropertyChanged("VenueName");
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
        if (string.IsNullOrWhiteSpace(this._venue))
          this.AddError("ShortName", "Venue Name is required");
        else
          this.RemoveError("ShortName");
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
        this.RaisePropertyChanged("VenueType");
      }
    }

    public int ProvinceID
    {
      get
      {
        return this._province;
      }
      set
      {
        if (this._province == value)
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
  }
}
