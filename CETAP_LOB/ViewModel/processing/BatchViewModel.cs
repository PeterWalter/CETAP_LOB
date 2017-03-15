// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.processing.BatchViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FeserWard.Controls;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CETAP_LOB.BDO;
using CETAP_LOB.Helper;
using CETAP_LOB.Model;
using CETAP_LOB.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace CETAP_LOB.ViewModel.processing
{
  public class BatchViewModel : ViewModelBase
  {
    private string _mystatus = "";
    public const string PeriodsPropertyName = "Periods";
    public const string IntakeRecordPropertyName = "IntakeRecord";
    public const string TestsPropertyName = "Tests";
    public const string AQLEPropertyName = "AQLE";
    public const string AQLAPropertyName = "AQLA";
    public const string MATAPropertyName = "MATA";
    public const string MATEPropertyName = "MATE";
    public const string WrittenTestPropertyName = "WrittenTest";
    public const string BatchMakersPropertyName = "BatchMakers";
    public const string SelectedBatcherPropertyName = "SelectedBatcher";
    public const string BatchNamePropertyName = "BatchName";
    public const string StampNoPropertyName = "StampNo";
    public const string ClientTypePropertyName = "ClientType";
    public const string SelectedProfilePropertyName = "SelectedProfile";
    public const string ProfilesAllocationsPropertyName = "ProfilesAllocations";
    public const string TestDatePropertyName = "TestDate";
    public const string VenuePropertyName = "Venue";
    public const string SelectedVenuePropertyName = "SelectedVenue";
    public const string NoInBatchPropertyName = "NoInBatch";
    public const string StatusPropertyName = "Status";
    public const string BatchPropertyName = "Batch";
    public const string SelectedBatchPropertyName = "SelectedBatch";
    public const string BatchesPropertyName = "Batches";
    public const string BatchesByPersonPropertyName = "BatchesByPerson";
    private bool isVenue;
    private bool isTestComb;
    private List<IntakeYearsBDO> _myPeriods;
    private IntakeYearsBDO _intakerecord;
    private List<TestBDO> _mytests;
    private TestBDO _myAQLE;
    private TestBDO _myAQLA;
    private TestBDO _myMATA;
    private TestBDO _myMATE;
    private string _myWrittenTest;
    private List<UserBDO> _myUsers;
    private UserBDO _mybatcher;
    private string _mybatch;
    private string _myStamp;
    private string _clientType;
    private ProfileAllocationBDO _myProfile;
    private ObservableCollection<ProfileAllocationBDO> _myProfAllocs;
    private DateTime _myTestDate;
    private VenueBDO _myVenue;
    private VenueBDO _selectedVenue;
    private int _BatchCount;
    private BatchBDO _batch;
    private BatchBDO _selectedBatch;
    private ObservableCollection<BatchBDO> _batches;
    private ObservableCollection<BatchBDO> _mypersonBatches;
    private IDataService _service;

    public RelayCommand SaveBatchCommand { get; private set; }

    public RelayCommand DeleteBatchCommand { get; private set; }

    public RelayCommand UpdateBatchCommand { get; private set; }

    public RelayCommand RestoreCommand { get; private set; }

    public IIntelliboxResultsProvider BatchProvider { get; private set; }

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

    public List<TestBDO> Tests
    {
      get
      {
        return this._mytests;
      }
      set
      {
        if (this._mytests == value)
          return;
        this._mytests = value;
        this.RaisePropertyChanged("Tests");
      }
    }

    public TestBDO AQLE
    {
      get
      {
        return this._myAQLE;
      }
      set
      {
        if (this._myAQLE == value)
          return;
        this._myAQLE = value;
        this.RaisePropertyChanged("AQLE");
      }
    }

    public TestBDO AQLA
    {
      get
      {
        return this._myAQLA;
      }
      set
      {
        if (this._myAQLA == value)
          return;
        this._myAQLA = value;
        this.RaisePropertyChanged("AQLA");
      }
    }

    public TestBDO MATA
    {
      get
      {
        return this._myMATA;
      }
      set
      {
        if (this._myMATA == value)
          return;
        this._myMATA = value;
        this.RaisePropertyChanged("MATA");
      }
    }

    public TestBDO MATE
    {
      get
      {
        return this._myMATE;
      }
      set
      {
        if (this._myMATE == value)
          return;
        this._myMATE = value;
        this.RaisePropertyChanged("MATE");
      }
    }

    public string WrittenTest
    {
      get
      {
        return this._myWrittenTest;
      }
      set
      {
        if (this._myWrittenTest == value)
          return;
        this._myWrittenTest = value;
        this.RaisePropertyChanged("WrittenTest");
      }
    }

    public List<UserBDO> BatchMakers
    {
      get
      {
        return this._myUsers;
      }
      set
      {
        if (this._myUsers == value)
          return;
        this._myUsers = value;
        this.RaisePropertyChanged("BatchMakers");
      }
    }

    public UserBDO SelectedBatcher
    {
      get
      {
        return this._mybatcher;
      }
      set
      {
        if (this._mybatcher == value)
          return;
        this._mybatcher = value;
        if (this._mybatcher != null)
        {
          if (this.Batch != null)
            this.Batch.BatchedBy = this._mybatcher.Name.Trim();
          this.getBatchesbyPerson();
        }
        this.RaisePropertyChanged("SelectedBatcher");
        this.SaveBatchCommand.RaiseCanExecuteChanged();
      }
    }

    public string BatchName
    {
      get
      {
        return this._mybatch;
      }
      set
      {
        if (this._mybatch == value)
          return;
        this._mybatch = value;
        if (!string.IsNullOrWhiteSpace(this._mybatch) && this._mybatch.Length == 22)
          this.GetBatchProperties();
        this.RaisePropertyChanged("BatchName");
      }
    }

    public string StampNo
    {
      get
      {
        return this._myStamp;
      }
      set
      {
        if (this._myStamp == value)
          return;
        this._myStamp = value;
        this.RaisePropertyChanged("StampNo");
      }
    }

    public string ClientType
    {
      get
      {
        return this._clientType;
      }
      set
      {
        if (this._clientType == value)
          return;
        this._clientType = value;
        this.RaisePropertyChanged("ClientType");
      }
    }

    public ProfileAllocationBDO SelectedProfile
    {
      get
      {
        return this._myProfile;
      }
      set
      {
        if (this._myProfile == value)
          return;
        this._myProfile = value;
        this.RaisePropertyChanged("SelectedProfile");
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

    public DateTime TestDate
    {
      get
      {
        return this._myTestDate;
      }
      set
      {
        if (this._myTestDate == value)
          return;
        this._myTestDate = value;
        this.GetProfileAllocations();
        if (this._myTestDate < DateTime.Today)
          this.SaveBatchCommand.RaiseCanExecuteChanged();
        this.RaisePropertyChanged("TestDate");
      }
    }

    public VenueBDO Venue
    {
      get
      {
        return this._myVenue;
      }
      set
      {
        if (this._myVenue == value)
          return;
        this._myVenue = value;
        this.RaisePropertyChanged("Venue");
        this.SaveBatchCommand.RaiseCanExecuteChanged();
      }
    }

    public VenueBDO SelectedVenue
    {
      get
      {
        return this._selectedVenue;
      }
      set
      {
        if (this._selectedVenue == value)
          return;
        this._selectedVenue = value;
        this.RaisePropertyChanged("SelectedVenue");
      }
    }

    public int NoInBatch
    {
      get
      {
        return this._BatchCount;
      }
      set
      {
        if (this._BatchCount == value)
          return;
        this._BatchCount = value;
        this.RaisePropertyChanged("NoInBatch");
      }
    }

    public string Status
    {
      get
      {
        return this._mystatus;
      }
      set
      {
        if (this._mystatus == value)
          return;
        this._mystatus = value;
        this.RaisePropertyChanged("Status");
      }
    }

    public BatchBDO Batch
    {
      get
      {
        return this._batch;
      }
      set
      {
        if (this._batch == value)
          return;
        this._batch = value;
        this.RaisePropertyChanged("Batch");
      }
    }

    public BatchBDO SelectedBatch
    {
      get
      {
        return this._selectedBatch;
      }
      set
      {
        if (this._selectedBatch == value)
          return;
        this._selectedBatch = value;
        this.RaisePropertyChanged("SelectedBatch");
        this.RestoreCommand.RaiseCanExecuteChanged();
      }
    }

    public ObservableCollection<BatchBDO> Batches
    {
      get
      {
        return this._batches;
      }
      set
      {
        if (this._batches == value)
          return;
        this._batches = value;
        this.RaisePropertyChanged("Batches");
      }
    }

    public ObservableCollection<BatchBDO> BatchesByPerson
    {
      get
      {
        return this._mypersonBatches;
      }
      set
      {
        if (this._mypersonBatches == value)
          return;
        this._mypersonBatches = value;
        this.RaisePropertyChanged("BatchesByPerson");
      }
    }

    public BatchViewModel(IDataService Service)
    {
      this._service = Service;
      this.TestDate = new DateTime();
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      this.BatchProvider = (IIntelliboxResultsProvider) new BatchResultsProvider(this._service);
      List<UserBDO> userBdoList = new List<UserBDO>();
      this.BatchMakers = this._service.GetAllUsers().Where<UserBDO>((Func<UserBDO, bool>) (a => a.Areas.StartsWith("1"))).OrderBy<UserBDO, string>((Func<UserBDO, string>) (c => c.Name)).Select<UserBDO, UserBDO>((Func<UserBDO, UserBDO>) (a => a)).ToList<UserBDO>();
      this._myPeriods = this._service.GetAllIntakeYears();
      this._intakerecord = this._myPeriods.Where<IntakeYearsBDO>((Func<IntakeYearsBDO, bool>) (x => x.Year == ApplicationSettings.Default.IntakeYear)).FirstOrDefault<IntakeYearsBDO>();
      this.TestDate = DateTime.Now;
      this.BatchesByPerson = (ObservableCollection<BatchBDO>) null;
      this.RefreshData();
    }

    private void RegisterCommands()
    {
      this.SaveBatchCommand = new RelayCommand((Action) (() => this.SaveBatch()), (Func<bool>) (() => this.canSaveBatch()));
      this.UpdateBatchCommand = new RelayCommand((Action) (() => this.UpdateBatch()));
      this.DeleteBatchCommand = new RelayCommand((Action) (() => this.DeleteBatch()));
      this.RestoreCommand = new RelayCommand((Action) (() => this.RestoreFile()), (Func<bool>) (() => this.canRestore()));
    }

    private void RestoreFile()
    {
      string batchName = this.SelectedBatch.BatchName;
      ScannedFileBDO scannedFileBdo = new ScannedFileBDO();
      ScannedFileBDO scannedFile = this._service.GetScannedFile(batchName);
      if (scannedFile != null)
      {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.SelectedPath = ApplicationSettings.Default.ScoreFolder;
        DialogResult dialogResult = folderBrowserDialog.ShowDialog();
        string path2 = batchName + ".dat";
        if (dialogResult == DialogResult.OK)
          File.WriteAllBytes(Path.Combine(folderBrowserDialog.SelectedPath, path2), scannedFile.FileData);
        int num = (int) ModernDialog.ShowMessage(path2 + " has been downloaded", "Scanned Files", MessageBoxButton.OK, (Window) null);
      }
      else
      {
        int num1 = (int) ModernDialog.ShowMessage("No scanned file with name " + batchName + " has been Scanned", "Scanned Files", MessageBoxButton.OK, (Window) null);
      }
    }

    private bool canRestore()
    {
      bool flag = false;
      if (this.SelectedBatch != null)
        flag = true;
      return flag;
    }

    private void DeleteBatch()
    {
      string message = "";
      if (ModernDialog.ShowMessage("Are you sure !!! \n \n You want to delete batch " + this.SelectedBatch.BatchName.ToString(), "Delete Record", MessageBoxButton.YesNo, (Window) null) != MessageBoxResult.Yes)
        return;
      this._service.deleteBatch(this.SelectedBatch, ref message);
      int num = (int) ModernDialog.ShowMessage(message, "Delete Record", MessageBoxButton.OK, (Window) null);
    }

    private void getBatchesbyPerson()
    {
      if (this.SelectedBatcher == null)
        return;
      this.BatchesByPerson = new ObservableCollection<BatchBDO>(this.Batches.Where<BatchBDO>((Func<BatchBDO, bool>) (b => b.BatchedBy.Trim() == this.SelectedBatcher.Name.Trim())).OrderByDescending<BatchBDO, DateTime>((Func<BatchBDO, DateTime>) (x => x.BatchDate)).Select<BatchBDO, BatchBDO>((Func<BatchBDO, BatchBDO>) (x => x)).ToList<BatchBDO>());
    }

    private void UpdateBatch()
    {
      string message = "";
      string text = "Record " + this.SelectedBatch.BatchName.ToString() + " has been updated";
      if (this._service.updatebatch(this.SelectedBatch, ref message))
      {
        int num = (int) ModernDialog.ShowMessage(text, "Update Record", MessageBoxButton.OK, (Window) null);
        this.RefreshData();
        this.getBatchesbyPerson();
      }
      else
      {
        int num1 = (int) ModernDialog.ShowMessage(message, "Update Record", MessageBoxButton.OK, (Window) null);
      }
    }

    private void SaveBatch()
    {
      string message = "";
      this.Batch.TestDate = this.TestDate;
      this.Batch.BatchedBy = this.SelectedBatcher.Name.Trim();
      this.Batch.BatchID = -1;
      if (this._service.addBatch(this.Batch, ref message))
      {
        int num = (int) ModernDialog.ShowMessage(message, "Save Batch", MessageBoxButton.OK, (Window) null);
        this.RefreshData();
        this.getBatchesbyPerson();
      }
      else
      {
        int num1 = (int) ModernDialog.ShowMessage(message, "Save Batch", MessageBoxButton.OK, (Window) null);
      }
    }

    private bool canSaveBatch()
    {
      bool flag = false;
      if (this.Batch != null && this.SelectedBatcher != null && (this.TestDate < DateTime.Today && this.isVenue) && this.isTestComb)
        flag = true;
      return flag;
    }

    private void GetProfileAllocations()
    {
      this.ProfilesAllocations = new ObservableCollection<ProfileAllocationBDO>(this._service.GetProfileAllocationsByDate(this.TestDate));
    }

    private bool canCreateBatch()
    {
      if (this.SelectedVenue != null)
        return this.NoInBatch != 0;
      return false;
    }

    private bool canEditBatch()
    {
      return this.SelectedBatch != null;
    }

    private void RefreshData()
    {
      this.Batches = new ObservableCollection<BatchBDO>(this._service.GetAllbatches().Where<BatchBDO>((Func<BatchBDO, bool>) (x =>
      {
        if (x.TestDate > this._intakerecord.yearStart)
          return x.TestDate < this._intakerecord.yearEnd;
        return false;
      })).OrderBy<BatchBDO, string>((Func<BatchBDO, string>) (b => b.BatchName)).Select<BatchBDO, BatchBDO>((Func<BatchBDO, BatchBDO>) (x => x)).ToList<BatchBDO>());
      this.BatchName = "";
      this.NoInBatch = 0;
      this.StampNo = "";
      this.WrittenTest = "";
      this.SelectedBatcher = (UserBDO) null;
      this.SelectedBatch = (BatchBDO) null;
      this.Tests = (List<TestBDO>) null;
      this.Venue = (VenueBDO) null;
    }

    private void GetBatchProperties()
    {
      if (ApplicationSettings.Default.DBAvailable)
      {
        datFileAttributes datFileAttributes = new datFileAttributes();
        datFileAttributes.SName = this.BatchName;
        this.Batch = new BatchBDO();
        this.NoInBatch = datFileAttributes.RecordCount;
        this.ClientType = datFileAttributes.Client;
        this.StampNo = datFileAttributes.RandNumber.ToString("D5");
        BatchViewModel.datFileAttributesToBatch(datFileAttributes, this.Batch);
        this.Batch.TestDate = this.TestDate;
        this.Tests = new List<TestBDO>();
        this.Tests = this._service.GetTestFromDatFile(datFileAttributes, this._intakerecord);
        this.WrittenTest = " ";
        if (datFileAttributes.Client != "Walk-in Bio")
        {
          string text = "";
          this.isTestComb = true;
          foreach (TestBDO test in this.Tests)
          {
            string str1 = test.TestName.Substring(0, 4);
            switch (datFileAttributes.TestCode)
            {
              case "0105":
                if (str1 == "AQLE")
                {
                  this.AQLE = test;
                  this.WrittenTest = this.AQLE.TestName;
                  continue;
                }
                continue;
              case "0115":
                if (str1 == "AQLA")
                {
                  this.AQLA = test;
                  this.WrittenTest = this.AQLA.TestName;
                  continue;
                }
                continue;
              case "0106":
                if (str1 == "MATE")
                  this.MATE = test;
                this.WrittenTest = this.MATE.TestName;
                continue;
              case "0116":
                if (str1 == "MATA")
                {
                  this.MATA = test;
                  this.WrittenTest = this.MATA.TestName;
                  continue;
                }
                continue;
              case "0107":
                if (str1 == "AQLE")
                {
                  this.AQLE = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.AQLE.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                }
                if (str1 == "MATE")
                {
                  this.MATE = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.MATE.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                  continue;
                }
                continue;
              case "0117":
                if (str1 == "AQLA")
                {
                  this.AQLA = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.AQLA.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                }
                if (str1 == "MATA")
                {
                  this.MATA = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.MATA.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                  continue;
                }
                continue;
              case "0127":
                if (str1 == "AQLE")
                {
                  this.AQLE = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.AQLE.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                }
                if (str1 == "MATA")
                {
                  this.MATA = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.MATA.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                  continue;
                }
                continue;
              case "0137":
                if (str1 == "AQLA")
                {
                  this.AQLA = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.AQLA.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                }
                if (str1 == "MATE")
                {
                  this.MATE = test;
                  BatchViewModel batchViewModel = this;
                  string str2 = batchViewModel.WrittenTest + this.MATE.TestName + "    ";
                  batchViewModel.WrittenTest = str2;
                  continue;
                }
                continue;
              default:
                text = "No such test Combination!!!";
                this.isTestComb = false;
                continue;
            }
          }
          if (!string.IsNullOrWhiteSpace(text))
          {
            int num = (int) ModernDialog.ShowMessage(text, "Batch Name", MessageBoxButton.OK, (Window) null);
          }
        }
        this.isVenue = true;
        this.Venue = this._service.GetTestVenue(datFileAttributes.VenueCode);
        if (this.Venue != null)
          return;
        this.isVenue = false;
        int num1 = (int) ModernDialog.ShowMessage("Cannot find Venue!!!", "Venue Name", MessageBoxButton.OK, (Window) null);
      }
      else
      {
        int num2 = (int) ModernDialog.ShowMessage("Cannot connect to Server for Database!!!", "Batching", MessageBoxButton.OK, (Window) null);
      }
    }

    private static void datFileAttributesToBatch(datFileAttributes datfileAttrib, BatchBDO batch)
    {
      batch.Count = datfileAttrib.RecordCount;
      batch.BatchName = datfileAttrib.SName;
      batch.TestProfileID = datfileAttrib.Profile;
      batch.TestCombination = datfileAttrib.TestCode;
      batch.TestVenueID = datfileAttrib.VenueCode;
      batch.RandomTestNumber = datfileAttrib.RandNumber;
    }
  }
}
