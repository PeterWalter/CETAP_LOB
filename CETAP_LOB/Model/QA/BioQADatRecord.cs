// Decompiled with JetBrains decompiler
// Type: LOB.Model.QA.BioQADatRecord
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Helper;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CETAP_LOB.Model.QA
{
  public class BioQADatRecord : ModelBase
  {
    private string _said = "";
    private string _foreignID = "";
    public const string mCSX_NumberPropertyName = "mCSX_Number";
    public const string CSXPropertyName = "CSX";
    public const string NBTPropertyName = "NBT";
    public const string BarcodePropertyName = "Barcode";
    public const string SAIDPropertyName = "SAID";
    public const string ForeignIDPropertyName = "ForeignID";
    public const string GenderPropertyName = "Gender";
    public const string CitizenshipPropertyName = "Citizenship";
    public const string HomeLanguagePropertyName = "HomeLanguage";
    public const string ClassificationPropertyName = "Classification";
    public const string PhonePropertyName = "Phone";
    public const string HomeProvincePropertyName = "HomeProvince";
    public const string DOTPropertyName = "DOT";
    public const string Grade12LanguagePropertyName = "Grade12Language";
    public const string SchoolTypePropertyName = "SchoolType";
    public const string Faculty1PropertyName = "Faculty1";
    public const string Faculty2PropertyName = "Faculty2";
    public const string Faculty3PropertyName = "Faculty3";
    public const string DatFilePropertyName = "DatFile";
    public const string ErrorCountPropertyName = "ErrorCount";
    public const string IsSelectedPropertyName = "IsSelected";
    private string _myCSXNum;
    private string _csx;
    private string _nbt;
    private string _barcode;
    private string _gender;
    private string _myCitizenship;
    private string _homeLanguage;
    private string _classi;
    private string _phone;
    private string _mProvince;
    private DateTime _dot;
    private string mHomeType;
    private string mHelectricity;
    private string mSchool10Km;
    private string mHomestudy;
    private string mSiblingsAttendedUni;
    private string mSiblingsAtUni;
    private string mVenueTime;
    private string mVenueCost;
    private string mVenueDist;
    private string mVenueModeOfTransport;
    private string mSchComputers;
    private string mSchLibrary;
    private string mSchLabs;
    private string mSchElectricity;
    private string mSchWater;
    private string mSchHall;
    private string mSchFields;
    private string mSchHostel;
    private string mUsedComputers;
    private string mUsedLibrary;
    private string mUsedLabs;
    private string mUsedElectricity;
    private string mUsedRWater;
    private string mUsedHall;
    private string mUsedFields;
    private string mUsedHostel;
    private string mSchoolName;
    private string mYrGr12;
    private string mPostalCode;
    private string mSchProvince;
    private int _myGr12L;
    private int schoolType;
    private string _myfaculty1;
    private string _myfaculty2;
    private string _myFaculty3;
    private string mEOL;
    private datFileAttributes _mydatFile;
    private int _myerrorcount;
    private bool _isSelected;

    public string mCSX_Number
    {
      get
      {
        return this._myCSXNum;
      }
      set
      {
        if (this._myCSXNum == value)
          return;
        this._myCSXNum = value;
        this.RaisePropertyChanged("mCSX_Number");
      }
    }

    public string CSX
    {
      get
      {
        return this._csx;
      }
      set
      {
        if (this._csx == value)
          return;
        this._csx = value;
        this.RaisePropertyChanged("CSX");
      }
    }

    public string NBT
    {
      get
      {
        return this._nbt;
      }
      set
      {
        if (this._nbt == value)
          return;
        this._nbt = value;
        string str = this._nbt.Substring(1, 13);
        if (!string.IsNullOrEmpty(this._nbt))
        {
          if (this._nbt.Length != 14)
            this.AddError("NBT", "Not proper length for NBT number");
          else if (!HelperUtils.IsValidChecksum(str))
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

    public string Barcode
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
        this._barcode = this._barcode.Trim();
        string barcode = this._barcode;
        if (!string.IsNullOrEmpty(this._barcode))
        {
          if (this._barcode.Length != 12)
            this.AddError("Barcode", "Not proper length for Session ID number");
          else if (!HelperUtils.IsValidChecksum(barcode))
            this.AddError("Barcode", "Not a Valid Barcode number");
          else
            this.RemoveError("Barcode");
        }
        else
          this.AddError("Barcode", "Barcode number cannot be empty");
        this.checkerrors();
        this.RaisePropertyChanged("Barcode");
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
        MatchCollection matchCollection = new Regex("\\s").Matches(this._said);
        if (!HelperUtils.IsValidChecksum(this._said))
          this.AddError("SAID", "Not a Valid South African ID number");
        else
          this.RemoveError("SAID");
        if (matchCollection.Count > 0)
          this.AddError("SAID", "South African ID number cannot have spaces");
        else if (!Regex.IsMatch(this._said, "[0-9]"))
          this.AddError("SAID", "SA Id does not have characters");
        if (!HelperUtils.IsNumeric(this._said))
          this.AddError("SAID", "SA ID cannot have characters");
        else if (!string.IsNullOrWhiteSpace(this._said))
          this.RemoveError("ForeignID");
        else
          this.RemoveError("SAID");
        this.checkerrors();
        this.RaisePropertyChanged("SAID");
        this.RaisePropertyChanged("ForeignID");
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
        if (string.IsNullOrWhiteSpace(this._said) && string.IsNullOrWhiteSpace(this._foreignID))
        {
          this.AddError("SAID", "SA Id missing");
          this.AddError("ForeignID", "Foreign Id missing");
        }
        else if (string.IsNullOrWhiteSpace(this._said) && !string.IsNullOrWhiteSpace(this._foreignID))
        {
          this.RemoveError("SAID");
          this.RemoveError("ForeignID");
        }
        else if (!string.IsNullOrWhiteSpace(this._said))
        {
          this.RemoveError("ForeignID");
        }
        else
        {
          this.RemoveError("ForeignID");
          this.RemoveError("SAID");
        }
        this.checkerrors();
        this.RaisePropertyChanged("ForeignID");
        this.RaisePropertyChanged("SAID");
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
        if (!string.IsNullOrWhiteSpace(this._gender))
        {
          if (this._said.Length == 13)
          {
            int int32 = Convert.ToInt32(this._said.Substring(6, 1));
            if (int32 < 5 && this._gender != "F")
              this.AddError("Gender", "Gender should be F");
            else if (int32 > 4 && this._gender != "M")
              this.AddError("Gender", "Gender should be M");
          }
          else
            this.RemoveError("Gender");
        }
        this.checkerrors();
        this.RaisePropertyChanged("Gender");
      }
    }

    public string Citizenship
    {
      get
      {
        return this._myCitizenship;
      }
      set
      {
        if (this._myCitizenship == value)
          return;
        this._myCitizenship = value;
        this.RaisePropertyChanged("Citizenship");
      }
    }

    public string HomeLanguage
    {
      get
      {
        return this._homeLanguage;
      }
      set
      {
        if (this._homeLanguage == value)
          return;
        this._homeLanguage = value;
        this.RaisePropertyChanged("HomeLanguage");
      }
    }

    public string Classification
    {
      get
      {
        return this._classi;
      }
      set
      {
        if (this._classi == value)
          return;
        this._classi = value;
        bool flag = HelperUtils.IsNumeric(this._classi);
        if (string.IsNullOrWhiteSpace(this._classi))
          this.AddError("Classification", "There should be a value");
        else if (flag)
        {
          if (Convert.ToInt32(this._classi) > 5)
            this.AddError("Classification", "Value should be less than 5");
        }
        else
          this.RemoveError("Classification");
        this.checkerrors();
        this.RaisePropertyChanged("Classification");
      }
    }

    public string Phone
    {
      get
      {
        return this._phone;
      }
      set
      {
        if (this._phone == value)
          return;
        this._phone = value;
        this.RaisePropertyChanged("Phone");
      }
    }

    public string HomeProvince
    {
      get
      {
        return this._mProvince;
      }
      set
      {
        if (this._mProvince == value)
          return;
        this._mProvince = value;
        if (!string.IsNullOrWhiteSpace(this._mProvince))
        {
          if (Convert.ToInt32(this._mProvince) > 10)
            this.AddError("HomeProvince", "No such Province exists");
          else
            this.RemoveError("HomeProvince");
        }
        this.checkerrors();
        this.RaisePropertyChanged("HomeProvince");
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
        this.checkerrors();
        this.RaisePropertyChanged("DOT");
      }
    }

    public string HomeType
    {
      get
      {
        return this.mHomeType;
      }
      set
      {
        this.mHomeType = value;
      }
    }

    public string Helectricity
    {
      get
      {
        return this.mHelectricity;
      }
      set
      {
        this.mHelectricity = value;
      }
    }

    public string School10Km
    {
      get
      {
        return this.mSchool10Km;
      }
      set
      {
        this.mSchool10Km = value;
      }
    }

    public string Homestudy
    {
      get
      {
        return this.mHomestudy;
      }
      set
      {
        this.mHomestudy = value;
      }
    }

    public string SiblingsAttendedUni
    {
      get
      {
        return this.mSiblingsAttendedUni;
      }
      set
      {
        this.mSiblingsAttendedUni = value;
      }
    }

    public string SiblingsAtUni
    {
      get
      {
        return this.mSiblingsAtUni;
      }
      set
      {
        this.mSiblingsAtUni = value;
      }
    }

    public string VenueTime
    {
      get
      {
        return this.mVenueTime;
      }
      set
      {
        this.mVenueTime = value;
      }
    }

    public string VenueCost
    {
      get
      {
        return this.mVenueCost;
      }
      set
      {
        this.mVenueCost = value;
      }
    }

    public string VenueDist
    {
      get
      {
        return this.mVenueDist;
      }
      set
      {
        this.mVenueDist = value;
      }
    }

    public string VenueModeOfTransport
    {
      get
      {
        return this.mVenueModeOfTransport;
      }
      set
      {
        this.mVenueModeOfTransport = value;
      }
    }

    public string SchComputers
    {
      get
      {
        return this.mSchComputers;
      }
      set
      {
        this.mSchComputers = value;
      }
    }

    public string SchLibrary
    {
      get
      {
        return this.mSchLibrary;
      }
      set
      {
        this.mSchLibrary = value;
      }
    }

    public string SchLabs
    {
      get
      {
        return this.mSchLabs;
      }
      set
      {
        this.mSchLabs = value;
      }
    }

    public string SchElectricity
    {
      get
      {
        return this.mSchElectricity;
      }
      set
      {
        this.mSchElectricity = value;
      }
    }

    public string SchWater
    {
      get
      {
        return this.mSchWater;
      }
      set
      {
        this.mSchWater = value;
      }
    }

    public string SchHall
    {
      get
      {
        return this.mSchHall;
      }
      set
      {
        this.mSchHall = value;
      }
    }

    public string SchFields
    {
      get
      {
        return this.mSchFields;
      }
      set
      {
        this.mSchFields = value;
      }
    }

    public string SchHostel
    {
      get
      {
        return this.mSchHostel;
      }
      set
      {
        this.mSchHostel = value;
      }
    }

    public string UsedComputers
    {
      get
      {
        return this.mUsedComputers;
      }
      set
      {
        this.mUsedComputers = value;
      }
    }

    public string UsedLibrary
    {
      get
      {
        return this.mUsedLibrary;
      }
      set
      {
        this.mUsedLibrary = value;
      }
    }

    public string UsedLabs
    {
      get
      {
        return this.mUsedLabs;
      }
      set
      {
        this.mUsedLabs = value;
      }
    }

    public string UsedElectricity
    {
      get
      {
        return this.mUsedElectricity;
      }
      set
      {
        this.mUsedElectricity = value;
      }
    }

    public string UsedRWater
    {
      get
      {
        return this.mUsedRWater;
      }
      set
      {
        this.mUsedRWater = value;
      }
    }

    public string UsedHall
    {
      get
      {
        return this.mUsedHall;
      }
      set
      {
        this.mUsedHall = value;
      }
    }

    public string UsedFields
    {
      get
      {
        return this.mUsedFields;
      }
      set
      {
        this.mUsedFields = value;
      }
    }

    public string UsedHostel
    {
      get
      {
        return this.mUsedHostel;
      }
      set
      {
        this.mUsedHostel = value;
      }
    }

    public string SchoolName
    {
      get
      {
        return this.mSchoolName;
      }
      set
      {
        this.mSchoolName = value;
      }
    }

    public string YrGr12
    {
      get
      {
        return this.mYrGr12;
      }
      set
      {
        this.mYrGr12 = value;
      }
    }

    public string PostalCode
    {
      get
      {
        return this.mPostalCode;
      }
      set
      {
        this.mPostalCode = value;
      }
    }

    public string SchProvince
    {
      get
      {
        return this.mSchProvince;
      }
      set
      {
        this.mSchProvince = value;
      }
    }

    public int Grade12Language
    {
      get
      {
        return this._myGr12L;
      }
      set
      {
        if (this._myGr12L == value)
          return;
        this._myGr12L = value;
        this.RaisePropertyChanged("Grade12Language");
      }
    }

    public int SchoolType
    {
      get
      {
        return this.schoolType;
      }
      set
      {
        if (this.schoolType == value)
          return;
        this.schoolType = value;
        this.RaisePropertyChanged("SchoolType");
      }
    }

    public string Faculty1
    {
      get
      {
        return this._myfaculty1;
      }
      set
      {
        if (this._myfaculty1 == value)
          return;
        this._myfaculty1 = value;
        this.RaisePropertyChanged("Faculty1");
      }
    }

    public string Faculty2
    {
      get
      {
        return this._myfaculty2;
      }
      set
      {
        if (this._myfaculty2 == value)
          return;
        this._myfaculty2 = value;
        this.RaisePropertyChanged("Faculty2");
      }
    }

    public string Faculty3
    {
      get
      {
        return this._myFaculty3;
      }
      set
      {
        if (this._myFaculty3 == value)
          return;
        this._myFaculty3 = value;
        this.RaisePropertyChanged("Faculty3");
      }
    }

    public string EOL
    {
      get
      {
        return this.mEOL;
      }
      set
      {
        this.mEOL = value;
      }
    }

    public datFileAttributes DatFile
    {
      get
      {
        return this._mydatFile;
      }
      set
      {
        if (this._mydatFile == value)
          return;
        this._mydatFile = value;
        this.RaisePropertyChanged("DatFile");
      }
    }

    public string CSX_Number { get; set; }

    public string CSX_Part { get; set; }

    public int ErrorCount
    {
      get
      {
        return this._myerrorcount;
      }
      set
      {
        if (this._myerrorcount == value)
          return;
        this._myerrorcount = value;
        this.RaisePropertyChanged("ErrorCount");
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

    public BioQADatRecord()
    {
    }

    public BioQADatRecord(string file)
    {
      this.DatFile = new datFileAttributes();
      this.DatFile.SName = Path.GetFileNameWithoutExtension(file).ToUpper();
      this.CSX_Number = this.DatFile.CSX.ToString();
    }

    private void checkerrors()
    {
      if (this.HasErrors)
        this.ErrorCount = this._errors.Count;
      else
        this.ErrorCount = 0;
    }
  }
}
