// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.writers.ProcessViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using ClosedXML.Excel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CETAP_LOB.BDO;
using CETAP_LOB.Helper;
using CETAP_LOB.Model;
using CETAP_LOB.Model.venueprep;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace LOB.ViewModel.writers
{
  public class ProcessViewModel : ViewModelBase
  {
    public const string NBTDOTPropertyName = "NBTDOT";
    public const string CollectionPropertyName = "Collection";
    public const string SelectedProfilePropertyName = "SelectedProfile";
    public const string ProfilesAllocationsPropertyName = "ProfilesAllocations";
    public const string SummaryPropertyName = "Summary";
    public const string VenuePropertyName = "Venue";
    private string testDate;
    private DateTime _myNBTdate;
    private ListCollectionView _collection;
    private IDataService _service;
    private int AQLE_Code;
    private int MATE_Code;
    private int AQLA_Code;
    private int MATA_Code;
    private TestBDO UsedTest;
    private ProfileAllocationBDO _selectedProfile;
    private ObservableCollection<ProfileAllocationBDO> _myProfAllocs;
    private ObservableCollection<VenueSummary> _mysummary;
    private ObservableCollection<ProcessList> _venue;

    public RelayCommand SaveToExcelCommand { get; private set; }

    public RelayCommand PackingListToExcelCommand { get; private set; }

    public DateTime NBTDOT
    {
      get
      {
        return this._myNBTdate;
      }
      set
      {
        if (this._myNBTdate == value)
          return;
        this._myNBTdate = value;
        this.RaisePropertyChanged("NBTDOT");
      }
    }

    public ListCollectionView Collection
    {
      get
      {
        return this._collection;
      }
      set
      {
        if (this._collection == value)
          return;
        this._collection = value;
        this.RaisePropertyChanged("Collection");
      }
    }

    public ProfileAllocationBDO SelectedProfile
    {
      get
      {
        return this._selectedProfile;
      }
      set
      {
        if (this._selectedProfile == value)
          return;
        this._selectedProfile = value;
        this.RaisePropertyChanged("SelectedProfile");
        this.PackingListToExcelCommand.RaiseCanExecuteChanged();
        if (this._selectedProfile == null)
          return;
        this.GetTestCodes();
      }
    }

    public ObservableCollection<ProfileAllocationBDO> ProfilesAllocations
    {
      get
      {
        return this._myProfAllocs;
      }
      set
      {
        if (this._myProfAllocs == value)
          return;
        this._myProfAllocs = value;
        this.RaisePropertyChanged("ProfilesAllocations");
      }
    }

    public ObservableCollection<VenueSummary> Summary
    {
      get
      {
        return this._mysummary;
      }
      set
      {
        if (this._mysummary == value)
          return;
        this._mysummary = value;
        this.RaisePropertyChanged("Summary");
      }
    }

    public ObservableCollection<ProcessList> Venue
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

    public ProcessViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
      this.LoadData();
    }

    private void InitializeModels()
    {
      this.Venue = new ObservableCollection<ProcessList>();
      this.Summary = new ObservableCollection<VenueSummary>();
    }

    private void RegisterCommands()
    {
      this.SaveToExcelCommand = new RelayCommand(new Action(this.SaveListToExcel));
      this.PackingListToExcelCommand = new RelayCommand((Action) (() => this.PackingList()), (Func<bool>) (() => this.CanSave()));
    }

    private bool CanSave()
    {
      return this.SelectedProfile != null;
    }

    private void GetTestCodes()
    {
      this.UsedTest = this._service.getTestByName(this._selectedProfile.AQLE);
      this.AQLE_Code = this.UsedTest.TestCode;
      this.UsedTest = this._service.getTestByName(this._selectedProfile.MATE);
      this.MATE_Code = this.UsedTest.TestCode;
    }

    private void LoadData()
    {
      List<VenueBDO> allvenues = this._service.GetAllvenues();
      ObservableCollection<WebWriters> observableCollection = this._service.Processdata();
      this.NBTDOT = observableCollection.Select<WebWriters, DateTime>((Func<WebWriters, DateTime>) (x => x.DOT)).FirstOrDefault<DateTime>();
      this.ProfilesAllocations = new ObservableCollection<ProfileAllocationBDO>(this._service.GetProfileAllocationsByDate(this.NBTDOT));
      List<\u003C\u003Ef__AnonymousType1c<string, string, int, string, string, string, string, double, string, string, string, string, DateTime, DateTime, DateTime, int>> list = observableCollection.Join((IEnumerable<VenueBDO>) allvenues, (Func<WebWriters, string>) (ss => ss.Venue.Trim()), (Func<VenueBDO, string>) (x => x.WebSiteName), (ss, x) => new
      {
        ss = ss,
        x = x
      }).OrderBy(param0 => param0.ss.Venue).ThenBy(param0 => param0.ss.Language).ThenByDescending(param0 => param0.ss.Tests).ThenBy(param0 => param0.ss.Surname).ThenBy(param0 => param0.ss.FirstName).Select(param0 => new
      {
        Surname = param0.ss.Surname.ToUpper(),
        Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(param0.ss.FirstName.ToLower()),
        Regno = 0,
        NBT = param0.ss.Reference,
        ID = param0.ss.SAID.Trim() != "" ? param0.ss.SAID : param0.ss.ForeignID,
        AQL = param0.ss.Language == "English" ? "E" : "A",
        Maths = param0.ss.Tests == "AQL" ? "" : (param0.ss.Language == "English" ? "E" : "A"),
        Paid = param0.ss.Paid,
        Venue = param0.ss.Venue != "" ? param0.x.ShortName : "Unknown Venue",
        Home = param0.ss.HTelephone,
        Mobile = param0.ss.Mobile,
        EMail = param0.ss.Email,
        DOT = param0.ss.DOT,
        RegDate = param0.ss.RegDate,
        CreationDate = param0.ss.CreationDate,
        VenueCode = param0.x.VenueCode
      }).ToList();
      int num = 1;
      string str = "";
      foreach (var data in list)
      {
        ProcessList processList = new ProcessList();
        processList.AQL = data.AQL;
        processList.ID = data.ID;
        processList.NBT = data.NBT;
        processList.Maths = data.Maths;
        processList.Name = data.Name;
        processList.Surname = data.Surname;
        processList.Venue = data.Venue;
        processList.Paid = data.Paid;
        if (str != data.Venue)
          num = 1;
        processList.RegNo = num;
        processList.FullName = data.Surname + ", " + data.Name;
        processList.Home = data.Home;
        processList.Mobile = data.Mobile;
        processList.DOT = data.DOT;
        processList.EMail = data.EMail;
        processList.creationDate = data.CreationDate;
        processList.regDate = data.RegDate;
        this.Venue.Add(processList);
        str = data.Venue;
        ++num;
      }
      foreach (var data1 in list.OrderBy(x => x.Venue).GroupBy(x => x.Venue).Select(venueGroups => new
      {
        TestVenue = venueGroups.Key,
        Writers = venueGroups.Count(),
        AQL = venueGroups.Where(Vg => Vg.AQL != "").GroupBy(Vg => Vg.AQL).Select(AQLGroups => new
        {
          Language = AQLGroups.Key,
          AQLCount = AQLGroups.Count()
        }),
        Maths = venueGroups.Where(mt => mt.Maths != "").GroupBy(mt => mt.Maths).Select(groupMaths => new
        {
          MathsLanguage = groupMaths.Key,
          Numbers = groupMaths.Count()
        }),
        VenueCode = venueGroups.GroupBy(vc => vc.VenueCode).Select(codes => new
        {
          vcode = codes.Key
        }),
        TestDate = venueGroups.GroupBy(vc => vc.DOT).Select(dates => new
        {
          DOT = dates.Key
        })
      }))
      {
        VenueSummary venueSummary = new VenueSummary();
        venueSummary.TotalWriters = data1.Writers;
        venueSummary.Venue = data1.TestVenue;
        foreach (var data2 in data1.AQL)
        {
          if (data2.Language == "E")
            venueSummary.AQL_E = data2.AQLCount;
          if (data2.Language == "A")
            venueSummary.AQL_A = data2.AQLCount;
        }
        foreach (var math in data1.Maths)
        {
          if (math.MathsLanguage == "E")
            venueSummary.Maths_E = math.Numbers;
          if (math.MathsLanguage == "A")
            venueSummary.Maths_A = math.Numbers;
        }
        foreach (var data2 in data1.VenueCode)
          venueSummary.CentreCode = data2.vcode;
        venueSummary.Walkin_E = HelperUtils.RoundUpWalkIn(venueSummary.AQL_E);
        venueSummary.Walkin_A = HelperUtils.RoundUpWalkIn(venueSummary.AQL_A);
        venueSummary.AQLE_S = HelperUtils.RoundAmount(venueSummary.AQL_E) + venueSummary.Walkin_E;
        venueSummary.AQLA_S = HelperUtils.RoundAmount(venueSummary.AQL_A) + venueSummary.Walkin_A;
        venueSummary.MATE_S = venueSummary.Maths_E > 0 ? HelperUtils.RoundAmount(venueSummary.Maths_E) + 10 : 0;
        venueSummary.MATA_S = venueSummary.Maths_A > 0 ? HelperUtils.RoundAmount(venueSummary.Maths_A) + 10 : 0;
        foreach (var data2 in data1.TestDate)
          venueSummary.TestDate = data2.DOT;
        if (venueSummary.Maths_E > 0 && venueSummary.Maths_E < 5)
          venueSummary.MATE_S = 10;
        if (venueSummary.AQL_E == 0)
        {
          venueSummary.Walkin_E = 0;
          venueSummary.AQLE_S = 0;
        }
        if (venueSummary.Maths_A > 0 && venueSummary.Maths_A < 5)
          venueSummary.MATA_S = 10;
        if (venueSummary.AQL_A == 0)
        {
          venueSummary.Walkin_A = 0;
          venueSummary.AQLA_S = 0;
        }
        if (venueSummary.AQL_A > 0 && venueSummary.AQL_A < 5)
          venueSummary.AQLA_S = 10;
        if (venueSummary.AQL_E > 0 && venueSummary.AQL_E < 5)
          venueSummary.AQLE_S = 10;
        venueSummary.AQLE_Batch = HelperUtils.YourChange(venueSummary.AQLE_S);
        venueSummary.AQLA_Batch = HelperUtils.YourChange(venueSummary.AQLA_S);
        venueSummary.MATE_Batch = HelperUtils.YourChange(venueSummary.MATE_S);
        venueSummary.MATA_Batch = HelperUtils.YourChange(venueSummary.MATA_S);
        venueSummary.TotalSent = venueSummary.AQLE_S + venueSummary.AQLA_S;
        this.Summary.Add(venueSummary);
      }
      this.Collection = new ListCollectionView((IList) this._venue);
      this.Collection.GroupDescriptions.Add((GroupDescription) new PropertyGroupDescription("Venue"));
    }

    private void SaveListToExcel()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = ".xlsx";
      saveFileDialog.Filter = "Excel FilesinFolder (*.xlsx)|*.xlsx|CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this.GenerateExcelWriters(saveFileDialog.FileName);
    }

    private void GenerateExcelWriters(string filename)
    {
      XLWorkbook xlWorkbook1 = new XLWorkbook();
      IEnumerable<ProcessList> processLists = this.Venue.GroupBy<ProcessList, string>((Func<ProcessList, string>) (i => i.Venue)).Select<IGrouping<string, ProcessList>, ProcessList>((Func<IGrouping<string, ProcessList>, ProcessList>) (group => group.First<ProcessList>()));
      int position = 1;
      foreach (ProcessList processList in processLists)
      {
        ProcessList rws = processList;
        try
        {
          string worksheetName = rws.Venue.ToString().Trim();
          if (worksheetName.Length > 30)
            worksheetName = worksheetName.Substring(0, 30);
          string sheetName = HelperUtils.RemoveWorksheetChars(worksheetName);
          string str = "NBT TEST - " + rws.DOT.Date.ToLongDateString() + Environment.NewLine;
          this.testDate = rws.DOT.Date.ToLongDateString();
          this.NBTDOT = rws.DOT;
          string text = str + " CHECK-IN SHEET : REGISTERED WRITERS " + Environment.NewLine + sheetName.ToUpper();
          if (text.Length > 120)
            text = text.Substring(0, 120);
          XLWorkbook xlWorkbook2 = new XLWorkbook();
          xlWorkbook1.Worksheets.Add(sheetName);
          IXLWorksheet xlWorksheet1 = xlWorkbook2.Worksheets.Add(sheetName);
          xlWorksheet1.PageSetup.Header.Center.Clear(XLHFOccurrence.AllPages);
          xlWorksheet1.PageSetup.Header.Center.AddText(text).SetBold();
          xlWorksheet1.PageSetup.PageOrientation = XLPageOrientation.Portrait;
          xlWorksheet1.PageSetup.AdjustTo(100);
          xlWorksheet1.PageSetup.PaperSize = XLPaperSize.A4Paper;
          xlWorksheet1.PageSetup.VerticalDpi = 600;
          xlWorksheet1.PageSetup.HorizontalDpi = 600;
          xlWorksheet1.PageSetup.PrintAreas.Add("A1:F31");
          xlWorksheet1.PageSetup.SetRowsToRepeatAtTop(1, 1);
          xlWorksheet1.PageSetup.Margins.Top = 1.0;
          xlWorksheet1.PageSetup.Margins.Bottom = 0.6;
          xlWorksheet1.PageSetup.Margins.Left = 0.2;
          xlWorksheet1.PageSetup.Margins.Right = 0.2;
          xlWorksheet1.PageSetup.Margins.Footer = 0.3;
          xlWorksheet1.PageSetup.Margins.Header = 0.3;
          xlWorksheet1.PageSetup.CenterHorizontally = true;
          xlWorksheet1.PageSetup.CenterVertically = true;
          xlWorksheet1.PageSetup.PageOrder = XLPageOrderValues.DownThenOver;
          xlWorksheet1.PageSetup.ShowGridlines = true;
          IXLWorksheet xlWorksheet2 = xlWorkbook1.Worksheet(position);
          IXLWorksheet xlWorksheet3 = xlWorkbook2.Worksheet(1);
          IEnumerable<\u003C\u003Ef__AnonymousType22<string, string, string, string, string, string, string, string, string, DateTime, string, string, string>> source = this.Venue.Where<ProcessList>((Func<ProcessList, bool>) (wsd => wsd.Venue == rws.Venue)).Select(wsd => new
          {
            Surname = wsd.Surname,
            Name = wsd.Name,
            Reg = wsd.RegNo.ToString("000"),
            FullName = wsd.FullName,
            ID = wsd.ID,
            AQL = wsd.AQL,
            Mat = wsd.Maths,
            Venue = wsd.Venue,
            NBT = wsd.NBT,
            DOT = wsd.DOT,
            Mobile = wsd.Mobile,
            Home = wsd.Home,
            email = wsd.EMail
          });
          int lastRow = source.Count() + 1;
          string rangeAddress = "A2:F" + (object) lastRow;
          IXLRow xlRow1 = xlWorksheet2.Row(1);
          xlRow1.Style.Font.Bold = true;
          xlRow1.Style.Font.FontSize = 12.0;
          xlWorksheet2.Cell(1, 1).Value = (object) "Surname";
          xlWorksheet2.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlWorksheet2.Cell(1, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
          xlWorksheet2.Cell(1, 2).Value = (object) "First Name";
          xlWorksheet2.Cell(1, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlWorksheet2.Cell(1, 3).Value = (object) "Reg #";
          xlWorksheet2.Cell(1, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlWorksheet2.Cell(1, 4).Value = (object) "FULL NAME";
          xlWorksheet2.Cell(1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlWorksheet2.Cell(1, 5).Value = (object) "ID";
          xlWorksheet2.Cell(1, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlWorksheet2.Cell(1, 6).Value = (object) "AQL";
          xlWorksheet2.Cell(1, 7).Value = (object) "MAT";
          xlWorksheet2.Cell(1, 8).Value = (object) "Venue";
          xlWorksheet2.Cell(1, 9).Value = (object) "Reference";
          xlWorksheet2.Cell(1, 10).Value = (object) "Date of Test";
          xlWorksheet2.Cell(1, 11).Value = (object) "Mobile";
          xlWorksheet2.Cell(1, 12).Value = (object) "Home";
          xlWorksheet2.Cell(1, 13).Value = (object) "EMail";
          xlWorksheet2.Cell(2, 1).InsertData((IEnumerable) source);
          IEnumerable<\u003C\u003Ef__AnonymousType23<string, string, string, string, string, string>> datas = this.Venue.Where<ProcessList>((Func<ProcessList, bool>) (wsd => wsd.Venue == rws.Venue)).Select(wsd => new
          {
            Reg = wsd.RegNo.ToString("000"),
            FullName = wsd.FullName,
            ID = wsd.ID,
            AQL = wsd.AQL,
            Mat = wsd.Maths,
            Signature = "         "
          });
          IXLColumn xlColumn1 = xlWorksheet3.Column("A");
          IXLColumn xlColumn2 = xlWorksheet3.Column("C");
          IXLColumn xlColumn3 = xlWorksheet3.Column("D");
          IXLColumn xlColumn4 = xlWorksheet3.Column("E");
          xlColumn1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlColumn2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
          xlColumn3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlColumn4.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          IXLRange xlRange1 = xlWorksheet3.Range("A1:F1");
          IXLRange xlRange2 = xlWorksheet3.Range(rangeAddress);
          xlRange1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
          xlRange1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
          xlRange1.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
          xlRange1.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
          xlRange2.Style.Font.FontSize = 10.0;
          xlRange2.Style.Font.FontName = "Calibri";
          xlRange2.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
          xlRange2.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
          xlRange2.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
          IXLRow xlRow2 = xlWorksheet3.Row(1);
          xlWorksheet3.Row(2);
          xlRow2.Style.Font.Bold = false;
          xlRow2.Style.Font.FontSize = 10.0;
          xlRow2.Style.Fill.BackgroundColor = XLColor.Cyan;
          xlRow2.Height = 29.5;
          xlWorksheet3.Rows(2, lastRow).Height = 24.0;
          xlWorksheet3.Rows(2, lastRow).Style.Font.FontSize = 10.0;
          xlWorksheet3.Column(1).Width = 5.0;
          xlWorksheet3.Column(2).Width = 30.0;
          xlWorksheet3.Column(3).Width = 16.0;
          xlWorksheet3.Column(4).Width = 4.9;
          xlWorksheet3.Column(5).Width = 4.9;
          xlWorksheet3.Column(6).Width = 30.0;
          xlWorksheet3.Cell(1, 1).Value = (object) "#";
          xlWorksheet3.Cell(1, 2).Value = (object) "Full Name";
          xlWorksheet3.Cell(1, 3).Value = (object) "ID #";
          xlWorksheet3.Cell(1, 4).Value = (object) "AQL";
          xlWorksheet3.Cell(1, 5).Value = (object) "MAT";
          xlWorksheet3.Cell(1, 6).Value = (object) "SIGN";
          xlWorksheet3.Cell(2, 1).InsertData((IEnumerable) datas);
          string file = Path.Combine(Path.GetDirectoryName(filename), rws.DOT.Date.ToLongDateString() + " " + sheetName + ".xlsx");
          xlWorkbook2.SaveAs(file);
          ++position;
        }
        catch (Exception ex)
        {
          throw;
        }
      }
      xlWorkbook1.SaveAs(filename);
      int num = (int) MessageBox.Show("All files saved");
    }

    private void PackingList()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = ".xlsx";
      saveFileDialog.Filter = "Excel FilesinFolder (*.xlsx)|*.xlsx|CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        this.GeneratePackingList(saveFileDialog.FileName);
      int num = (int) MessageBox.Show("All files saved");
    }

    private void GeneratePackingList(string FileName)
    {
      XLWorkbook xlWorkbook = new XLWorkbook("PackingList.xlsx");
      IXLWorksheet xlWorksheet1 = xlWorkbook.Worksheet(2);
      IEnumerable<\u003C\u003Ef__AnonymousType24<string, int, string, string, string, string, int, int, int, string, int, int, int, string, int, int, string, int, int, string, string, string, string, int, int>> source = this.Summary.Select(ss => new
      {
        VenueName = HelperUtils.RemoveWorksheetChars(ss.Venue),
        Total = ss.TotalWriters,
        CentreCode = ss.CentreCode.ToString("00000"),
        walkins = "",
        Booked = "",
        regNotOnlist = "",
        AQLE_Reg = ss.AQL_E,
        AQLE_Sent = ss.AQLE_S,
        E_Walkin = ss.Walkin_E,
        AQLEBatches = ss.AQLE_Batch,
        AQLA_Reg = ss.AQL_A,
        AQLa_Send = ss.AQLA_S,
        A_Walkin = ss.Walkin_A,
        AQLABatches = ss.AQLA_Batch,
        Mate_reg = ss.Maths_E,
        Mate_send = ss.MATE_S,
        Mate_Batch = ss.MATE_Batch,
        Mata_reg = ss.Maths_A,
        Mata_Send = ss.MATA_S,
        Mata_Batch = ss.MATA_Batch,
        Pencils = "",
        Erasers = "",
        Sharpeners = "",
        Totalsent = ss.TotalSent,
        TotalWriters = ss.TotalWriters
      });
      source.Count();
      xlWorksheet1.Cell("A1").Value = (object) this.testDate;
      xlWorksheet1.Cell(4, 1).InsertData((IEnumerable) source);
      int num = 2;
      foreach (var data in source)
      {
        ++num;
        string str = data.VenueName.Trim();
        if (data.VenueName.Length > 30)
          str = data.VenueName.Substring(0, 30);
        xlWorkbook.Worksheet(1).CopyTo(str);
        IXLWorksheet xlWorksheet2 = xlWorkbook.Worksheet(str);
        xlWorksheet2.Cell("B8").Value = (object) this.SelectedProfile.TestDate;
        xlWorksheet2.Cell("J1").Value = (object) this.SelectedProfile.Client.ToUpper();
        xlWorksheet2.Cell("C13").Value = (object) data.AQLEBatches;
        xlWorksheet2.Cell("C14").Value = (object) data.Mate_Batch;
        xlWorksheet2.Cell("C15").Value = (object) data.AQLABatches;
        xlWorksheet2.Cell("C16").Value = (object) data.Mata_Batch;
        xlWorksheet2.Cell("D13").Value = (object) data.AQLE_Sent;
        xlWorksheet2.Cell("D14").Value = (object) data.Mate_send;
        xlWorksheet2.Cell("D15").Value = (object) data.AQLa_Send;
        xlWorksheet2.Cell("D16").Value = (object) data.Mata_Send;
        xlWorksheet2.Cell("E8").Value = (object) data.CentreCode;
        xlWorksheet2.Cell("G2").Value = (object) str;
        xlWorksheet2.Cell("D17").Value = (object) data.TotalWriters;
        xlWorksheet2.Cell("D18").Value = (object) data.E_Walkin;
        xlWorksheet2.Cell("D19").Value = (object) data.A_Walkin;
        xlWorksheet2.Cell("O5").Value = (object) this.AQLE_Code;
        xlWorksheet2.Cell("O6").Value = (object) this.MATE_Code;
        xlWorksheet2.Cell("O7").Value = (object) this.AQLA_Code;
        xlWorksheet2.Cell("O8").Value = (object) this.MATA_Code;
        xlWorksheet2.Cell("B13").Value = (object) this.SelectedProfile.AQLE;
        xlWorksheet2.Cell("B14").Value = (object) this.SelectedProfile.MATE;
        xlWorksheet2.Cell("B15").Value = (object) this.SelectedProfile.AQLA;
        xlWorksheet2.Cell("B16").Value = (object) this.SelectedProfile.MATA;
        xlWorksheet2.Cell("H8").Value = (object) this.SelectedProfile.Profile;
      }
      xlWorkbook.CalculateMode = XLCalculateMode.Auto;
      xlWorkbook.SaveAs(FileName);
    }
  }
}
