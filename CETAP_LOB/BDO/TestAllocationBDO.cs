// Decompiled with JetBrains decompiler
// Type: LOB.BDO.TestAllocationBDO
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;
using System;

namespace CETAP_LOB.BDO
{
  public class TestAllocationBDO : ModelBase
  {
    public const string TestDatePropertyName = "TestDate";
    public const string ClientTypePropertyName = "ClientType";
    public const string TestIDPropertyName = "TestID";
    public const string TestNamePropertyName = "TestName";
    public const string ClientPropertyName = "Client";
    public const string EstimatedPropertyName = "Estimated";
    public const string ActualUsedPropertyName = "ActualUsed";
    private DateTime _testDate;
    private string _clientType;
    private int _testID;
    private string _mytestName;
    private string _client;
    private int _estimated;
    private int _actualUsed;

    public int ID { get; set; }

    public DateTime TestDate
    {
      get
      {
        return this._testDate;
      }
      set
      {
        if (this._testDate == value)
          return;
        this._testDate = value;
        this.RaisePropertyChanged("TestDate");
      }
    }

    public string ClientType
    {
      get
      {
        return this._clientType;
      }
      set
      {
        if (this._clientType == value)
          return;
        this._clientType = value;
        this.RaisePropertyChanged("ClientType");
      }
    }

    public int TestID
    {
      get
      {
        return this._testID;
      }
      set
      {
        if (this._testID == value)
          return;
        this._testID = value;
        this.RaisePropertyChanged("TestID");
      }
    }

    public string TestName
    {
      get
      {
        return this._mytestName;
      }
      set
      {
        if (this._mytestName == value)
          return;
        this._mytestName = value;
        this.RaisePropertyChanged("TestName");
      }
    }

    public string Client
    {
      get
      {
        return this._client;
      }
      set
      {
        if (this._client == value)
          return;
        this._client = value;
        this.RaisePropertyChanged("Client");
      }
    }

    public int Estimated
    {
      get
      {
        return this._estimated;
      }
      set
      {
        if (this._estimated == value)
          return;
        this._estimated = value;
        this.RaisePropertyChanged("Estimated");
      }
    }

    public int ActualUsed
    {
      get
      {
        return this._actualUsed;
      }
      set
      {
        if (this._actualUsed == value)
          return;
        this._actualUsed = value;
        this.RaisePropertyChanged("ActualUsed");
      }
    }

    public Guid RowGuid { get; set; }

    public DateTime DateModified { get; set; }

    public byte[] RowVersion { get; set; }

    public override string ToString()
    {
      return this.TestDate.ToShortDateString() + " " + this.Client + " Amount : " + (object) this.Estimated;
    }
  }
}
