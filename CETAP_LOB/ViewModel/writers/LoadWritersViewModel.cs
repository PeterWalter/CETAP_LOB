// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.writers.LoadWritersViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using CETAP_LOB.Model.venueprep;
using log4net;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CETAP_LOB.ViewModel.writers
{
  public class LoadWritersViewModel : ViewModelBase
  {
    private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private string _mystatus = "";
    public const string IsStartedPropertyName = "IsStarted";
    public const string isLoadedPropertyName = "isLoaded";
    public const string StatusPropertyName = "Status";
    public const string CleanDataPropertyName = "CleanData";
    public const string DBDuplicatesPropertyName = "DBDuplicates";
    public const string DuplicatesPropertyName = "Duplicates";
    public const string IsDirtyPropertyName = "IsDirty";
    public const string applicantsPropertyName = "applicants";
    public const string SelectedWriterPropertyName = "SelectedWriter";
    public const string AfrikaansPropertyName = "Afrikaans";
    public const string EnglishPropertyName = "English";
    public const string VenuesPropertyName = "Venues";
    public const string FemalePropertyName = "Female";
    public const string MalePropertyName = "Male";
    public const string CountPropertyName = "Count";
    public const string ErrorsPropertyName = "Errors";
    public const string writersPropertyName = "writers";
    public const string FileNamePropertyName = "FileName";
    public const string DBResultsPropertyName = "DBResults";
    public ObservableCollection<WritersBDO> myList;
    private IDataService _service;
    private bool _isStarted;
    private bool _isLoaded;
    private bool _mydata;
    private ObservableCollection<WebWriters> _myDBDuplicates;
    private ObservableCollection<WebWriters> _myduplicates;
    private bool _isDirty;
    private CollectionViewSource WebA;
    private WebWriters _selectedWriter;
    private int _afrikaans;
    private int _myenglish;
    private int _venues;
    private int _female;
    private int _male;
    private int _count;
    private ObservableCollection<string> _myProperty;
    private ObservableCollection<WebWriters> _writers;
    private string _filename;
    private List<string> _myDBResults;

    public RelayCommand OpenFileCommand { get; private set; }

    public RelayCommand RefreshCommand { get; private set; }

    public RelayCommand LoadwritersToDBCommand { get; private set; }

    public RelayCommand CreateFileCommand { get; private set; }

    public RelayCommand DeleteRowCommand { get; private set; }

    public RelayCommand CleanNamesCommand { get; private set; }

    public RelayCommand GetDBDuplicatesCommand { get; private set; }

    public RelayCommand GetNBTCommand { get; private set; }

    public RelayCommand<object> UpDateFilterCommand { get; private set; }

    public bool IsStarted
    {
      get
      {
        return this._isStarted;
      }
      set
      {
        if (this._isStarted == value)
          return;
        this._isStarted = value;
        this.RaisePropertyChanged("IsStarted");
      }
    }

    public bool isLoaded
    {
      get
      {
        return this._isLoaded;
      }
      set
      {
        if (this._isLoaded == value)
          return;
        this._isLoaded = value;
        this.RaisePropertyChanged("isLoaded");
        this.CreateFileCommand.RaiseCanExecuteChanged();
        this.RefreshCommand.RaiseCanExecuteChanged();
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
        this.LoadwritersToDBCommand.RaiseCanExecuteChanged();
      }
    }

    public bool CleanData
    {
      get
      {
        return this._mydata;
      }
      set
      {
        if (this._mydata == value)
          return;
        this._mydata = value;
        this.RaisePropertyChanged("CleanData");
        this.LoadwritersToDBCommand.RaiseCanExecuteChanged();
      }
    }

    public ObservableCollection<WebWriters> DBDuplicates
    {
      get
      {
        return this._myDBDuplicates;
      }
      set
      {
        if (this._myDBDuplicates == value)
          return;
        this._myDBDuplicates = value;
        this.RaisePropertyChanged("DBDuplicates");
      }
    }

    public ObservableCollection<WebWriters> Duplicates
    {
      get
      {
        return this._myduplicates;
      }
      set
      {
        if (this._myduplicates == value)
          return;
        this._myduplicates = value;
        this.RaisePropertyChanged("Duplicates");
      }
    }

    public bool IsDirty
    {
      get
      {
        return this._isDirty;
      }
      set
      {
        if (this._isDirty == value)
          return;
        this._isDirty = value;
        this.RaisePropertyChanged("IsDirty");
        this.LoadwritersToDBCommand.RaiseCanExecuteChanged();
      }
    }

    public string FilterText { get; set; }

    public bool AscendingChecked { get; set; }

    public WebWriters SelectedWriter
    {
      get
      {
        return this._selectedWriter;
      }
      set
      {
        if (this._selectedWriter == value)
          return;
        this._selectedWriter = value;
        this.RaisePropertyChanged("SelectedWriter");
      }
    }

    public int Afrikaans
    {
      get
      {
        return this._afrikaans;
      }
      set
      {
        if (this._afrikaans == value)
          return;
        this._afrikaans = value;
        this.RaisePropertyChanged("Afrikaans");
      }
    }

    public int English
    {
      get
      {
        return this._myenglish;
      }
      set
      {
        if (this._myenglish == value)
          return;
        this._myenglish = value;
        this.RaisePropertyChanged("English");
      }
    }

    public int Venues
    {
      get
      {
        return this._venues;
      }
      set
      {
        if (this._venues == value)
          return;
        this._venues = value;
        this.RaisePropertyChanged("Venues");
      }
    }

    public int Female
    {
      get
      {
        return this._female;
      }
      set
      {
        if (this._female == value)
          return;
        this._female = value;
        this.RaisePropertyChanged("Female");
      }
    }

    public int Male
    {
      get
      {
        return this._male;
      }
      set
      {
        if (this._male == value)
          return;
        this._male = value;
        this.RaisePropertyChanged("Male");
      }
    }

    public int Count
    {
      get
      {
        return this._count;
      }
      set
      {
        if (this._count == value)
          return;
        this._count = value;
        this.RaisePropertyChanged("Count");
      }
    }

    public ObservableCollection<string> Errors
    {
      get
      {
        return this._myProperty;
      }
      set
      {
        if (this._myProperty == value)
          return;
        this._myProperty = value;
        this.RaisePropertyChanged("Errors");
      }
    }

    public ObservableCollection<WebWriters> writers
    {
      get
      {
        return this._writers;
      }
      set
      {
        if (this._writers == value)
          return;
        this._writers = value;
        this.RaisePropertyChanged("writers");
        if (this._writers.Count <= 0)
          return;
        this.LoadwritersToDBCommand.RaiseCanExecuteChanged();
        this.RaisePropertyChanged("CleanData");
      }
    }

    public string FileName
    {
      get
      {
        return this._filename;
      }
      set
      {
        if (this._filename == value)
          return;
        this._filename = value;
        this.RaisePropertyChanged("FileName");
      }
    }

    public List<string> DBResults
    {
      get
      {
        return this._myDBResults;
      }
      set
      {
        if (this._myDBResults == value)
          return;
        this._myDBResults = value;
        this.RaisePropertyChanged("DBResults");
      }
    }

    public LoadWritersViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      this.writers = new ObservableCollection<WebWriters>();
      this.Errors = new ObservableCollection<string>();
      this.Duplicates = new ObservableCollection<WebWriters>();
      this.DBDuplicates = new ObservableCollection<WebWriters>();
    }

    private void RegisterCommands()
    {
      this.OpenFileCommand = new RelayCommand(new Action(this.OpenCSVFile));
      this.CreateFileCommand = new RelayCommand((Action) (() => this.createCsvFile()), (Func<bool>) (() => this.canManipulateData()));
      this.DeleteRowCommand = new RelayCommand((Action) (() => this.DeleteWriter()), (Func<bool>) (() => this.canManipulateData()));
      this.GetNBTCommand = new RelayCommand((Action) (() => this.GetNewNBTNumber()), (Func<bool>) (() => this.canManipulateData()));
      this.LoadwritersToDBCommand = new RelayCommand((Action) (() => this.LoadDB()), (Func<bool>) (() => this.canSaveToDB()));
      this.CleanNamesCommand = new RelayCommand((Action) (() => this.RemoveFunnyCharacters()), (Func<bool>) (() => this.canManipulateData()));
      this.GetDBDuplicatesCommand = new RelayCommand((Action) (() => this.GetDBDuplicates()), (Func<bool>) (() => this.canSaveToDB()));
      this.RefreshCommand = new RelayCommand((Action) (() => this.Refresh()), (Func<bool>) (() => this.canManipulateData()));
    }

    private bool canManipulateData()
    {
      return this._isLoaded;
    }

    private bool canSaveToDB()
    {
      if (this._mydata)
        return this._isDirty;
      return false;
    }

    private void RemoveFunnyCharacters()
    {
      this._service.CleanFunnyChars();
    }

    private void GetNewNBTNumber()
    {
      string NewNBT = "";
      this._service.GetNewNBT(this.SelectedWriter, ref NewNBT);
      this.Status = NewNBT;
      this.Refresh();
    }

    private void DeleteWriter()
    {
      if (!this._service.DeleteWriterfromList(this._selectedWriter))
        return;
      this.Refresh();
    }

    private async void GetDBDuplicates()
    {
      this.IsStarted = true;
      this.DBDuplicates = await this._service.GetDuplicatesfromDBAsync();
      this.IsStarted = false;
    }

    private void GetDuplicates()
    {
      this.Duplicates = this._service.GetDuplicates();
      if (this.Duplicates.Count<WebWriters>() > 0)
      {
        this.CleanData = false;
        foreach (WebWriters duplicate in (Collection<WebWriters>) this.Duplicates)
        {
          WebWriters a = duplicate;
          this.writers.Where<WebWriters>((Func<WebWriters, bool>) (x => x.Reference == a.Reference)).Select<WebWriters, WebWriters>((Func<WebWriters, WebWriters>) (m => m)).ToList<WebWriters>();
        }
      }
      else
      {
        this._mydata = true;
        this._isDirty = true;
      }
    }

    private async void LoadDB()
    {
      this._isDirty = false;
      this.IsStarted = true;
      await this.LoadDBAsync();
      this.IsStarted = false;
      this._isDirty = true;
      string title = "Writer List: ";
      int num = (int) ModernDialog.ShowMessage("Writer list loaded to DB", title, MessageBoxButton.OK, (Window) null);
    }

    private async Task LoadDBAsync()
    {
      if (this.DBDuplicates.Count<WebWriters>() < 1)
      {
        int num = await this._service.addwriterToDBAsync() ? 1 : 0;
      }
      else
        LoadWritersViewModel.log.Warn((object) ("There are uncleaned errors in " + this.FileName));
    }

    private void OpenCSVFile()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.DefaultExt = ".csv";
      openFileDialog.Filter = "CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = openFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this.FileName = openFileDialog.FileName;
      this.LoadData(this.FileName);
    }

    private void createCsvFile()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.DefaultExt = ".csv";
      saveFileDialog.Filter = "CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this.FileName = saveFileDialog.FileName;
      this._service.generateFile(this.FileName);
    }

    private void Refresh()
    {
      this.writers.Clear();
      this.writers = new ObservableCollection<WebWriters>(this._service.Processdata().OrderByDescending<WebWriters, int>((Func<WebWriters, int>) (s => s.errorCount)).ToList<WebWriters>());
      this.CheckHasErrors();
      this.GetDuplicates();
    }

    private void LoadData(string filename)
    {
      ObservableCollection<WebWriters> data = this._service.GetData(filename);
      if (data != null)
      {
        this.Count = data.Count;
        this.Venues = data.GroupBy<WebWriters, string>((Func<WebWriters, string>) (a => a.Venue)).Select<IGrouping<string, WebWriters>, string>((Func<IGrouping<string, WebWriters>, string>) (venueGroup => venueGroup.Key)).Count<string>();
        this.Female = data.Where<WebWriters>((Func<WebWriters, bool>) (a => a.Gender == "Female")).Count<WebWriters>();
        this.Male = data.Where<WebWriters>((Func<WebWriters, bool>) (a => a.Gender == "Male")).Count<WebWriters>();
        this.English = data.Where<WebWriters>((Func<WebWriters, bool>) (a => a.Language == "English")).Count<WebWriters>();
        this.Afrikaans = data.Where<WebWriters>((Func<WebWriters, bool>) (a => a.Language == "Afrikaans")).Count<WebWriters>();
        this.writers = new ObservableCollection<WebWriters>(data.OrderByDescending<WebWriters, int>((Func<WebWriters, int>) (s => s.errorCount)).ToList<WebWriters>());
        this._isLoaded = true;
        this.CheckHasErrors();
      }
      else
      {
        int num = (int) ModernDialog.ShowMessage("File is opened by another process or \n file does not exist", "Writer List", MessageBoxButton.OK, (Window) null);
      }
    }

    private void CheckHasErrors()
    {
      if (this.writers.Where<WebWriters>((Func<WebWriters, bool>) (x => x.HasErrors)).Select<WebWriters, WebWriters>((Func<WebWriters, WebWriters>) (m => m)).ToList<WebWriters>() != null)
        return;
      this._mydata = true;
    }

    private void HandleChangeSortDirection(object obj)
    {
      this.WebA.SortDescriptions.Clear();
      if (this.AscendingChecked)
        this.WebA.SortDescriptions.Add(new SortDescription(string.Empty, ListSortDirection.Ascending));
      else
        this.WebA.SortDescriptions.Add(new SortDescription(string.Empty, ListSortDirection.Descending));
    }

    private void applicants_Filter(object sender, FilterEventArgs e)
    {
      if (e.Item == null || this.FilterText == null)
        return;
      e.Accepted = ((string) e.Item).ToLower().StartsWith(this.FilterText.ToLower());
    }
  }
}
