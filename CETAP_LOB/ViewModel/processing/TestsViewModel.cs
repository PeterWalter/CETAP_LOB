// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.processing.TestsViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using CETAP_LOB.Search;
using FeserWard.Controls;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;

namespace CETAP_LOB.ViewModel.processing
{
    public class TestsViewModel : ViewModelBase
  {
    public const string PeriodsPropertyName = "Periods";
    public const string IntakeRecordPropertyName = "IntakeRecord";
    public const string IntakeYearPropertyName = "IntakeYear";
    public const string GrpProfilesPropertyName = "GrpProfiles";
    public const string ProfilesAllocationsPropertyName = "ProfilesAllocations";
    public const string SelectedProfilePropertyName = "SelectedProfile";
    public const string ProfilesPropertyName = "Profiles";
    public const string SelectedProfNumberPropertyName = "SelectedProfNumber";
    public const string SelectedProfAllocPropertyName = "SelectedProfAlloc";
    public const string AllAllocationsPropertyName = "AllAllocations";
    public const string BStatusPropertyName = "BStatus";
    public const string AStatusPropertyName = "AStatus";
    public const string StatusPropertyName = "Status";
    public const string SelectedAllocationPropertyName = "SelectedAllocation";
    public const string SelectedTestPropertyName = "SelectedTest";
    public const string AllocationsPropertyName = "Allocations";
    public const string TestsPropertyName = "Tests";
    private List<IntakeYearsBDO> _myPeriods;
    private IntakeYearsBDO _intakerecord;
    private int _intakeyear;
    private ObservableCollection<TestProfileBDO> _mygrpProfiles;
    private ObservableCollection<ProfileAllocationBDO> _myProfAllocs;
    private TestProfileBDO _myProfile;
    private ObservableCollection<TestProfileBDO> _myProfiles;
    private int _myProfNumber;
    private TestAllocationBDO _myselectedProfAlloc;
    private ObservableCollection<TestAllocationBDO> _allAlloc;
    private string _myBstatus;
    private string _myAstatus;
    private string _status;
    private TestAllocationBDO _myselectedAllocation;
    private TestBDO _test;
    private ObservableCollection<TestAllocationBDO> _myallocations;
    private ObservableCollection<TestBDO> _tests;
    private IDataService _service;

    public IIntelliboxResultsProvider TestsProvider { get; private set; }

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
        this.IntakeYear = this._intakerecord.Year;
        this.RefreshAll();
        this.RaisePropertyChanged("IntakeRecord");
      }
    }

    public int IntakeYear
    {
      get
      {
        return this._intakeyear;
      }
      set
      {
        if (this._intakeyear == value)
          return;
        this._intakeyear = value;
        this.GetSelectedIntake();
        this.RaisePropertyChanged("IntakeYear");
      }
    }

    public ObservableCollection<TestProfileBDO> GrpProfiles
    {
      get
      {
        return this._mygrpProfiles;
      }
      set
      {
        if (this._mygrpProfiles == value)
          return;
        this._mygrpProfiles = value;
        this.RaisePropertyChanged("GrpProfiles");
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

    public TestProfileBDO SelectedProfile
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
        this.SaveAProfileCommand.RaiseCanExecuteChanged();
      }
    }

    public ObservableCollection<TestProfileBDO> Profiles
    {
      get
      {
        return this._myProfiles;
      }
      set
      {
        if (this._myProfiles == value)
          return;
        this._myProfiles = value;
        this.RaisePropertyChanged("Profiles");
      }
    }

    public int SelectedProfNumber
    {
      get
      {
        return this._myProfNumber;
      }
      set
      {
        if (this._myProfNumber == value)
          return;
        this._myProfNumber = value;
        this._myProfile.Profile = this._myProfNumber;
        this.RaisePropertyChanged("SelectedProfNumber");
        this.GetGroupProfiles();
      }
    }

    public TestAllocationBDO SelectedProfAlloc
    {
      get
      {
        return this._myselectedProfAlloc;
      }
      set
      {
        if (this._myselectedProfAlloc == value)
          return;
        this._myselectedProfAlloc = value;
        this.RaisePropertyChanged("SelectedProfAlloc");
      }
    }

    public ObservableCollection<TestAllocationBDO> AllAllocations
    {
      get
      {
        return this._allAlloc;
      }
      set
      {
        if (this._allAlloc == value)
          return;
        this._allAlloc = value;
        this.RaisePropertyChanged("AllAllocations");
      }
    }

    public string BStatus
    {
      get
      {
        return this._myBstatus;
      }
      set
      {
        if (this._myBstatus == value)
          return;
        this._myBstatus = value;
        this.RaisePropertyChanged("BStatus");
      }
    }

    public string AStatus
    {
      get
      {
        return this._myAstatus;
      }
      set
      {
        if (this._myAstatus == value)
          return;
        this._myAstatus = value;
        this.RaisePropertyChanged("AStatus");
      }
    }

    public string Status
    {
      get
      {
        return this._status;
      }
      set
      {
        if (this._status == value)
          return;
        this._status = value;
        this.RaisePropertyChanged("Status");
      }
    }

    public TestAllocationBDO SelectedAllocation
    {
      get
      {
        return this._myselectedAllocation;
      }
      set
      {
        if (this._myselectedAllocation == value)
          return;
        this._myselectedAllocation = value;
        this.RaisePropertyChanged("SelectedAllocation");
      }
    }

    public TestBDO SelectedTest
    {
      get
      {
        return this._test;
      }
      set
      {
        if (this._test == value)
          return;
        this._test = value;
        this.Status = "";
        if (this._test != null)
          this.getAllocationBytestID(this._test.TestID);
        this.RaisePropertyChanged("SelectedTest");
        this.DeleteTestCommand.RaiseCanExecuteChanged();
        this.SaveTestCommand.RaiseCanExecuteChanged();
        this.UpDateTestCommand.RaiseCanExecuteChanged();
      }
    }

    public ObservableCollection<TestAllocationBDO> Allocations
    {
      get
      {
        return this._myallocations;
      }
      set
      {
        if (this._myallocations == value)
          return;
        this._myallocations = value;
        this.RaisePropertyChanged("Allocations");
      }
    }

    public ObservableCollection<TestBDO> Tests
    {
      get
      {
        return this._tests;
      }
      set
      {
        if (this._tests == value)
          return;
        this._tests = value;
        this.RaisePropertyChanged("Tests");
      }
    }

    public RelayCommand AllocationProfileToExcelCommand { get; private set; }

    public RelayCommand AddTestCommand { get; private set; }

    public RelayCommand UpDateTestCommand { get; private set; }

    public RelayCommand DeleteTestCommand { get; private set; }

    public RelayCommand SaveTestCommand { get; private set; }

    public RelayCommand AllocateTestCommand { get; private set; }

    public RelayCommand SaveAllocationCommand { get; private set; }

    public RelayCommand UpdateAllocationCommand { get; private set; }

    public RelayCommand DeleteAllocationCommand { get; private set; }

    public RelayCommand SaveExcelAllocationsCommand { get; private set; }

    public RelayCommand NewProfileCommand { get; private set; }

    public RelayCommand SaveAProfileCommand { get; private set; }

    public RelayCommand UpdateProfileCommand { get; private set; }

    public RelayCommand DeleteProfileCommand { get; private set; }

    public TestsViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      this.Tests = new ObservableCollection<TestBDO>();
      this.TestsProvider = (IIntelliboxResultsProvider) new TestsResultsProvider(this._service);
      this.AllAllocations = new ObservableCollection<TestAllocationBDO>();
      if (!ApplicationSettings.Default.DBAvailable)
        return;
      this.RefreshTests();
      this._myPeriods = this._service.GetAllIntakeYears();
      this.IntakeYear = this._service.GetCurrentYear();
      this.GetProfiles();
      this.Refresh_alloc();
      this.Refresh_ProfAllocs();
    }

    private void RegisterCommands()
    {
      this.AddTestCommand = new RelayCommand((Action) (() => this.CreateTest()));
      this.UpDateTestCommand = new RelayCommand((Action) (() => this.UpdateTest()), (Func<bool>) (() => this.canSaveTest()));
      this.SaveTestCommand = new RelayCommand((Action) (() => this.SaveTest()), (Func<bool>) (() => this.canSaveTest()));
      this.DeleteTestCommand = new RelayCommand((Action) (() => this.DeleteTest()), (Func<bool>) (() => this.canDeleteTest()));
      this.AllocateTestCommand = new RelayCommand((Action) (() => this.AllocateTest()), (Func<bool>) (() => this.canAllocateTest()));
      this.SaveAllocationCommand = new RelayCommand((Action) (() => this.SaveAllocation()), (Func<bool>) (() => this.canSaveAllocation()));
      this.DeleteAllocationCommand = new RelayCommand((Action) (() => this.DeleteAllocation()), (Func<bool>) (() => this.canSaveAllocation()));
      this.UpdateAllocationCommand = new RelayCommand((Action) (() => this.UpdateAllocation()), (Func<bool>) (() => this.canSaveAllocation()));
      this.SaveExcelAllocationsCommand = new RelayCommand((Action) (() => this.SaveAllocationsToExcel()));
      this.AllocationProfileToExcelCommand = new RelayCommand((Action) (() => this.AllocationProfileToExcel()));
      this.NewProfileCommand = new RelayCommand((Action) (() => this.CreateProfile()));
      this.SaveAProfileCommand = new RelayCommand((Action) (() => this.SaveAProfile()), (Func<bool>) (() => this.canSaveProfile()));
      this.DeleteProfileCommand = new RelayCommand((Action) (() => this.DeletingProfile()));
    }

    private void SaveAllocationsToExcel()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Data files (*.dat)|*.dat|All files(*.*)|*.*";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      string title = "Test Allocations";
      if (!this._service.AllocationsToExcel(saveFileDialog.FileName))
        return;
      int num = (int) ModernDialog.ShowMessage("Allocation Data saved to excel file ", title, MessageBoxButton.OK, (Window) null);
    }

    private void Refresh_ProfAllocs()
    {
      this.ProfilesAllocations = new ObservableCollection<ProfileAllocationBDO>(this._service.GetAllProfileAllocations().Where<ProfileAllocationBDO>((Func<ProfileAllocationBDO, bool>) (x =>
      {
        if (x.TestDate > this.IntakeRecord.yearStart)
          return x.TestDate < this.IntakeRecord.yearEnd;
        return false;
      })).Select<ProfileAllocationBDO, ProfileAllocationBDO>((Func<ProfileAllocationBDO, ProfileAllocationBDO>) (m => m)).ToList<ProfileAllocationBDO>());
    }

    private void Refresh_alloc()
    {
      this.AllAllocations.Clear();
      IEnumerable<TestAllocationBDO> source = this._service.GetAllTestAllocations().Where<TestAllocationBDO>((Func<TestAllocationBDO, bool>) (x =>
      {
        if (x.TestDate > this.IntakeRecord.yearStart)
          return x.TestDate < this.IntakeRecord.yearEnd;
        return false;
      })).Select<TestAllocationBDO, TestAllocationBDO>((Func<TestAllocationBDO, TestAllocationBDO>) (m => m));
      List<TestProfileBDO> profs = this._service.GetAllTestProfiles();
      this.AllAllocations = new ObservableCollection<TestAllocationBDO>(source.Where<TestAllocationBDO>((Func<TestAllocationBDO, bool>) (i => !profs.Any<TestProfileBDO>((Func<TestProfileBDO, bool>) (e => e.AllocationID == i.ID)))).OrderBy<TestAllocationBDO, DateTime>((Func<TestAllocationBDO, DateTime>) (m => m.TestDate)).ToList<TestAllocationBDO>());
    }

    private void AllocationProfileToExcel()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx|Data files (*.dat)|*.dat|All files(*.*)|*.*";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this._service.SaveProfileAllocationsToExcel(saveFileDialog.FileName);
    }

    private void GetProfiles()
    {
      this.Profiles = new ObservableCollection<TestProfileBDO>(new ObservableCollection<TestProfileBDO>(this._service.GetAllTestProfiles()).Where<TestProfileBDO>((Func<TestProfileBDO, bool>) (x => x.Intake == this.IntakeYear)).Select<TestProfileBDO, TestProfileBDO>((Func<TestProfileBDO, TestProfileBDO>) (v => v)).ToList<TestProfileBDO>().GroupBy<TestProfileBDO, int>((Func<TestProfileBDO, int>) (e => e.Profile)).Select<IGrouping<int, TestProfileBDO>, TestProfileBDO>((Func<IGrouping<int, TestProfileBDO>, TestProfileBDO>) (gp => gp.First<TestProfileBDO>())).OrderBy<TestProfileBDO, int>((Func<TestProfileBDO, int>) (m => m.Profile)).ToList<TestProfileBDO>());
    }

    private void GetGroupProfiles()
    {
      this.GrpProfiles = new ObservableCollection<TestProfileBDO>(this._service.getTestprofileByProfile(this._myProfNumber));
    }

    private void SaveAProfile()
    {
      string message = "";
      this._service.addTestProfile(this.SelectedProfile, ref message);
      this.BStatus = message;
      this.Refresh_alloc();
      this.Refresh_ProfAllocs();
    }

    private void CreateProfile()
    {
      this.SelectedProfile = (TestProfileBDO) null;
      this._myProfile = new TestProfileBDO()
      {
        AllocationID = this.SelectedProfAlloc.ID
      };
      this._myProfile.Intake = this._intakeyear;
      this.SaveAProfileCommand.RaiseCanExecuteChanged();
    }

    private bool canSaveProfile()
    {
      bool flag = false;
      if (this.SelectedProfile != null)
        return true;
      return flag;
    }

    private void DeletingProfile()
    {
      string message = "";
      this._service.deleteTestProfile(this.SelectedProfile, ref message);
      this.Status = message;
    }

    private void SaveAllocation()
    {
      string message = "";
      this._service.addTestAllocation(this.SelectedAllocation, ref message);
      this.AStatus = message;
      this.getAllocationBytestID(this.SelectedTest.TestID);
      this.Refresh_alloc();
    }

    private bool canSaveAllocation()
    {
      if (this.SelectedAllocation != null && !string.IsNullOrWhiteSpace(this.SelectedAllocation.Client))
        return !string.IsNullOrWhiteSpace(this.SelectedAllocation.ClientType);
      return false;
    }

    private void DeleteAllocation()
    {
      if (this.SelectedAllocation == null)
        return;
      if (ModernDialog.ShowMessage("Do you really want to delete this Test Allocation?", "Test Name: " + this.SelectedTest.TestName.ToString(), MessageBoxButton.YesNo, (Window) null).ToString() == "Yes")
      {
        string message = "";
        this._service.deleteTestAllocation(this.SelectedAllocation, ref message);
        this.Status = message;
      }
      this.RefreshAllocations();
      this.Refresh_alloc();
      this.RefreshTests();
    }

    private void UpdateAllocation()
    {
      this.AStatus = "";
      string message = "";
      this._service.updateTestAllocation(this.SelectedAllocation, ref message);
      int num = (int) ModernDialog.ShowMessage(message, "Update", MessageBoxButton.OK, (Window) null);
      this.AStatus = message;
      this.getAllocationBytestID(this.SelectedTest.TestID);
      this.Refresh_alloc();
    }

    private void RefreshAllocations()
    {
      this.Allocations.Clear();
      this.Allocations = new ObservableCollection<TestAllocationBDO>(this._service.GetAllTestAllocations());
    }

    private void getAllocationBytestID(int testID)
    {
      this.Allocations = new ObservableCollection<TestAllocationBDO>(this._service.getTestAllocationByTestID(testID).Where<TestAllocationBDO>((Func<TestAllocationBDO, bool>) (x =>
      {
        if (x.TestDate > this.IntakeRecord.yearStart)
          return x.TestDate < this.IntakeRecord.yearEnd;
        return false;
      })).Select<TestAllocationBDO, TestAllocationBDO>((Func<TestAllocationBDO, TestAllocationBDO>) (m => m)).OrderBy<TestAllocationBDO, DateTime>((Func<TestAllocationBDO, DateTime>) (v => v.TestDate)).ToList<TestAllocationBDO>());
    }

    private void AllocateTest()
    {
      this.SelectedAllocation = new TestAllocationBDO()
      {
        TestID = this.SelectedTest.TestID
      };
      this.SelectedAllocation.TestDate = DateTime.Now;
    }

    private bool canAllocateTest()
    {
      if (this.SelectedTest != null && !string.IsNullOrWhiteSpace(this.SelectedTest.TestName))
        return this.SelectedTest.TestID > 0;
      return false;
    }

    private void DeleteTest()
    {
      if (this.SelectedTest == null)
        return;
      if (ModernDialog.ShowMessage("Do you really want to delete this Test?\n Tests affect other parts of the application \n and the NBT_Production Database ", "Test Name: " + this.SelectedTest.TestName.ToString(), MessageBoxButton.YesNo, (Window) null).ToString() == "Yes")
      {
        string message = "";
        this._service.deleteTest(this.SelectedTest, ref message);
        this.Status = message;
      }
      this.RefreshTests();
    }

    private void RefreshTests()
    {
      this.Tests.Clear();
      this.Tests = new ObservableCollection<TestBDO>((IEnumerable<TestBDO>) this._service.GetAllTests().OrderBy<TestBDO, string>((Func<TestBDO, string>) (t => t.TestName)));
    }

    private void UpdateTest()
    {
      this.Status = "";
      string message = "";
      this._service.updateTest(this.SelectedTest, ref message);
      int num = (int) ModernDialog.ShowMessage(message, "Update", MessageBoxButton.OK, (Window) null);
      this.Status = message;
      this.RefreshTests();
    }

    private void CreateTest()
    {
      this.SelectedTest = (TestBDO) null;
      this.SelectedTest = new TestBDO();
    }

    private void SaveTest()
    {
      string message = "";
      this._service.addTest(this.SelectedTest, ref message);
      this.Status = message;
      this.RefreshTests();
    }

    private bool canSaveTest()
    {
      if (this.SelectedTest != null)
        return !string.IsNullOrWhiteSpace(this.SelectedTest.TestName);
      return false;
    }

    private bool canDeleteTest()
    {
      if (this.SelectedTest != null)
        return !string.IsNullOrWhiteSpace(this.SelectedTest.TestName);
      return false;
    }

    private void GetSelectedIntake()
    {
      this.IntakeRecord = this._myPeriods.Where<IntakeYearsBDO>((Func<IntakeYearsBDO, bool>) (x => x.Year == this.IntakeYear)).Select<IntakeYearsBDO, IntakeYearsBDO>((Func<IntakeYearsBDO, IntakeYearsBDO>) (x => x)).FirstOrDefault<IntakeYearsBDO>();
    }

    private void RefreshAll()
    {
      this.Refresh_ProfAllocs();
      this.Refresh_alloc();
    }
  }
}
