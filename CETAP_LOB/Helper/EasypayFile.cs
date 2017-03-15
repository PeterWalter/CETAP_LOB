// Decompiled with JetBrains decompiler
// Type: LOB.Helper.EasypayFile
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;

namespace CETAP_LOB.Helper
{
  public class EasypayFile : ModelBase
  {
    private string thename = "";
    private string _name = "";
    private string _date = "";
    public const string IsSelectedPropertyName = "IsSelected";
    private string _size;
    private bool _isSelected;

    public string FileDetails
    {
      get
      {
        return this.thename;
      }
      set
      {
        this.thename = value;
        this.SplitDetails(this.thename);
      }
    }

    public string FileName
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
      }
    }

    public string Size
    {
      get
      {
        return this._size;
      }
      set
      {
        this._size = value;
      }
    }

    public string Date
    {
      get
      {
        return this._date;
      }
      set
      {
        this._date = value;
      }
    }

    public bool IsSelected
    {
      get
      {
        return this._isSelected;
      }
      set
      {
        if (this._isSelected == value)
          return;
        this._isSelected = value;
        this.RaisePropertyChanged("IsSelected");
      }
    }

    private void SplitDetails(string filedata)
    {
      char[] chArray = new char[2]{ ' ', ' ' };
      string[] strArray = filedata.Split(chArray);
      int length = strArray.Length;
      this._name = strArray[length - 1];
      string str1 = strArray[length - 2];
      string str2 = strArray[length - 3];
      string str3 = strArray[length - 4];
      this._date = strArray[length - 5];
      EasypayFile easypayFile = this;
      string str4 = easypayFile._date + " " + str3 + " " + str2 + " " + str1;
      easypayFile._date = str4;
      this._size = strArray[length - 6];
    }

    public override string ToString()
    {
      return this._name + " " + this._date + " " + this._size;
    }
  }
}
