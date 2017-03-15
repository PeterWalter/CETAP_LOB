// Decompiled with JetBrains decompiler
// Type: LOB.Model.venueprep.VenueSummary
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using CETAP_LOB.Helper;
using System;

namespace CETAP_LOB.Model.venueprep
{
  public class VenueSummary : ObservableObject
  {
    private int _walkin_e = 10;
    private int _walkin_a = 10;
    public const string TestDatePropertyName = "TestDate";
    public const string VenuePropertyName = "Venue";
    public const string TotalWritersPropertyName = "TotalWriters";
    public const string CentreCodePropertyName = "CentreCode";
    public const string AQL_EPropertyName = "AQL_E";
    public const string Walkin_EPropertyName = "Walkin_E";
    public const string AQLE_SPropertyName = "AQLE_S";
    public const string AQLE_BatchPropertyName = "AQLE_Batch";
    public const string Maths_EPropertyName = "Maths_E";
    public const string MATE_SPropertyName = "MATE_S";
    public const string MATE_BatchPropertyName = "MATE_Batch";
    public const string AQL_APropertyName = "AQL_A";
    public const string Walkin_APropertyName = "Walkin_A";
    public const string AQLA_SPropertyName = "AQLA_S";
    public const string AQLA_BatchPropertyName = "AQLA_Batch";
    public const string Maths_APropertyName = "Maths_A";
    public const string MATA_SPropertyName = "MATA_S";
    public const string MATA_BatchPropertyName = "MATA_Batch";
    public const string TotalSentPropertyName = "TotalSent";
    private DateTime _mytestDate;
    private string _venue;
    private int _writers;
    private int _vcode;
    private int _aql_e;
    private int _aqle_s;
    private string _aqle_b;
    private int _maths_e;
    private int _mate_s;
    private string _mate_batch;
    private int _aql_a;
    private int _aqla_s;
    private string _aqla_b;
    private int _math_a;
    private int _mata_s;
    private string _mata_batch;
    private int _totalsent;

    public DateTime TestDate
    {
      get
      {
        return this._mytestDate;
      }
      set
      {
        if (this._mytestDate == value)
          return;
        this._mytestDate = value;
        this.RaisePropertyChanged("TestDate");
      }
    }

    public string Venue
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
        this.RaisePropertyChanged("Venue");
      }
    }

    public int TotalWriters
    {
      get
      {
        return this._writers;
      }
      set
      {
        if (this._writers == value)
          return;
        this._writers = value;
        this.RaisePropertyChanged("TotalWriters");
      }
    }

    public int CentreCode
    {
      get
      {
        return this._vcode;
      }
      set
      {
        if (this._vcode == value)
          return;
        this._vcode = value;
        this.RaisePropertyChanged("CentreCode");
      }
    }

    public int AQL_E
    {
      get
      {
        return this._aql_e;
      }
      set
      {
        if (this._aql_e == value)
          return;
        this._aql_e = value;
        this.RaisePropertyChanged("AQL_E");
        this._aqle_s = HelperUtils.RoundAmount(this._aql_e);
        this.RaisePropertyChanged("AQLE_S");
      }
    }

    public int Walkin_E
    {
      get
      {
        return this._walkin_e;
      }
      set
      {
        if (this._walkin_e == value)
          return;
        if (this._aql_e == 0)
          value = 0;
        this._walkin_e = value;
        this.RaisePropertyChanged("Walkin_E");
      }
    }

    public int AQLE_S
    {
      get
      {
        return this._aqle_s;
      }
      set
      {
        if (this._aqle_s == value)
          return;
        this._aqle_s = value;
        this.RaisePropertyChanged("AQLE_S");
        this.AQLE_Batch = HelperUtils.YourChange(this._aqle_s);
        this.RaisePropertyChanged("AQLE_Batch");
        this._totalsent = this._aqle_s + this._aqla_s;
        this.RaisePropertyChanged("TotalSent");
      }
    }

    public string AQLE_Batch
    {
      get
      {
        return this._aqle_b;
      }
      set
      {
        if (this._aqle_b == value)
          return;
        this._aqle_b = value;
        this.RaisePropertyChanged("AQLE_Batch");
      }
    }

    public int Maths_E
    {
      get
      {
        return this._maths_e;
      }
      set
      {
        if (this._maths_e == value)
          return;
        this._maths_e = value;
        this._mate_s = HelperUtils.RoundAmount(this._maths_e);
        this.RaisePropertyChanged("Maths_E");
        this.RaisePropertyChanged("MATE_S");
      }
    }

    public int MATE_S
    {
      get
      {
        return this._mate_s;
      }
      set
      {
        if (this._mate_s == value)
          return;
        this._mate_s = value;
        this._mate_batch = HelperUtils.YourChange(this._mate_s);
        this.RaisePropertyChanged("MATE_S");
        this.RaisePropertyChanged("MATE_Batch");
      }
    }

    public string MATE_Batch
    {
      get
      {
        return this._mate_batch;
      }
      set
      {
        if (this._mate_batch == value)
          return;
        this._mate_batch = value;
        this.RaisePropertyChanged("MATE_Batch");
      }
    }

    public int AQL_A
    {
      get
      {
        return this._aql_a;
      }
      set
      {
        if (this._aql_a == value)
          return;
        this._aql_a = value;
        this._aqla_s = HelperUtils.RoundAmount(this._aql_a);
        this.RaisePropertyChanged("AQL_A");
        this.RaisePropertyChanged("AQLA_S");
      }
    }

    public int Walkin_A
    {
      get
      {
        return this._walkin_a;
      }
      set
      {
        if (this._walkin_a == value)
          return;
        if (this._aql_a == 0)
          value = 0;
        this._walkin_a = value;
        this.RaisePropertyChanged("Walkin_A");
      }
    }

    public int AQLA_S
    {
      get
      {
        return this._aqla_s;
      }
      set
      {
        if (this._aqla_s == value)
          return;
        this._aqla_s = value;
        this._totalsent = this._aqle_s + this._aqla_s;
        this._aqla_b = HelperUtils.YourChange(this._aqla_s);
        this.RaisePropertyChanged("AQLA_S");
        this.RaisePropertyChanged("AQLA_Batch");
        this.RaisePropertyChanged("TotalSent");
      }
    }

    public string AQLA_Batch
    {
      get
      {
        return this._aqla_b;
      }
      set
      {
        if (this._aqla_b == value)
          return;
        this._aqla_b = value;
        this.RaisePropertyChanged("AQLA_Batch");
      }
    }

    public int Maths_A
    {
      get
      {
        return this._math_a;
      }
      set
      {
        if (this._math_a == value)
          return;
        this._math_a = value;
        this._mata_s = HelperUtils.RoundAmount(this._math_a);
        this.RaisePropertyChanged("Maths_A");
        this.RaisePropertyChanged("MATA_S");
      }
    }

    public int MATA_S
    {
      get
      {
        return this._mata_s;
      }
      set
      {
        if (this._mata_s == value)
          return;
        this._mata_s = value;
        this._mata_batch = HelperUtils.YourChange(this._mata_s);
        this.RaisePropertyChanged("MATA_S");
        this.RaisePropertyChanged("MATA_Batch");
      }
    }

    public string MATA_Batch
    {
      get
      {
        return this._mata_batch;
      }
      set
      {
        if (this._mata_batch == value)
          return;
        this._mata_batch = value;
        this.RaisePropertyChanged("MATA_Batch");
      }
    }

    public int TotalSent
    {
      get
      {
        return this._totalsent;
      }
      set
      {
        if (this._totalsent == value)
          return;
        this._totalsent = value;
        this.RaisePropertyChanged("TotalSent");
      }
    }
  }
}
