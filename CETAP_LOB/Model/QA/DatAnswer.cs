// Decompiled with JetBrains decompiler
// Type: LOB.Model.QA.DatAnswer
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

namespace CETAP_LOB.Model.QA
{
  public class DatAnswer : ModelBase
  {
    public const string errorCountPropertyName = "errorCount";
    public const string ValuePropertyName = "Value";
    private int _mycount;
    private char _myValue;

    public int errorCount
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
        this.RaisePropertyChanged("errorCount");
      }
    }

    public char Value
    {
      get
      {
        return this._myValue;
      }
      set
      {
        if ((int) this._myValue == (int) value)
          return;
        this._myValue = value;
        bool flag = false;
        if ((int) this._myValue == 65)
          flag = true;
        if ((int) this._myValue == 66)
          flag = true;
        if ((int) this._myValue == 67)
          flag = true;
        if ((int) this._myValue == 68)
          flag = true;
        if ((int) this._myValue == 78)
          flag = true;
        if ((int) this._myValue == 88)
          flag = true;
        if ((int) this._myValue == 32)
          flag = true;
        if (!flag)
          this.AddError("Value", "Score value not correct");
        else
          this.RemoveError("Value");
        this.checkerrors();
        this.RaisePropertyChanged("Value");
      }
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
