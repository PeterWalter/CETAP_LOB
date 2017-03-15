// Decompiled with JetBrains decompiler
// Type: LOB.Model.Composite.BI
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Helper;
using System;
using System.Text.RegularExpressions;

namespace CETAP_LOB.Model.Composite
{
  public class BI : ModelBase
  {
    public const string errorCountPropertyName = "errorCount";
    public const string NBTPropertyName = "NBT";
    public const string SurnamePropertyName = "Surname";
    public const string NamePropertyName = "Name";
    public const string SAIDPropertyName = "SAID";
    public const string DOBPropertyName = "DOB";
    public const string DOTPropertyName = "DOT";
    private int _errorCount;
    private long _refNo;
    private string _surname;
    private string _name;
    private string _said;
    private DateTime _dob;
    private DateTime _dot;

    public int errorCount
    {
      get
      {
        return this._errorCount;
      }
      set
      {
        if (this._errorCount == value)
          return;
        this._errorCount = value;
        this.RaisePropertyChanged("errorCount");
      }
    }

    public long NBT
    {
      get
      {
        return this._refNo;
      }
      set
      {
        if (this._refNo == value)
          return;
        this._refNo = value;
        if (!string.IsNullOrEmpty(this._refNo.ToString()))
        {
          if (this._refNo.ToString().Length != 14)
            this.AddError("NBT", "Not proper length for NBT number");
          else if (!HelperUtils.IsValidChecksum(this._refNo.ToString().Substring(1, 13)))
            this.AddError("NBT", "Not a Valid NBT number");
          else
            this.RemoveError("NBT");
        }
        else
          this.AddError("NBT", "NBT number cannot be empty");
        this.checkerrors();
        this.RaisePropertyChanged("NBT");
      }
    }

    public string Surname
    {
      get
      {
        return this._surname;
      }
      set
      {
        if (this._surname == value)
          return;
        this._surname = value;
        if (string.IsNullOrEmpty(this._surname))
          this.AddError("Surname", "Surname cannot be empty");
        else
          this.RemoveError("Surname");
        if (!string.IsNullOrEmpty(this._surname))
        {
          if (Regex.IsMatch(this._surname, "\\d"))
            this.AddError("Surname", "Surname cannot have digits");
          else if (!Regex.IsMatch(this._surname, "^[^\\s=!@#](?:[^!@#]*[^\\s!@#])?$"))
            this.AddError("Surname", "cannot start/end with space or have funny characters");
          else
            this.RemoveError("Surname");
        }
        if (new Regex("\\s").Matches(this._surname).Count > 2)
          this.AddError("Surname", "Surname has too many spaces");
        else
          this.RemoveError("Surname");
        this.checkerrors();
        this.RaisePropertyChanged("Surname");
      }
    }

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
        if (string.IsNullOrEmpty(this._name))
          this.AddError("Name", "Name cannot be empty");
        else
          this.RemoveError("Name");
        if (!string.IsNullOrEmpty(this._surname))
        {
          if (Regex.IsMatch(this._surname, "\\d"))
            this.AddError("Name", "Name cannot have digits");
          else if (!Regex.IsMatch(this._name, "^[^\\s=!@#](?:[^!@#]*[^\\s!@#])?$"))
            this.AddError("Name", "cannot start/end with space or have funny characters");
          else
            this.RemoveError("Name");
        }
        if (new Regex("\\s").Matches(this._name).Count > 2)
          this.AddError("Name", "Surname has too many spaces");
        else
          this.RemoveError("Name");
        this.checkerrors();
        this.RaisePropertyChanged("Name");
      }
    }

    public string SAID
    {
      get
      {
        return this._said;
      }
      set
      {
        if (this._said == value)
          return;
        this._said = value;
        this._said = this._said.Trim();
        if (!string.IsNullOrEmpty(this._said))
        {
          if (this._said.Length != 13)
            this.AddError("SAID", "Not proper length for SA ID");
          else if (!Regex.IsMatch(this._said, "^[0-9]+$"))
            this.AddError("SAID", "SA Id does not have characters");
          else if (!HelperUtils.IsValidChecksum(this._said))
            this.AddError("SAID", "Not a Valid South African ID number");
          else
            this.RemoveError("SAID");
        }
        this.checkerrors();
        this.RaisePropertyChanged("SAID");
      }
    }

    public DateTime DOB
    {
      get
      {
        return this._dob;
      }
      set
      {
        if (this._dob == value)
          return;
        this._dob = value;
        TimeSpan timeSpan = DateTime.Now - this._dob;
        if (timeSpan.TotalDays < 3650.0 || timeSpan.TotalDays > 29100.0)
          this.AddError("DOB", "Wrong age for Matric");
        else
          this.RemoveError("DOB");
        if (!string.IsNullOrWhiteSpace(this._said) || !string.IsNullOrEmpty(this._said))
        {
          if (HelperUtils.DOBfromSAID(this._said) != string.Format("{0:dd/MM/yyyy}", (object) this._dob))
            this.AddError("DOB", "ID and DOB not the same");
          else
            this.RemoveError("DOB");
        }
        this.checkerrors();
        this.RaisePropertyChanged("DOB");
      }
    }

    public DateTime DOT
    {
      get
      {
        return this._dot;
      }
      set
      {
        if (this._dot == value)
          return;
        this._dot = value;
        this.RaisePropertyChanged("DOT");
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
