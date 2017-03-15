// Decompiled with JetBrains decompiler
// Type: LOB.Model.venueprep.WebWriters1
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using System;

namespace CETAP_LOB.Model.venueprep
{
  public class WebWriters1 : ObservableObject
  {
    private string _surname = "";
    private string _myname = "";
    private string _initials = "";
    private string _said = "";
    private string _foreignID = "";
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
    public const string LastPropertyName = "Last";
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
    private string _mylast;

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

    public string Last
    {
      get
      {
        return this._mylast;
      }
      set
      {
        if (this._mylast == value)
          return;
        this._mylast = value;
        this.RaisePropertyChanged("Last");
      }
    }
  }
}
