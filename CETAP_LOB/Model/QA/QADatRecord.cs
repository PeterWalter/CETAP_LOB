// Decompiled with JetBrains decompiler
// Type: LOB.Model.QA.QADatRecord
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Helper;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;

namespace CETAP_LOB.Model.QA
{
  public class QADatRecord : ModelBase
  {
    private string _surname = "";
    private string _myname = "";
    private string _initials = "";
    private string _said = "";
    private string _foreignID = "";
    public const string TestDatePropertyName = "TestDate";
    public const string errorCountPropertyName = "errorCount";
    public const string DatFilePropertyName = "DatFile";
    public const string ReferencePropertyName = "Reference";
    public const string BarcodePropertyName = "Barcode";
    public const string SurnamePropertyName = "Surname";
    public const string FirstNamePropertyName = "FirstName";
    public const string initialsPropertyName = "initials";
    public const string SAIDPropertyName = "SAID";
    public const string ForeignIDPropertyName = "ForeignID";
    public const string DOBPropertyName = "DOB";
    public const string IDTypePropertyName = "IDType";
    public const string GenderPropertyName = "Gender";
    public const string CitizenshipPropertyName = "Citizenship";
    public const string ClassificationPropertyName = "Classification";
    public const string VenueCodePropertyName = "VenueCode";
    public const string DOTPropertyName = "DOT";
    public const string HomeLanguagePropertyName = "HomeLanguage";
    public const string SchoolLanguagePropertyName = "SchoolLanguage";
    public const string AQL_LanguagePropertyName = "AQL_Language";
    public const string AQL_CodePropertyName = "AQL_Code";
    public const string Section1PropertyName = "Section1";
    public const string Section2PropertyName = "Section2";
    public const string Section3PropertyName = "Section3";
    public const string Section4PropertyName = "Section4";
    public const string Section5PropertyName = "Section5";
    public const string Section6PropertyName = "Section6";
    public const string Section7PropertyName = "Section7";
    public const string Mat_LanguagePropertyName = "Mat_Language";
    public const string MatCodePropertyName = "MatCode";
    public const string MathSectionPropertyName = "MathSection";
    public const string Faculty1PropertyName = "Faculty1";
    public const string Faculty2PropertyName = "Faculty2";
    public const string Faculty3PropertyName = "Faculty3";
    public const string EOLPropertyName = "EOL";
    public const string EditedPropertyName = "Edited";
    public const string ScanNoPropertyName = "ScanNo";
    public const string IsSelectedPropertyName = "IsSelected";
    private DateTime _testDate;
    private int _mycount;
    private datFileAttributes _mydatFile;
    private string _nbt;
    private string _barcode;
    private DateTime _dob;
    private string _myIdType;
    private string _gender;
    private string _myCitizenship;
    private string _classi;
    private string _myVenueCode;
    private DateTime _dot;
    private string _myHomeLanguage;
    private string _Slanguage;
    private string _myAQL_Language;
    private string _myAQLCode;
    private ObservableCollection<DatAnswer> _mysection1;
    private ObservableCollection<DatAnswer> _mysection2;
    private ObservableCollection<DatAnswer> _mySection3;
    private ObservableCollection<DatAnswer> _mySection4;
    private ObservableCollection<DatAnswer> mySection5;
    private ObservableCollection<DatAnswer> _mySection6;
    private ObservableCollection<DatAnswer> _mySection7;
    private string _myMat_Language;
    private string _myMatCode;
    private ObservableCollection<DatAnswer> _myMathSection;
    private string _myfaculty1;
    private string _myFaculty2;
    private string _myFaculty3;
    private string _myEOL;
    private string _myEdited;
    private int _myScanNo;
    private bool _isSelected;

    public string CSX_Number { get; set; }

    public string CSX_Part { get; set; }

    public DateTime TestDate
    {
      get
      {
        return this._testDate;
      }
      set
      {
        if (this._testDate == value)
          return;
        this._testDate = value;
        this.RaisePropertyChanged("TestDate");
        this.RaisePropertyChanged("DOT");
      }
    }

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

    public string Reference
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
            this.AddError("Reference", "Not proper length for NBT number");
          else if (!HelperUtils.IsValidChecksum(str))
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
        this._surname = this._surname.Trim();
        if (string.IsNullOrEmpty(this._surname))
          this.AddError("Surname", "Surname cannot be empty");
        else
          this.RemoveError("Surname");
        MatchCollection matchCollection = new Regex("\\s").Matches(this._surname);
        if (!string.IsNullOrEmpty(this._surname))
        {
          if (Regex.IsMatch(this._surname, "\\d"))
            this.AddError("Surname", "Surname cannot have digits");
          else if (Regex.IsMatch(this._surname, "[\\.\\*=!@#%\\&\\$]"))
            this.AddError("Surname", "First name cannot have special characters");
          else if (matchCollection.Count < 3)
          {
            string surname = this._surname;
            char[] chArray = new char[1]{ ' ' };
            foreach (string str in surname.Split(chArray))
            {
              if (str.Length < 3)
                this.AddError("Surname", "Part of Surname has few letters");
            }
          }
          else if (matchCollection.Count > 2)
            this.AddError("Surname", "Surname has too many spaces");
          else
            this.RemoveError("Surname");
          ListSurnames.surname = this._surname;
          if (ListSurnames.IsFound)
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
        this._myname = this._myname.Trim();
        MatchCollection matchCollection = new Regex("\\s").Matches(this._myname);
        if (string.IsNullOrEmpty(this._myname))
          this.AddError("FirstName", "FirstName cannot be empty");
        else
          this.RemoveError("FirstName");
        if (!string.IsNullOrWhiteSpace(this._myname))
        {
          if (Regex.IsMatch(this._myname, "\\d"))
            this.AddError("FirstName", "First name cannot have digits");
          else if (Regex.IsMatch(this._myname, "[\\.\\*=!@#%\\&\\$]"))
            this.AddError("FirstName", "First name cannot have special characters");
          else if (matchCollection.Count > 2)
            this.AddError("FirstName", "Name has too many spaces");
          else if (matchCollection.Count < 3)
          {
            string myname = this._myname;
            char[] chArray = new char[1]{ ' ' };
            foreach (string str in myname.Split(chArray))
            {
              if (str.Length < 3)
                this.AddError("FirstName", "Part of Name has few letters");
            }
          }
          else
            this.RemoveError("FirstName");
          ApplicantNames.FirstName = this._myname;
          if (ApplicantNames.IsFound)
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
        this.checkerrors();
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
        this.CheckDOB();
        this.checkerrors();
        this.RaisePropertyChanged("SAID");
        this.RaisePropertyChanged("DOB");
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
        else if (!string.IsNullOrWhiteSpace(this._said) || !string.IsNullOrEmpty(this._said))
          this.CheckDOB();
        else
          this.RemoveError("DOB");
        this.checkerrors();
        this.RaisePropertyChanged("DOB");
      }
    }

    public string IDType
    {
      get
      {
        return this._myIdType;
      }
      set
      {
        if (this._myIdType == value)
          return;
        this._myIdType = value;
        string str = this._myIdType.Trim();
        if (!string.IsNullOrWhiteSpace(this._said) || !string.IsNullOrEmpty(this._said))
        {
          if (this.CSX_Number == "761")
          {
            if (str != "1")
              this.AddError("IDType", "type should be 1");
            else
              this.RemoveError("IDType");
          }
          else if (this.CSX_Number == "667")
          {
            if (this._myIdType != "S")
              this.AddError("IDType", "type should be S");
            else
              this.RemoveError("IDType");
          }
        }
        else if (this.CSX_Number == "761")
        {
          if (str != "2")
            this.AddError("IDType", "type should be 2");
          else
            this.RemoveError("IDType");
        }
        else if (this.CSX_Number == "667")
        {
          if (str != "F")
            this.AddError("IDType", "type should be F");
          else
            this.RemoveError("IDType");
        }
        this.checkerrors();
        this.RaisePropertyChanged("IDType");
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
        if (!string.IsNullOrWhiteSpace(this._said) || !string.IsNullOrEmpty(this._said))
        {
          if (this._said.Length == 13)
          {
            int int32 = Convert.ToInt32(this._said.Substring(6, 1));
            if (this.CSX_Number == "761")
            {
              if (int32 < 5 && this._gender != "2")
                this.AddError("Gender", "Gender should be 2");
              else if (int32 > 4 && this._gender != "1")
                this.AddError("Gender", "Wrong Gender should be 1");
            }
            if (this.CSX_Number == "667")
            {
              if (int32 < 5 && this._gender != "F")
                this.AddError("Gender", "Gender should be F");
              else if (int32 > 4 && this._gender != "M")
                this.AddError("Gender", "Wrong Gender, should be M");
            }
          }
        }
        else
          this.RemoveError("Gender");
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

    public string VenueCode
    {
      get
      {
        return this._myVenueCode;
      }
      set
      {
        if (this._myVenueCode == value)
          return;
        this._myVenueCode = value;
        if (this._myVenueCode != this._mydatFile.VenueCode.ToString("D5"))
          this.AddError("VenueCode", "Wrong Venue Code");
        else
          this.RemoveError("VenueCode");
        this.checkerrors();
        this.RaisePropertyChanged("VenueCode");
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
        if (this._dot != this._testDate)
          this.AddError("DOT", "Wrong Test date");
        else
          this.RemoveError("DOT");
        this.checkerrors();
        this.RaisePropertyChanged("DOT");
      }
    }

    public string HomeLanguage
    {
      get
      {
        return this._myHomeLanguage;
      }
      set
      {
        if (this._myHomeLanguage == value)
          return;
        this._myHomeLanguage = value;
        bool flag = HelperUtils.IsNumeric(this._myHomeLanguage);
        if (string.IsNullOrWhiteSpace(this._myHomeLanguage))
          this.AddError("HomeLanguage", "Language cannot be empty");
        else if (flag)
        {
          if (Convert.ToInt32(this._myHomeLanguage) > 12)
            this.AddError("HomeLanguage", "Language should be below 13");
        }
        else
          this.RemoveError("HomeLanguage");
        this.checkerrors();
        this.RaisePropertyChanged("HomeLanguage");
      }
    }

    public string SchoolLanguage
    {
      get
      {
        return this._Slanguage;
      }
      set
      {
        if (this._Slanguage == value)
          return;
        this._Slanguage = value;
        bool flag = HelperUtils.IsNumeric(this._Slanguage);
        if (string.IsNullOrWhiteSpace(this._Slanguage))
          this.AddError("SchoolLanguage", "Language cannot be empty");
        else if (flag)
        {
          if (Convert.ToInt32(this._Slanguage) > 3)
            this.AddError("SchoolLanguage", "Language should be 01, 02 or 03");
        }
        else
          this.RemoveError("SchoolLanguage");
        this.checkerrors();
        this.RaisePropertyChanged("SchoolLanguage");
      }
    }

    public string AQL_Language
    {
      get
      {
        return this._myAQL_Language;
      }
      set
      {
        if (this._myAQL_Language == value)
          return;
        this._myAQL_Language = value;
        if (this._myAQL_Language.Trim() != this.DatFile.AQL_Language)
          this.AddError("AQL_Language", "Wrong Language");
        else
          this.RemoveError("AQL_Language");
        this.checkerrors();
        this.RaisePropertyChanged("AQL_Language");
      }
    }

    public string AQL_Code
    {
      get
      {
        return this._myAQLCode;
      }
      set
      {
        if (this._myAQLCode == value)
          return;
        this._myAQLCode = value;
        string str = this._myAQLCode.Trim();
        if (this.AQLCOD.Length > 0)
          this.AQLCOD = Convert.ToInt32(this.AQLCOD).ToString("000");
        if (this.AQLCOD != str)
          this.AddError("AQL_Code", "Wrong AQL Code");
        else
          this.RemoveError("AQL_Code");
        this.checkerrors();
        this.RaisePropertyChanged("AQL_Code");
      }
    }

    public ObservableCollection<DatAnswer> Section1
    {
      get
      {
        return this._mysection1;
      }
      set
      {
        if (this._mysection1 == value)
          return;
        this._mysection1 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._mysection1)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section1", "Errors in section 1");
        else
          this.RemoveError("Section1");
        this.checkerrors();
        this.RaisePropertyChanged("Section1");
      }
    }

    public ObservableCollection<DatAnswer> Section2
    {
      get
      {
        return this._mysection2;
      }
      set
      {
        if (this._mysection2 == value)
          return;
        this._mysection2 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._mysection2)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section2", "Errors in section 2");
        else
          this.RemoveError("Section2");
        this.checkerrors();
        this.RaisePropertyChanged("Section2");
      }
    }

    public ObservableCollection<DatAnswer> Section3
    {
      get
      {
        return this._mySection3;
      }
      set
      {
        if (this._mySection3 == value)
          return;
        this._mySection3 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._mySection3)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section3", "Errors in section 3");
        else
          this.RemoveError("Section3");
        this.checkerrors();
        this.RaisePropertyChanged("Section3");
      }
    }

    public ObservableCollection<DatAnswer> Section4
    {
      get
      {
        return this._mySection4;
      }
      set
      {
        if (this._mySection4 == value)
          return;
        this._mySection4 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._mySection4)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section4", "Errors in section 4");
        else
          this.RemoveError("Section4");
        this.checkerrors();
        this.RaisePropertyChanged("Section4");
      }
    }

    public ObservableCollection<DatAnswer> Section5
    {
      get
      {
        return this.mySection5;
      }
      set
      {
        if (this.mySection5 == value)
          return;
        this.mySection5 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this.mySection5)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section5", "Errors in section 5");
        else
          this.RemoveError("Section5");
        this.checkerrors();
        this.RaisePropertyChanged("Section5");
      }
    }

    public ObservableCollection<DatAnswer> Section6
    {
      get
      {
        return this._mySection6;
      }
      set
      {
        if (this._mySection6 == value)
          return;
        this._mySection6 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._mySection6)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section6", "Errors in section 6");
        else
          this.RemoveError("Section6");
        this.checkerrors();
        this.RaisePropertyChanged("Section6");
      }
    }

    public ObservableCollection<DatAnswer> Section7
    {
      get
      {
        return this._mySection7;
      }
      set
      {
        if (this._mySection7 == value)
          return;
        this._mySection7 = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._mySection7)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("Section7", "Errors in section 7");
        else
          this.RemoveError("Section7");
        this.checkerrors();
        this.RaisePropertyChanged("Section7");
      }
    }

    public string Mat_Language
    {
      get
      {
        return this._myMat_Language;
      }
      set
      {
        if (this._myMat_Language == value)
          return;
        this._myMat_Language = value;
        this._myMat_Language = this._myMat_Language.Trim();
        if (this._myMat_Language != this.DatFile.MAT_Language)
          this.AddError("Mat_Language", "Wrong Language");
        else
          this.RemoveError("Mat_Language");
        this.checkerrors();
        this.RaisePropertyChanged("Mat_Language");
      }
    }

    public string MatCode
    {
      get
      {
        return this._myMatCode;
      }
      set
      {
        if (this._myMatCode == value)
          return;
        this._myMatCode = value;
        string str = this._myMatCode.Trim();
        if (this.MATCOD.Length > 0)
          this.MATCOD = Convert.ToInt32(this.MATCOD).ToString("000");
        if (string.IsNullOrWhiteSpace(str))
        {
          if (this.MATCOD != "")
            this.AddError("MatCode", "MAT code should be " + this.MATCOD);
        }
        else if (!string.IsNullOrWhiteSpace(str))
        {
          if (Convert.ToInt32(str).ToString("000") != this.MATCOD)
            this.AddError("MatCode", "MAT code should be " + this.MATCOD);
        }
        else
          this.RemoveError("MatCode");
        if (this.MATCOD == "" && str == "")
          this.RemoveError("MatCode");
        this.checkerrors();
        this.RaisePropertyChanged("MatCode");
      }
    }

    public ObservableCollection<DatAnswer> MathSection
    {
      get
      {
        return this._myMathSection;
      }
      set
      {
        if (this._myMathSection == value)
          return;
        this._myMathSection = value;
        bool flag = false;
        foreach (ModelBase modelBase in (Collection<DatAnswer>) this._myMathSection)
        {
          if (modelBase.HasErrors)
            flag = true;
        }
        if (flag)
          this.AddError("MathSection", "Errors in MAT section");
        else
          this.RemoveError("MathSection");
        if (this._mydatFile.TestCode == "0105" || this._mydatFile.TestCode == "0115")
        {
          foreach (DatAnswer datAnswer in (Collection<DatAnswer>) this._myMathSection)
          {
            if ((int) datAnswer.Value != 32)
              flag = true;
          }
          if (flag)
            this.AddError("MathSection", "MAT section should be empty");
          else
            this.RemoveError("MathSection");
        }
        this.checkerrors();
        this.RaisePropertyChanged("MathSection");
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
        this._myfaculty1 = this._myfaculty1.Trim();
        if (string.IsNullOrEmpty(this._myfaculty1))
          this.AddError("Faculty1", "Faculty cannot be empty");
        else if (this._myfaculty1 == "*")
          this.AddError("Faculty1", "Faculty cannot have (*)");
        else
          this.RemoveError("Faculty1");
        this.checkerrors();
        this.RaisePropertyChanged("Faculty1");
      }
    }

    public string Faculty2
    {
      get
      {
        return this._myFaculty2;
      }
      set
      {
        if (this._myFaculty2 == value)
          return;
        this._myFaculty2 = value;
        if (!string.IsNullOrEmpty(this._myFaculty2.Trim()))
        {
          if (this._myFaculty2 == "*")
            this.AddError("Faculty2", "Faculty cannot have (*)");
        }
        else
          this.RemoveError("Faculty2");
        this.checkerrors();
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
        if (!string.IsNullOrEmpty(this._myFaculty3.Trim()))
        {
          if (this._myFaculty3 == "*")
            this.AddError("Faculty3", "Faculty cannot have (*)");
        }
        else
          this.RemoveError("Faculty3");
        this.checkerrors();
        this.RaisePropertyChanged("Faculty3");
      }
    }

    public string EOL
    {
      get
      {
        return this._myEOL;
      }
      set
      {
        if (this._myEOL == value)
          return;
        this._myEOL = value;
        this.RaisePropertyChanged("EOL");
      }
    }

    public string Edited
    {
      get
      {
        return this._myEdited;
      }
      set
      {
        if (this._myEdited == value)
          return;
        this._myEdited = value;
        this.RaisePropertyChanged("Edited");
      }
    }

    public int ScanNo
    {
      get
      {
        return this._myScanNo;
      }
      set
      {
        if (this._myScanNo == value)
          return;
        this._myScanNo = value;
        this.RaisePropertyChanged("ScanNo");
      }
    }

    public string AQLCOD { get; set; }

    public string MATCOD { get; set; }

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

    public QADatRecord()
    {
    }

    public QADatRecord(string file)
    {
      this.DatFile = new datFileAttributes();
      this.DatFile.SName = Path.GetFileNameWithoutExtension(file).ToUpper();
      this.CSX_Number = this.DatFile.CSX.ToString();
    }

    private void checkerrors()
    {
      if (this.HasErrors)
        this.errorCount = this._errors.Count;
      else
        this.errorCount = 0;
    }

    public void CheckDOB()
    {
      if (HelperUtils.DOBfromSAID(this._said) != string.Format("{0:dd/MM/yyyy}", (object) this._dob))
        this.AddError("DOB", "ID and DOB not the same");
      else
        this.RemoveError("DOB");
    }
  }
}
