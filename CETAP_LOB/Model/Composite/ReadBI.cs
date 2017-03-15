// Decompiled with JetBrains decompiler
// Type: LOB.Model.Composite.ReadBI
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Model;
using CETAP_LOB.Model.Composite;
using ClosedXML.Excel;
using CETAP_LOB.Helper;
using System;
using System.Collections.Generic;

namespace CETAP_LOB.Model.Composite
{
  public class ReadBI
  {
    private string _filename = "";
    private List<BI> Allbi = new List<BI>();
    public IDataService _service;

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

    public List<BI> BiDetails
    {
      get
      {
        return this.Allbi;
      }
      set
      {
        this.Allbi = value;
      }
    }

    public ReadBI(string File)
    {
      this._filename = File;
      this.ReadExcelFile();
    }

    private async void ReadExcelFile()
    {
      IXLWorksheet xlWorksheet = new XLWorkbook(this._filename).Worksheet(1);
      xlWorksheet.FirstRowUsed();
      IXLTable xlTable = xlWorksheet.Range(xlWorksheet.FirstCellUsed().Address, xlWorksheet.LastCellUsed().Address).AsTable();
      int num = 0;
      foreach (IXLTableRow row in (IEnumerable<IXLTableRow>) xlTable.DataRange.Rows((Func<IXLTableRow, bool>) null))
      {
        if (row.Field("Employee Id").IsEmpty())
          break;
        BI bi = new BI();
        bi.NBT = Convert.ToInt64(row.Field("NBT Registration Number").GetString());
        bi.Surname = row.Field("Last Name").GetString();
        bi.Name = row.Field("First Name").GetString();
        if (!row.Field("Id Number").IsEmpty())
          bi.SAID = row.Field("Id Number").GetString();
        if (!row.Field("Birth Date").IsEmpty())
          bi.DOB = HelperUtils.BIDate(row.Field("Birth Date").GetString().Trim());
        if (!row.Field("NBT Exam Date").IsEmpty())
          bi.DOT = HelperUtils.BioDate(row.Field("NBT Exam Date").GetString().Trim());
        ++num;
        this.Allbi.Add(bi);
      }
    }
  }
}
