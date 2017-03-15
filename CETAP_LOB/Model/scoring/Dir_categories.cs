// Decompiled with JetBrains decompiler
// Type: LOB.Model.scoring.Dir_categories
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CETAP_LOB.Model.scoring
{
  public class Dir_categories
  {
    private string _folder = "";
    private List<string> _filesinFolder = new List<string>();
    private List<string> _ResponseMatrix = new List<string>();
    private List<string> _AQLScorefiles = new List<string>();
    private List<string> _MATScorefiles = new List<string>();
    private string _AnswersheetBio = "";

    public string AnswerSheetBio
    {
      get
      {
        return this._AnswersheetBio;
      }
      set
      {
        this._AnswersheetBio = value;
      }
    }

    public List<string> AQLScorefiles
    {
      get
      {
        return this._AQLScorefiles;
      }
      set
      {
        this._AQLScorefiles = value;
      }
    }

    public List<string> MATScoresfiles
    {
      get
      {
        return this._MATScorefiles;
      }
      set
      {
        this._MATScorefiles = value;
      }
    }

    public string Dir
    {
      get
      {
        return this._folder;
      }
      set
      {
        this._folder = value;
      }
    }

    public List<string> ResponseMatrix
    {
      get
      {
        return this._ResponseMatrix;
      }
      set
      {
        this._ResponseMatrix = value;
      }
    }

    public List<string> FilesinFolder
    {
      get
      {
        return this._filesinFolder;
      }
      set
      {
        this._filesinFolder = value;
      }
    }

    public Dir_categories(string path)
    {
      this._folder = path;
      this.SortFiles(((IEnumerable<string>) Directory.GetFiles(this._folder)).ToList<string>());
    }

    private void SortFiles(List<string> thefiles)
    {
      foreach (string thefile in thefiles)
      {
        string fileName = Path.GetFileName(thefile);
        this._filesinFolder.Add(fileName);
        if (Path.GetExtension(thefile) == ".xlsx")
        {
          string str = fileName.Split(' ')[0];
          switch (str.Substring(0, 3))
          {
            case "NBT":
              if (str.Substring(0, 7) == "NBT_Ans")
              {
                this._AnswersheetBio = thefile;
                break;
              }
              break;
            case "AQL":
              this._AQLScorefiles.Add(thefile);
              break;
            case "MAT":
              this._MATScorefiles.Add(thefile);
              break;
          }
        }
        if (fileName.Contains("Response"))
          this._ResponseMatrix.Add(thefile);
      }
    }
  }
}
