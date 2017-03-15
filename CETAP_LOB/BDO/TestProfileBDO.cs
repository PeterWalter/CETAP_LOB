// Decompiled with JetBrains decompiler
// Type: LOB.BDO.TestProfileBDO
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;
using System;

namespace CETAP_LOB.BDO
{
  public class TestProfileBDO : ModelBase
  {
    public const string ProfilePropertyName = "Profile";
    public const string IntakePropertyName = "Intake";
    public const string AllocationIDPropertyName = "AllocationID";
    public const string ModifiedDatePropertyName = "ModifiedDate";
    private int _profile;
    private int _myIntake;
    private int _myAllocID;
    private DateTime _mDate;

    public int ProfileID { get; set; }

    public int Profile
    {
      get
      {
        return this._profile;
      }
      set
      {
        if (this._profile == value)
          return;
        this._profile = value;
        this.RaisePropertyChanged("Profile");
      }
    }

    public int Intake
    {
      get
      {
        return this._myIntake;
      }
      set
      {
        if (this._myIntake == value)
          return;
        this._myIntake = value;
        this.RaisePropertyChanged("Intake");
      }
    }

    public int AllocationID
    {
      get
      {
        return this._myAllocID;
      }
      set
      {
        if (this._myAllocID == value)
          return;
        this._myAllocID = value;
        this.RaisePropertyChanged("AllocationID");
      }
    }

    public Guid RowGuid { get; set; }

    public DateTime ModifiedDate
    {
      get
      {
        return this._mDate;
      }
      set
      {
        if (this._mDate == value)
          return;
        this._mDate = value;
        this.RaisePropertyChanged("ModifiedDate");
      }
    }

    public byte[] RowVersion { get; set; }

    public override string ToString()
    {
      return this.Profile.ToString();
    }
  }
}
