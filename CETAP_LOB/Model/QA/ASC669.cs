// Decompiled with JetBrains decompiler
// Type: LOB.Model.QA.ASC669
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FileHelpers;

namespace CETAP_LOB.Model.QA
{
  [IgnoreLast(1)]
  [FixedLengthRecord(FixedMode.ExactLength)]
  public sealed class ASC669
  {
    [FieldFixedLength(3)]
    private string mCSX_Number;
    [FieldFixedLength(37)]
    private string mCSX;
    [FieldFixedLength(14)]
    private string mNBT;
    [FieldFixedLength(12)]
    private string mSessionID;
    [FieldFixedLength(13)]
    private string mSAID;
    [FieldFixedLength(15)]
    private string mForeignID;
    [FieldFixedLength(1)]
    private string mGender;
    [FieldFixedLength(1)]
    private string mIDType;
    [FieldFixedLength(2)]
    private string mHomeLanguage;
    [FieldFixedLength(1)]
    private string mClassification;
    [FieldFixedLength(10)]
    private string mContactNo;
    [FieldFixedLength(2)]
    private string mHomeProvince;
    [FieldFixedLength(8)]
    private string mDOT;
    [FieldFixedLength(1)]
    private string mHomeType;
    [FieldFixedLength(1)]
    private string mHelectricity;
    [FieldFixedLength(1)]
    private string mSchool10Km;
    [FieldFixedLength(1)]
    private string mHomestudy;
    [FieldFixedLength(1)]
    private string mSiblingsAttendedUni;
    [FieldFixedLength(1)]
    private string mSiblingsAtUni;
    [FieldFixedLength(1)]
    private string mVenueTime;
    [FieldFixedLength(1)]
    private string mVenueCost;
    [FieldFixedLength(1)]
    private string mVenueDist;
    [FieldFixedLength(1)]
    private string mVenueModeOfTransport;
    [FieldFixedLength(1)]
    private string mSchComputers;
    [FieldFixedLength(1)]
    private string mSchLibrary;
    [FieldFixedLength(1)]
    private string mSchLabs;
    [FieldFixedLength(1)]
    private string mSchElectricity;
    [FieldFixedLength(1)]
    private string mSchWater;
    [FieldFixedLength(1)]
    private string mSchHall;
    [FieldFixedLength(1)]
    private string mSchFields;
    [FieldFixedLength(1)]
    private string mSchHostel;
    [FieldFixedLength(1)]
    private string mUsedComputers;
    [FieldFixedLength(1)]
    private string mUsedLibrary;
    [FieldFixedLength(1)]
    private string mUsedLabs;
    [FieldFixedLength(1)]
    private string mUsedElectricity;
    [FieldFixedLength(1)]
    private string mUsedRWater;
    [FieldFixedLength(1)]
    private string mUsedHall;
    [FieldFixedLength(1)]
    private string mUsedFields;
    [FieldFixedLength(1)]
    private string mUsedHostel;
    [FieldFixedLength(44)]
    private string mSchoolName;
    [FieldFixedLength(4)]
    private string mYrGr12;
    [FieldFixedLength(4)]
    private string mPostalCode;
    [FieldFixedLength(2)]
    private string mSchProvince;
    [FieldFixedLength(1)]
    private string mGr12Language;
    [FieldFixedLength(1)]
    private string mSchType;
    [FieldFixedLength(1)]
    private string mFaculty1;
    [FieldFixedLength(1)]
    private string mFaculty2;
    [FieldFixedLength(1)]
    private string mFaculty3;
    [FieldFixedLength(1)]
    private string mEOL;

    public string CSX_Number
    {
      get
      {
        return this.mCSX_Number;
      }
      set
      {
        this.mCSX_Number = value;
      }
    }

    public string CSX
    {
      get
      {
        return this.mCSX;
      }
      set
      {
        this.mCSX = value;
      }
    }

    public string NBT
    {
      get
      {
        return this.mNBT;
      }
      set
      {
        this.mNBT = value;
      }
    }

    public string SessionID
    {
      get
      {
        return this.mSessionID;
      }
      set
      {
        this.mSessionID = value;
      }
    }

    public string SAID
    {
      get
      {
        return this.mSAID;
      }
      set
      {
        this.mSAID = value;
      }
    }

    public string ForeignID
    {
      get
      {
        return this.mForeignID;
      }
      set
      {
        this.mForeignID = value;
      }
    }

    public string Gender
    {
      get
      {
        return this.mGender;
      }
      set
      {
        this.mGender = value;
      }
    }

    public string IDType
    {
      get
      {
        return this.mIDType;
      }
      set
      {
        this.mIDType = value;
      }
    }

    public string HomeLanguage
    {
      get
      {
        return this.mHomeLanguage;
      }
      set
      {
        this.mHomeLanguage = value;
      }
    }

    public string Classification
    {
      get
      {
        return this.mClassification;
      }
      set
      {
        this.mClassification = value;
      }
    }

    public string ContactNo
    {
      get
      {
        return this.mContactNo;
      }
      set
      {
        this.mContactNo = value;
      }
    }

    public string HomeProvince
    {
      get
      {
        return this.mHomeProvince;
      }
      set
      {
        this.mHomeProvince = value;
      }
    }

    public string DOT
    {
      get
      {
        return this.mDOT;
      }
      set
      {
        this.mDOT = value;
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

    public string Gr12Language
    {
      get
      {
        return this.mGr12Language;
      }
      set
      {
        this.mGr12Language = value;
      }
    }

    public string SchType
    {
      get
      {
        return this.mSchType;
      }
      set
      {
        this.mSchType = value;
      }
    }

    public string Faculty1
    {
      get
      {
        return this.mFaculty1;
      }
      set
      {
        this.mFaculty1 = value;
      }
    }

    public string Faculty2
    {
      get
      {
        return this.mFaculty2;
      }
      set
      {
        this.mFaculty2 = value;
      }
    }

    public string Faculty3
    {
      get
      {
        return this.mFaculty3;
      }
      set
      {
        this.mFaculty3 = value;
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
  }
}
