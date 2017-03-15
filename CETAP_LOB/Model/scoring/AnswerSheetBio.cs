// Decompiled with JetBrains decompiler
// Type: LOB.Model.scoring.AnswerSheetBio
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Helper;
using System;
using System.Text.RegularExpressions;

namespace CETAP_LOB.Model.scoring
{
  public class AnswerSheetBio : ModelBase
  {
    private string _initials = "";
    private int? _mcode = new int?();
    public const string errorCountPropertyName = "errorCount";
    public const string NBTPropertyName = "NBT";
    public const string BarcodePropertyName = "Barcode";
    public const string SurnamePropertyName = "Surname";
    public const string NamePropertyName = "Name";
    public const string InitialsPropertyName = "Initials";
    public const string SAIDPropertyName = "SAID";
    public const string ForeignIDPropertyName = "ForeignID";
    public const string DOBPropertyName = "DOB";
    public const string ID_TypePropertyName = "ID_Type";
    public const string CitizenshipPropertyName = "Citizenship";
    public const string ClassificationPropertyName = "Classification";
    public const string GenderPropertyName = "Gender";
    public const string Faculty1PropertyName = "Faculty1";
    public const string DOTPropertyName = "DOT";
    public const string VenueCodePropertyName = "VenueCode";
    public const string VenueNamePropertyName = "VenueName";
    public const string Grade12_LanguagePropertyName = "Grade12_Language";
    public const string Mat_LanguagePropertyName = "Mat_Language";
    public const string AQL_LanguagePropertyName = "AQL_Language";
    public const string HomeLanguagePropertyName = "HomeLanguage";
    public const string MatCodePropertyName = "MatCode";
    public const string AQLCodePropertyName = "AQLCode";
    public const string Faculty2PropertyName = "Faculty2";
    public const string faculty3PropertyName = "faculty3";
    public const string BatchFilePropertyName = "BatchFile";
    public const string aqltestnamePropertyName = "aqltestname";
    public const string matTestnamePropertyName = "matTestname";
    private int _errorCount;
    private long _refNo;
    private long _barcode;
    private string _surname;
    private string _name;
    private string _said;
    private string _foreignID;
    private DateTime _dob;
    private string _idtype;
    private int? _citizen;
    private string _class;
    private string _gender;
    private string _faculty1;
    private DateTime _dot;
    private int _venuecode;
    private string _venueShortName;
    private string _school_lang;
    private string _mat_lang;
    private string _AQL_Lang;
    private int? _hlanguage;
    private int _acode;
    private string _faculty2;
    private string _faculty3;
    private string _batch;
    private string _aqltestname;
    private string _matTestname;

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

    public long Barcode
    {
      get
      {
        return this._barcode;
      }
      set
      {
        if (this._barcode == value)
          return;
        this._barcode = value;
        if (!string.IsNullOrEmpty(this._barcode.ToString()))
        {
          string str = this._barcode.ToString();
          if (str.Length != 12)
            this.AddError("Barcode", "Barcode length is wrong");
          else
            this.RemoveError("Barcode");
          if (!HelperUtils.IsValidChecksum(str))
            this.AddError("Barcode", "Not a Valid Barcode number");
          else
            this.RemoveError("Barcode");
        }
        this.RaisePropertyChanged("Barcode");
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

    public string Initials
    {
      get
      {
        return this._initials;
      }
      set
      {
        if (this._initials == value)
          return;
        this._initials = value;
        this.RaisePropertyChanged("Initials");
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

    public string ForeignID
    {
      get
      {
        return this._foreignID;
      }
      set
      {
        if (this._foreignID == value)
          return;
        this._foreignID = value;
        this.RaisePropertyChanged("ForeignID");
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

    public string ID_Type
    {
      get
      {
        return this._idtype;
      }
      set
      {
        if (this._idtype == value)
          return;
        this._idtype = value;
        this.checkerrors();
        this.RaisePropertyChanged("ID_Type");
      }
    }

    public int? Citizenship
    {
      get
      {
        return this._citizen;
      }
      set
      {
        int? citizen = this._citizen;
        int? nullable = value;
        if ((citizen.GetValueOrDefault() != nullable.GetValueOrDefault() ? 0 : (citizen.HasValue == nullable.HasValue ? 1 : 0)) != 0)
          return;
        this._citizen = value;
        this.RaisePropertyChanged("Citizenship");
      }
    }

    public string Classification
    {
      get
      {
        return this._class;
      }
      set
      {
        if (this._class == value)
          return;
        this._class = value;
        this.RaisePropertyChanged("Classification");
      }
    }

    public string Gender
    {
      get
      {
        return this._gender;
      }
      set
      {
        if (this._gender == value)
          return;
        this._gender = value;
        this.RaisePropertyChanged("Gender");
      }
    }

    public string Faculty1
    {
      get
      {
        return this._faculty1;
      }
      set
      {
        if (this._faculty1 == value)
          return;
        this._faculty1 = value;
        this.RaisePropertyChanged("Faculty1");
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

    public int VenueCode
    {
      get
      {
        return this._venuecode;
      }
      set
      {
        if (this._venuecode == value)
          return;
        this._venuecode = value;
        this.RaisePropertyChanged("VenueCode");
      }
    }

    public string VenueName
    {
      get
      {
        return this._venueShortName;
      }
      set
      {
        if (this._venueShortName == value)
          return;
        this._venueShortName = value;
        this.RaisePropertyChanged("VenueName");
      }
    }

    public string Grade12_Language
    {
      get
      {
        return this._school_lang;
      }
      set
      {
        if (this._school_lang == value)
          return;
        this._school_lang = value;
        this.RaisePropertyChanged("Grade12_Language");
      }
    }

    public string Mat_Language
    {
      get
      {
        return this._mat_lang;
      }
      set
      {
        if (this._mat_lang == value)
          return;
        this._mat_lang = value;
        this.RaisePropertyChanged("Mat_Language");
      }
    }

    public string AQL_Language
    {
      get
      {
        return this._AQL_Lang;
      }
      set
      {
        if (this._AQL_Lang == value)
          return;
        this._AQL_Lang = value;
        this.RaisePropertyChanged("AQL_Language");
      }
    }

    public int? HomeLanguage
    {
      get
      {
        return this._hlanguage;
      }
      set
      {
        int? hlanguage = this._hlanguage;
        int? nullable = value;
        if ((hlanguage.GetValueOrDefault() != nullable.GetValueOrDefault() ? 0 : (hlanguage.HasValue == nullable.HasValue ? 1 : 0)) != 0)
          return;
        this._hlanguage = value;
        this.RaisePropertyChanged("HomeLanguage");
      }
    }

    public int? MatCode
    {
      get
      {
        return this._mcode;
      }
      set
      {
        int? mcode = this._mcode;
        int? nullable = value;
        if ((mcode.GetValueOrDefault() != nullable.GetValueOrDefault() ? 0 : (mcode.HasValue == nullable.HasValue ? 1 : 0)) != 0)
          return;
        this._mcode = value;
        this.RaisePropertyChanged("MatCode");
      }
    }

    public int AQLCode
    {
      get
      {
        return this._acode;
      }
      set
      {
        if (this._acode == value)
          return;
        this._acode = value;
        this.RaisePropertyChanged("AQLCode");
      }
    }

    public string Faculty2
    {
      get
      {
        return this._faculty2;
      }
      set
      {
        if (this._faculty2 == value)
          return;
        this._faculty2 = value;
        this.RaisePropertyChanged("Faculty2");
      }
    }

    public string faculty3
    {
      get
      {
        return this._faculty3;
      }
      set
      {
        if (this._faculty3 == value)
          return;
        this._faculty3 = value;
        this.RaisePropertyChanged("faculty3");
      }
    }

    public string BatchFile
    {
      get
      {
        return this._batch;
      }
      set
      {
        if (this._batch == value)
          return;
        this._batch = value;
        this.RaisePropertyChanged("BatchFile");
      }
    }

    public string aqltestname
    {
      get
      {
        return this._aqltestname;
      }
      set
      {
        if (this._aqltestname == value)
          return;
        this._aqltestname = value;
        this.RaisePropertyChanged("aqltestname");
      }
    }

    public string matTestname
    {
      get
      {
        return this._matTestname;
      }
      set
      {
        if (this._matTestname == value)
          return;
        this._matTestname = value;
        this.RaisePropertyChanged("matTestname");
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
