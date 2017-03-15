// Decompiled with JetBrains decompiler
// Type: LOB.Model.easypay.PayRecord
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using System;

namespace CETAP_LOB.Model.easypay
{
  public class PayRecord
  {
    private double amount;
    private string _Id;
    private long _nbt;
    private string _date;
    private string _time;
    private string _xRecord;
    private string _pRecord;
    private string myRecord;

    public long NBT
    {
      get
      {
        return this._nbt;
      }
      set
      {
        this._nbt = value;
      }
    }

    public double Amount
    {
      get
      {
        return this.amount;
      }
      set
      {
        this.amount = value;
      }
    }

    public string ID
    {
      get
      {
        return this._Id;
      }
      set
      {
        this._Id = value;
      }
    }

    public string Record
    {
      get
      {
        this.CreateXrecord();
        this.CreateTPrecord();
        this.myRecord = this._xRecord + this._pRecord;
        return this.myRecord;
      }
    }

    private void CreateXrecord()
    {
      long num = 2630099999;
      DateTime now = DateTime.Now;
      this._date = now.ToString("yyyyMMdd");
      this._time = now.ToString("HHMMss");
      this._xRecord = "X," + (object) num + "," + this._date + "," + this._time + ",0263," + this._Id;
      this._xRecord += Environment.NewLine;
    }

    private void CreateTPrecord()
    {
      string str1 = "P,";
      string str2 = string.Format("{0,10:######0.00}", (object) this.amount);
      string str3 = str1 + str2;
      string str4 = string.Format("{0,10:######0.00}", (object) 0.0);
      this._pRecord = str3 + "," + str4 + "," + (object) this._nbt + Environment.NewLine + ("T," + str2 + "," + str4 + ",Cash" + Environment.NewLine);
    }
  }
}
