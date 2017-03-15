// Decompiled with JetBrains decompiler
// Type: LOB.BDO.ProvinceBDO
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;

namespace CETAP_LOB.BDO
{
  public class ProvinceBDO : ModelBase
  {
    public const string IdPropertyName = "Id";
    public const string NamePropertyName = "Name";
    private int _myID;
    private string _name;

    public int Id
    {
      get
      {
        return this._myID;
      }
      set
      {
        if (this._myID == value)
          return;
        this._myID = value;
        this.RaisePropertyChanged("Id");
      }
    }

    public byte[] RowVersion { get; set; }

    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        if (this._name == value)
          return;
        this._name = value;
        this.RaisePropertyChanged("Name");
      }
    }

    public int Code { get; set; }

    public override string ToString()
    {
      return this.Name;
    }
  }
}
