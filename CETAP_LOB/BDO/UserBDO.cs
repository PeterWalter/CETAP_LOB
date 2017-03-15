// Decompiled with JetBrains decompiler
// Type: LOB.BDO.UserBDO
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;

namespace CETAP_LOB.BDO
{
  public class UserBDO : ModelBase
  {
    public const string StaffIDPropertyName = "StaffID";
    public const string NamePropertyName = "Name";
    public const string AreasPropertyName = "Areas";
    private string _staffno;
    private string _username;
    private string _areas;

    public string StaffID
    {
      get
      {
        return this._staffno;
      }
      set
      {
        if (this._staffno == value)
          return;
        this._staffno = value;
        this.RaisePropertyChanged("StaffID");
      }
    }

    public string Name
    {
      get
      {
        return this._username;
      }
      set
      {
        if (this._username == value)
          return;
        this._username = value;
        this.RaisePropertyChanged("Name");
      }
    }

    public string Areas
    {
      get
      {
        return this._areas;
      }
      set
      {
        if (this._areas == value)
          return;
        this._areas = value;
        this.RaisePropertyChanged("Areas");
      }
    }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
