// Decompiled with JetBrains decompiler
// Type: LOB.Model.scoring.ReadExcel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace CETAP_LOB.Model.scoring
{
  public class ReadExcel
  {
    private string _filename = "";
    private List<AQL_Score> aql = new List<AQL_Score>();
    private List<MAT_Score> mat = new List<MAT_Score>();
    private string _type;

    public string Filename
    {
      get
      {
        return this._filename;
      }
      set
      {
        this._filename = value;
      }
    }

    public List<AQL_Score> AQLScores
    {
      get
      {
        return this.aql;
      }
      set
      {
        this.aql = value;
      }
    }

    public List<MAT_Score> MATScores
    {
      get
      {
        return this.mat;
      }
      set
      {
        this.mat = value;
      }
    }

    public ReadExcel(string File, string type)
    {
      this._filename = File;
      this._type = type;
      this.ReadExcelFile();
    }

    private void ReadExcelFile()
    {
      IXLWorksheet xlWorksheet = new XLWorkbook(this._filename).Worksheet(1);
      foreach (IXLTableRow row in (IEnumerable<IXLTableRow>) xlWorksheet.Range(xlWorksheet.FirstCellUsed().Address, xlWorksheet.LastCellUsed().Address).AsTable().DataRange.Rows((Func<IXLTableRow, bool>) null))
      {
        if (!row.Field("ID").IsEmpty())
        {
          switch (this._type)
          {
            case "AQL":
              AQL_Score aqlScore = new AQL_Score();
              string str1 = row.Field("ID").GetString();
              string valueCached1 = row.Field("AL_Score").ValueCached;
              string valueCached2 = row.Field("QL_Score").ValueCached;
              aqlScore.ID = Convert.ToInt64(str1);
              aqlScore.AL = new int?(Convert.ToInt32(valueCached1));
              aqlScore.QL = new int?(Convert.ToInt32(valueCached2));
              this.aql.Add(aqlScore);
              continue;
            case "MAT":
              MAT_Score matScore = new MAT_Score();
              string str2 = row.Field("ID").GetString();
              string valueCached3 = row.Field("MAT_Score").ValueCached;
              matScore.ID = Convert.ToInt64(str2);
              matScore.MAT = new int?(Convert.ToInt32(valueCached3));
              this.mat.Add(matScore);
              continue;
            default:
              continue;
          }
        }
      }
    }
  }
}
