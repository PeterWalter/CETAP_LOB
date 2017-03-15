// Decompiled with JetBrains decompiler
// Type: LOB.BDO.BatchBDO
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;
using CETAP_LOB.Model;
using System;

namespace CETAP_LOB.BDO
{
  public class BatchBDO : ModelBase
  {
    public const string errorCountPropertyName = "errorCount";
    public const string BatchNamePropertyName = "BatchName";
    public const string TestDatePropertyName = "TestDate";
    public const string TestCombinationPropertyName = "TestCombination";
    public const string BatchedByPropertyName = "BatchedBy";
    public const string BatchDatePropertyName = "BatchDate";
    public const string RandomTestNumberPropertyName = "RandomTestNumber";
    public const string CountPropertyName = "Count";
    public const string TestVenueIDPropertyName = "TestVenueID";
    public const string TestProfileIDPropertyName = "TestProfileID";
    public const string DescriptionPropertyName = "Description";
    private int _myecount;
    private string _mybatch;
    private DateTime _testDate;
    private string _testCombination;
    private string _batchedBy;
    private DateTime _batchDate;
    private int _randNumber;
    private int _mycount;
    private int _venueID;
    private int _myProfileID;
    private string _desc;

    public int BatchID { get; set; }

    public int errorCount
    {
      get
      {
        return this._myecount;
      }
      set
      {
        if (this._myecount == value)
          return;
        this._myecount = value;
        this.RaisePropertyChanged("errorCount");
      }
    }

    public string BatchName
    {
      get
      {
        return this._mybatch;
      }
      set
      {
        if (this._mybatch == value)
          return;
        this._mybatch = value;
        if (string.IsNullOrWhiteSpace(this._mybatch))
          this.AddError("BatchName", "Batch Name is required");
        else
          this.RemoveError("BatchName");
        this.checkerrors();
        this.RaisePropertyChanged("BatchName");
      }
    }

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
        if (this._testDate > DateTime.Now)
          this.AddError("TestDate", "Impossible date, test already written");
        else
          this.RemoveError("TestDate");
        this.checkerrors();
        this.RaisePropertyChanged("TestDate");
      }
    }

    public string TestCombination
    {
      get
      {
        return this._testCombination;
      }
      set
      {
        if (this._testCombination == value)
          return;
        this._testCombination = value;
        this.RaisePropertyChanged("TestCombination");
      }
    }

    public string BatchedBy
    {
      get
      {
        return this._batchedBy;
      }
      set
      {
        if (this._batchedBy == value)
          return;
        this._batchedBy = value;
        this.RaisePropertyChanged("BatchedBy");
      }
    }

    public DateTime BatchDate
    {
      get
      {
        return this._batchDate;
      }
      set
      {
        if (this._batchDate == value)
          return;
        this._batchDate = value;
        this.RaisePropertyChanged("BatchDate");
      }
    }

    public int RandomTestNumber
    {
      get
      {
        return this._randNumber;
      }
      set
      {
        if (this._randNumber == value)
          return;
        this._randNumber = value;
        this.RaisePropertyChanged("RandomTestNumber");
      }
    }

    public int Count
    {
      get
      {
        return this._mycount;
      }
      set
      {
        if (this._mycount == value)
          return;
        this._mycount = value;
        this.RaisePropertyChanged("Count");
      }
    }

    public int TestVenueID
    {
      get
      {
        return this._venueID;
      }
      set
      {
        if (this._venueID == value)
          return;
        this._venueID = value;
        this.RaisePropertyChanged("TestVenueID");
      }
    }

    public int TestProfileID
    {
      get
      {
        return this._myProfileID;
      }
      set
      {
        if (this._myProfileID == value)
          return;
        this._myProfileID = value;
        this.RaisePropertyChanged("TestProfileID");
      }
    }

    public string Description
    {
      get
      {
        return this._desc;
      }
      set
      {
        if (this._desc == value)
          return;
        this._desc = value;
        this.RaisePropertyChanged("Description");
      }
    }

    public DateTime DateModified { get; set; }

    public byte[] RowVersion { get; set; }

    public override string ToString()
    {
      return this.BatchName;
    }

    private void checkerrors()
    {
      if (this.HasErrors)
        this.errorCount = this._errors.Count;
      else
        this.errorCount = 0;
    }
  }
}
