// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.processing.ScanTrackerViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using ClosedXML.Excel;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CETAP_LOB.ViewModel.processing
{
  public class ScanTrackerViewModel : ViewModelBase
  {
    public const string PeriodsPropertyName = "Periods";
    public const string IntakeRecordPropertyName = "IntakeRecord";
    public const string TrackersPropertyName = "Trackers";
    private IDataService _service;
    private List<IntakeYearsBDO> _myPeriods;
    private IntakeYearsBDO _intakerecord;
    private ObservableCollection<ScanTrackerBDO> _mytrackers;

    public RelayCommand SavetoExcelCommand { get; private set; }

    public RelayCommand FolderBowserCommand { get; private set; }

    public List<IntakeYearsBDO> Periods
    {
      get
      {
        return this._myPeriods;
      }
      set
      {
        if (this._myPeriods == value)
          return;
        this._myPeriods = value;
        this.RaisePropertyChanged("Periods");
      }
    }

    public IntakeYearsBDO IntakeRecord
    {
      get
      {
        return this._intakerecord;
      }
      set
      {
        if (this._intakerecord == value)
          return;
        this._intakerecord = value;
        this.RaisePropertyChanged("IntakeRecord");
      }
    }

    public ObservableCollection<ScanTrackerBDO> Trackers
    {
      get
      {
        return this._mytrackers;
      }
      set
      {
        if (this._mytrackers == value)
          return;
        this._mytrackers = value;
        this.RaisePropertyChanged("Trackers");
      }
    }

    public ScanTrackerViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      List<ScanTrackerBDO> allTracks = this._service.GetAllTracks();
      this._myPeriods = this._service.GetAllIntakeYears();
      this._intakerecord = this._myPeriods.Where<IntakeYearsBDO>((Func<IntakeYearsBDO, bool>) (m => m.Year == ApplicationSettings.Default.IntakeYear)).FirstOrDefault<IntakeYearsBDO>();
      this.Trackers = new ObservableCollection<ScanTrackerBDO>((IEnumerable<ScanTrackerBDO>) allTracks.Where<ScanTrackerBDO>((Func<ScanTrackerBDO, bool>) (x =>
      {
        if (!x.FileName.Contains("BIO"))
        {
          DateTime? dateBatched1 = x.DateBatched;
          DateTime yearStart = this._intakerecord.yearStart;
          if ((dateBatched1.HasValue ? (dateBatched1.GetValueOrDefault() >= yearStart ? 1 : 0) : 0) != 0)
          {
            DateTime? dateBatched2 = x.DateBatched;
            DateTime yearEnd = this._intakerecord.yearEnd;
            if (!dateBatched2.HasValue)
              return false;
            return dateBatched2.GetValueOrDefault() <= yearEnd;
          }
        }
        return false;
      })).OrderByDescending<ScanTrackerBDO, DateTime?>((Func<ScanTrackerBDO, DateTime?>) (q => q.DateBatched)));
    }

    private void RegisterCommands()
    {
      this.SavetoExcelCommand = new RelayCommand(new Action(this.SaveToExcelFile));
    }

    private void SaveToExcelFile()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = ".xlsx";
      saveFileDialog.Filter = "Excel FilesinFolder (*.xlsx)|*.xlsx|CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this.GenerateExcelFile(saveFileDialog.FileName);
    }

    private void GenerateExcelFile(string filename)
    {
      XLWorkbook xlWorkbook = new XLWorkbook();
      IXLWorksheet xlWorksheet = xlWorkbook.Worksheets.Add("Scan Tracker");
      List<ScanTrackerBDO> list = this.Trackers.OrderByDescending<ScanTrackerBDO, DateTime?>((Func<ScanTrackerBDO, DateTime?>) (x => x.DateBatched)).ThenBy<ScanTrackerBDO, string>((Func<ScanTrackerBDO, string>) (v => v.BatchedBy)).Select<ScanTrackerBDO, ScanTrackerBDO>((Func<ScanTrackerBDO, ScanTrackerBDO>) (c => c)).ToList<ScanTrackerBDO>();
      IXLRow xlRow = xlWorksheet.Row(1);
      xlRow.Style.Font.Bold = true;
      xlRow.Style.Font.FontSize = 12.0;
      xlWorksheet.Cell(1, 1).Value = (object) "Batch ID";
      xlWorksheet.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
      xlWorksheet.Cell(1, 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
      xlWorksheet.Cell(1, 2).Value = (object) "Batch Name";
      xlWorksheet.Cell(1, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
      xlWorksheet.Cell(1, 3).Value = (object) "Batched By";
      xlWorksheet.Cell(1, 4).Value = (object) "Date Batched";
      xlWorksheet.Cell(1, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
      xlWorksheet.Cell(1, 5).Value = (object) "Counted Answer Sheets";
      xlWorksheet.Cell(1, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
      xlWorksheet.Cell(1, 6).Value = (object) "Scan Date";
      xlWorksheet.Cell(1, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
      xlWorksheet.Cell(1, 7).Value = (object) "Records Scanned";
      xlWorksheet.Cell(1, 8).Value = (object) "Date Edited";
      xlWorksheet.Cell(1, 9).Value = (object) "Edited Records";
      xlWorksheet.Cell(1, 10).Value = (object) "Date QA'ed";
      xlWorksheet.Cell(1, 11).Value = (object) "Records QA";
      xlWorksheet.Cell(1, 12).Value = (object) "Date sent for Scoring";
      xlWorksheet.Cell(1, 13).Value = (object) "Amount Scored";
      xlWorksheet.Cell(1, 14).Value = (object) "Date Scores compiled";
      xlWorksheet.Cell(1, 15).Value = (object) "Count Compiled";
      xlWorksheet.Cell(1, 16).Value = (object) "Test Date";
      xlWorksheet.Cell(1, 17).Value = (object) "Date File Modified";
      xlWorksheet.Cell(1, 18).Value = (object) "Row Version";
      xlWorksheet.Cell(2, 1).InsertData((IEnumerable) list);
      DateTime.Now.ToShortDateString();
      xlWorkbook.SaveAs(filename);
      int num = (int) ModernDialog.ShowMessage("Excel File has been saved to folder", "Save File!!", MessageBoxButton.OK, (Window) null);
    }
  }
}
