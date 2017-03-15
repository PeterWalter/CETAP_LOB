// Decompiled with JetBrains decompiler
// Type: LOB.Model.venueprep.WebWriters
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Helper;
using System;
using System.Text.RegularExpressions;

namespace CETAP_LOB.Model.venueprep
{
  public class WebWriters : ModelBase
  {
    private string _surname = "";
    private string _myname = "";
    private string _initials = "";
    private string _said = "";
    private string _foreignID = "";
    public const string errorCountPropertyName = "errorCount";
    public const string ReferencePropertyName = "Reference";
    public const string SurnamePropertyName = "Surname";
    public const string FirstNamePropertyName = "FirstName";
    public const string initialsPropertyName = "initials";
    public const string SAIDPropertyName = "SAID";
    public const string ForeignIDPropertyName = "ForeignID";
    public const string DOBPropertyName = "DOB";
    public const string GenderPropertyName = "Gender";
    public const string ClassificationPropertyName = "Classification";
    public const string TestsPropertyName = "Tests";
    public const string LanguagePropertyName = "Language";
    public const string VenuePropertyName = "Venue";
    public const string DOTPropertyName = "DOT";
    public const string MobilePropertyName = "Mobile";
    public const string HTelephonePropertyName = "HTelephone";
    public const string EmailPropertyName = "Email";
    public const string RegDatePropertyName = "RegDate";
    public const string PaidPropertyName = "Paid";
    public const string CreationDatePropertyName = "CreationDate";
    public const string IsSelectedPropertyName = "IsSelected";
    private int _mycount;
    private string _NBT;
    private DateTime _dob;
    private string _gender;
    private string _classification;
    private string _tests;
    private string _language;
    private string _venue;
    private DateTime _dot;
    private string _mobile;
    private string _telephone;
    private string _email;
    private DateTime _regdate;
    private double _payment;
    private DateTime _CreateDate;
    private bool _isSelected;

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

    public string Reference
    {
      get
      {
        return this._NBT;
      }
      set
      {
        if (this._NBT == value)
          return;
        this._NBT = value;
        if (!string.IsNullOrEmpty(this._NBT))
        {
          if (this._NBT.Length != 14)
            this.AddError("Reference", "Not proper length for NBT number");
          else if (!HelperUtils.IsValidChecksum(this._NBT.Substring(1, 13)))
            this.AddError("Reference", "Not a Valid NBT number");
          else
            this.RemoveError("Reference");
        }
        else
          this.AddError("Reference", "NBT number cannot be empty");
        this.checkerrors();
        this.RaisePropertyChanged("Reference");
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
          else if (this._surname.Length > 20)
            this.AddError("Surname", "Too many characters for Surname");
          else
            this.RemoveError("Surname");
        }
        this.checkerrors();
        this.RaisePropertyChanged("Surname");
      }
    }

    public string FirstName
    {
      get
      {
        return this._myname;
      }
      set
      {
        if (this._myname == value)
          return;
        this._myname = value;
        if (string.IsNullOrEmpty(this._myname))
          this.AddError("FirstName", "FirstName cannot be empty");
        else
          this.RemoveError("FirstName");
        if (!string.IsNullOrWhiteSpace(this._myname))
        {
          if (Regex.IsMatch(this._myname, "\\d"))
            this.AddError("FirstName", "First name cannot have digits");
          else if (!Regex.IsMatch(this._myname, "^[^\\s=!@#](?:[^!@#]*[^\\s!@#])?$"))
            this.AddError("FirstName", "cannot start/end with space or have funny characters");
          else if (this._myname.Length > 18)
            this.AddError("FirstName", "To many characters for Name (max is 18)");
          else
            this.RemoveError("FirstName");
        }
        this.checkerrors();
        this.RaisePropertyChanged("FirstName");
      }
    }

    public string initials
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
        this.RaisePropertyChanged("initials");
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
        if (!string.IsNullOrEmpty(this._said))
        {
          if (!Regex.IsMatch(this._said, "^[0-9]+$"))
            this.AddError("SAID", "SA Id does not have characters");
          else if (!HelperUtils.IsValidChecksum(this._said))
            this.AddError("SAID", "Not a Valid South African ID number");
          else
            this.RemoveError("SAID");
        }
        else
          this.RemoveError("SAID");
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
        if (!string.IsNullOrEmpty(this._foreignID))
        {
          if (this._foreignID.Length > 15)
            this.AddError("ForeignID", "ForeignID has too many characters");
          else
            this.RemoveError("ForeignID");
        }
        this.checkerrors();
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
        this.checkerrors();
        this.RaisePropertyChanged("DOB");
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

    public string Classification
    {
      get
      {
        return this._classification;
      }
      set
      {
        if (this._classification == value)
          return;
        this._classification = value;
        this.RaisePropertyChanged("Classification");
      }
    }

    public string Tests
    {
      get
      {
        return this._tests;
      }
      set
      {
        if (this._tests == value)
          return;
        this._tests = value;
        this.RaisePropertyChanged("Tests");
      }
    }

    public string Language
    {
      get
      {
        return this._language;
      }
      set
      {
        if (this._language == value)
          return;
        this._language = value;
        this.RaisePropertyChanged("Language");
      }
    }

    public string Venue
    {
      get
      {
        return this._venue;
      }
      set
      {
        if (this._venue == value)
          return;
        this._venue = value;
        this.RaisePropertyChanged("Venue");
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

    public string Mobile
    {
      get
      {
        return this._mobile;
      }
      set
      {
        if (this._mobile == value)
          return;
        this._mobile = value;
        if (!string.IsNullOrEmpty(this._mobile))
        {
          if (this._mobile.Length > 15)
            this.AddError("Mobile", "Cellphone number has too many characters");
          else
            this.RemoveError("Mobile");
        }
        this.checkerrors();
        this.RaisePropertyChanged("Mobile");
      }
    }

    public string HTelephone
    {
      get
      {
        return this._telephone;
      }
      set
      {
        if (this._telephone == value)
          return;
        this._telephone = value;
        if (!string.IsNullOrEmpty(this._telephone))
        {
          if (this._telephone.Length > 15)
            this.AddError("HTelephone", "Telephone number has too many characters");
          else
            this.RemoveError("HTelephone");
        }
        this.checkerrors();
        this.RaisePropertyChanged("HTelephone");
      }
    }

    public string Email
    {
      get
      {
        return this._email;
      }
      set
      {
        if (this._email == value)
          return;
        this._email = value;
        if (!string.IsNullOrEmpty(this._email))
        {
          if (!HelperUtils.IsValidEmail(this._email))
            this.AddError("Email", "Wrong email address");
          else if (this._email.Length > 50)
            this.AddError("Email", "Email is to long");
          else
            this.RemoveError("Email");
        }
        else
          this.RemoveError("Email");
        this.checkerrors();
        this.RaisePropertyChanged("Email");
      }
    }

    public DateTime RegDate
    {
      get
      {
        return this._regdate;
      }
      set
      {
        if (this._regdate == value)
          return;
        this._regdate = value;
        this.RaisePropertyChanged("RegDate");
      }
    }

    public double Paid
    {
      get
      {
        return this._payment;
      }
      set
      {
        if (this._payment == value)
          return;
        this._payment = value;
        this.RaisePropertyChanged("Paid");
      }
    }

    public DateTime CreationDate
    {
      get
      {
        return this._CreateDate;
      }
      set
      {
        if (this._CreateDate == value)
          return;
        this._CreateDate = value;
        this.RaisePropertyChanged("CreationDate");
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

    private void checkerrors()
    {
      if (this.HasErrors)
        this.errorCount = this._errors.Count;
      else
        this.errorCount = 0;
    }
  }
}
