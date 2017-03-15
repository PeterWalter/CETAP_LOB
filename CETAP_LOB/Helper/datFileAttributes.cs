// Decompiled with JetBrains decompiler
// Type: LOB.Helper.datFileAttributes
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CETAP_LOB.Helper
{
  public class datFileAttributes : ModelBase
  {
    private string _mat_Lang = "";
    public const string SNamePropertyName = "SName";
    private int _profile;
    private int _venuecode;
    private string _filecomb;
    private string _filepath;
    private string _firstRecord;
    private int _randNumber;
    private int _recCount;
    private FileInfo _info;
    private string _clientType;
    private string _client;
    private string _testCode;
    private string _aql_Lang;
    private int _csx;
    private string _nameWithoutext;
    private string _ncs_ModifyFlag;
    private string _ncs_Errorflag;
    private bool _edited;

    public string SName
    {
      get
      {
        return this._nameWithoutext;
      }
      set
      {
        if (this._nameWithoutext == value)
          return;
        this._nameWithoutext = value;
        if (this._nameWithoutext.Length != 22)
          this.AddError("SName", "Wrong File Name");
        else
          this.RemoveError("SName");
        if (this._nameWithoutext.Length == 22)
          this.SplitFileparts(this._nameWithoutext);
        this.RaisePropertyChanged("SName");
      }
    }

    public int NoOfErrors { get; set; }

    public int RecordCount
    {
      get
      {
        return this._recCount;
      }
      set
      {
        this._recCount = value;
      }
    }

    public string AQL_Language
    {
      get
      {
        return this._aql_Lang;
      }
      set
      {
        this._aql_Lang = value;
      }
    }

    public bool Edited
    {
      get
      {
        return this._edited;
      }
    }

    public string MAT_Language
    {
      get
      {
        return this._mat_Lang;
      }
      set
      {
        this._mat_Lang = value;
      }
    }

    public int RandNumber
    {
      get
      {
        return this._randNumber;
      }
      set
      {
        value = this._randNumber;
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
        this._venuecode = value;
      }
    }

    public int Profile
    {
      get
      {
        return this._profile;
      }
      set
      {
        this._profile = value;
      }
    }

    public string FileCombination
    {
      get
      {
        return this._filecomb;
      }
      set
      {
      }
    }

    public string FilePath
    {
      get
      {
        return this._filepath;
      }
      set
      {
        this._filepath = value;
      }
    }

    public FileInfo info
    {
      get
      {
        return this._info;
      }
      set
      {
        this._info = value;
      }
    }

    public string Client
    {
      get
      {
        return this._client;
      }
      set
      {
        this._client = value;
      }
    }

    public string FirstRecord
    {
      get
      {
        return this._firstRecord;
      }
    }

    public int CSX
    {
      get
      {
        return this._csx;
      }
      set
      {
        this._csx = value;
      }
    }

    public string TestCode
    {
      get
      {
        return this._testCode;
      }
    }

    public datFileAttributes()
    {
    }

    public datFileAttributes(string filepath)
    {
      this._filepath = filepath;
      this.readLineAsync();
      this._nameWithoutext = Path.GetFileNameWithoutExtension(this._filepath).ToUpper();
      if (this._nameWithoutext.Length != 22)
        return;
      this.SplitFileparts(this._nameWithoutext);
    }

    public async Task readLineAsync()
    {
      try
      {
        using (FileStream fileStream = File.Open(this._filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
          using (StreamReader streamReader = new StreamReader((Stream) fileStream))
          {
            string str = streamReader.ReadLine();
            this._firstRecord = str;
            this._ncs_ModifyFlag = str.Substring(21, 1);
            this._ncs_Errorflag = str.Substring(23, 1);
            if (this._ncs_ModifyFlag == "Y" && this._ncs_Errorflag == " ")
              this._edited = true;
            this._csx = Convert.ToInt32(str.Substring(0, 3));
            streamReader.Close();
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void SplitFileparts(string namefile)
    {
      this._recCount = Convert.ToInt32(namefile.Substring(19, 3));
      this._profile = Convert.ToInt32(namefile.Substring(4, 2));
      this._testCode = namefile.Substring(0, 4);
      switch (this._testCode)
      {
        case "0105":
          this._filecomb = "AQLE";
          this._aql_Lang = "E";
          break;
        case "0115":
          this._filecomb = "AQLA";
          this._aql_Lang = "A";
          break;
        case "0106":
          this._filecomb = "MATE";
          this._mat_Lang = "E";
          break;
        case "0116":
          this._filecomb = "MATA";
          this._mat_Lang = "A";
          break;
        case "0107":
          this._filecomb = "AQLE_MATE";
          this._aql_Lang = "E";
          this._mat_Lang = "E";
          break;
        case "0117":
          this._filecomb = "AQLA_MATA";
          this._aql_Lang = "A";
          this._mat_Lang = "A";
          break;
        case "0127":
          this._filecomb = "AQLE_MATA";
          this._aql_Lang = "E";
          this._mat_Lang = "A";
          break;
        case "0137":
          this._filecomb = "AQLA_MATE";
          this._aql_Lang = "A";
          this._mat_Lang = "E";
          break;
        default:
          this.AddError("SName", "No Such Test Code");
          break;
      }
      this._clientType = namefile.Substring(18, 1);
      if (this._clientType != "O")
      {
        this._randNumber = Convert.ToInt32(namefile.Substring(13, 5));
        this._venuecode = Convert.ToInt32(namefile.Substring(7, 5));
      }
      else
      {
        this._randNumber = Convert.ToInt32(namefile.Substring(11, 5));
        this._venuecode = Convert.ToInt32(namefile.Substring(6, 5));
      }
      switch (this._clientType)
      {
        case "R":
          this._client = "National";
          break;
        case "X":
          this._client = "Re-score";
          break;
        case "M":
          this._client = "Moderated";
          break;
        case "W":
          this._client = "Remote";
          break;
        case "S":
          this._client = "Special";
          break;
        case "O":
          this._client = "Walk-in Bio";
          break;
        case "D":
          this._client = "Disability";
          break;
        case "B":
          this._client = "Braille";
          break;
        case "L":
          this._client = "Large Print";
          break;
        default:
          this._client = "Unknown Client";
          this.AddError("SName", "No Such Client");
          break;
      }
    }

    public override string ToString()
    {
      return string.Format("{0}{1:00}C{2:00000}B{3:00000}{4}{5:000}", (object) this._testCode, (object) this._profile, (object) this._venuecode, (object) this._randNumber, (object) this._clientType, (object) this._recCount);
    }
  }
}
