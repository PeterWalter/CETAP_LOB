// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.easypay.EasyPayViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LINQtoCSV;
using CETAP_LOB.Database;
using CETAP_LOB.Helper;
using CETAP_LOB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace CETAP_LOB.ViewModel.easypay
{
  public class EasyPayViewModel : ViewModelBase
  {
    private static MRUManager<string> _mruManager = new MRUManager<string>("EasyPay", 10);
    public const string InProgressPropertyName = "InProgress";
    public const string EasyPayRecordsPropertyName = "EasyPayRecords";
    public const string DateLoadedPropertyName = "DateLoaded";
    public const string EPFileNamePropertyName = "EPFileName";
    public const string StartDatePropertyName = "StartDate";
    public const string EndDatePropertyName = "EndDate";
    public const string mruListPropertyName = "mruList";
    public const string FolderPropertyName = "Folder";
    public const string SelectedFilesPropertyName = "SelectedFiles";
    public const string DirListPropertyName = "DirList";
    private IDataService _service;
    private bool _inProgress;
    private ObservableCollection<Vw_EasyPayRecords> _espRecords;
    private DateTime _dateLoaded;
    private string _epFileName;
    private DateTime _startDate;
    private DateTime _endDate;
    private ObservableCollection<string> _mrulist;
    private string _folder;
    private IEnumerable<EasypayFile> _selectedfiles;
    private ObservableCollection<EasypayFile> _mylist;
    private EasyPayFile EPFile;

    public RelayCommand ListCommand { get; private set; }

    public RelayCommand<string> SelectedItemCommand { get; private set; }

    public RelayCommand FolderBowserCommand { get; private set; }

    public RelayCommand WriteToDatabaseCommand { get; private set; }

    public RelayCommand FromDBCommand { get; private set; }

    public RelayCommand SavetoCSVCommand { get; private set; }

    public bool InProgress
    {
      get
      {
        return this._inProgress;
      }
      set
      {
        if (this._inProgress == value)
          return;
        this._inProgress = value;
        this.RaisePropertyChanged("InProgress");
      }
    }

    public ObservableCollection<Vw_EasyPayRecords> EasyPayRecords
    {
      get
      {
        return this._espRecords;
      }
      set
      {
        if (this._espRecords == value)
          return;
        this._espRecords = value;
        this.RaisePropertyChanged("EasyPayRecords");
      }
    }

    public DateTime DateLoaded
    {
      get
      {
        return this._dateLoaded;
      }
      set
      {
        if (this._dateLoaded == value)
          return;
        this._dateLoaded = value;
        this.RaisePropertyChanged("DateLoaded");
      }
    }

    public string EPFileName
    {
      get
      {
        return this._epFileName;
      }
      set
      {
        if (this._epFileName == value)
          return;
        this._epFileName = value;
        this.RaisePropertyChanged("EPFileName");
      }
    }

    public DateTime StartDate
    {
      get
      {
        return this._startDate;
      }
      set
      {
        if (this._startDate == value)
          return;
        this._startDate = value;
        this.RaisePropertyChanged("StartDate");
      }
    }

    public DateTime EndDate
    {
      get
      {
        return this._endDate;
      }
      set
      {
        if (this._endDate == value)
          return;
        this._endDate = value;
        this.RaisePropertyChanged("EndDate");
      }
    }

    public ObservableCollection<string> mruList
    {
      get
      {
        return this._mrulist;
      }
      set
      {
        if (this._mrulist == value)
          return;
        this._mrulist = value;
        this.RaisePropertyChanged("mruList");
      }
    }

    public string Folder
    {
      get
      {
        return this._folder;
      }
      set
      {
        if (this._folder == value)
          return;
        this._folder = value;
        this.RaisePropertyChanged("Folder");
      }
    }

    public IEnumerable<EasypayFile> SelectedFiles
    {
      get
      {
        if (this.DirList != null)
          return this.DirList.Where<EasypayFile>((Func<EasypayFile, bool>) (x => x.IsSelected));
        return this._selectedfiles;
      }
      set
      {
        if (this._selectedfiles == value)
          return;
        this._selectedfiles = value;
        this.RaisePropertyChanged("SelectedFiles");
      }
    }

    public ObservableCollection<EasypayFile> DirList
    {
      get
      {
        return this._mylist;
      }
      set
      {
        if (this._mylist == value)
          return;
        this._mylist = value;
        this.RaisePropertyChanged("DirList");
      }
    }

    public EasyPayViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
      this.ftpDirectoryList();
    }

    private void InitializeModels()
    {
      this.mruList = new ObservableCollection<string>((IEnumerable<string>) EasyPayViewModel._mruManager.List);
      this.StartDate = DateTime.Now;
      this.EndDate = DateTime.Now;
    }

    private void RegisterCommands()
    {
      this.ListCommand = new RelayCommand(new Action(this.GetFiles));
      this.FolderBowserCommand = new RelayCommand(new Action(this.OpenNewFolder));
      this.WriteToDatabaseCommand = new RelayCommand((Action) (() => this.WriteToDB()));
      this.FromDBCommand = new RelayCommand((Action) (() => this.RecordsFromDB()));
      this.SavetoCSVCommand = new RelayCommand((Action) (() => this.SaveCSVFile()));
    }

    private void SaveCSVFile()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "csv files (*.csv)|*.csv|All files(*.*)|*.*|Text Files (*.txt)|*.txt";
      saveFileDialog.FilterIndex = 1;
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      new CsvContext().Write<Vw_EasyPayRecords>((IEnumerable<Vw_EasyPayRecords>) this.EasyPayRecords.ToList<Vw_EasyPayRecords>(), saveFileDialog.FileName, new CsvFileDescription()
      {
        SeparatorChar = ',',
        FirstLineHasColumnNames = true
      });
    }

    private async void RecordsFromDB()
    {
      this.InProgress = true;
      this.EasyPayRecords = await this._service.GetEasyPayRecords(this._startDate, this._endDate);
      this.InProgress = false;
    }

    private async void ftpDirectoryList()
    {
      this.EPFile = this._service.ReadLastFile();
      this._epFileName = this.EPFile.FileName;
      this._dateLoaded = Convert.ToDateTime(this.EPFile.DateWritten);
      this.DirList = this._service.ListFTPFiles();
    }

    private async void GetFiles()
    {
      this.SelectedFiles = this.DirList.Where<EasypayFile>((Func<EasypayFile, bool>) (x => x.IsSelected));
      foreach (EasypayFile selectedFile in this.SelectedFiles)
      {
        string Aname = selectedFile.FileName.ToString();
        string b = this.Folder + "/" + Aname;
        await this._service.DownloadfileAsync(Aname, b);
      }
    }

    private void OpenNewFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = "D:\\ftpeasypay\\";
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      string selectedPath = folderBrowserDialog.SelectedPath;
      EasyPayViewModel._mruManager.Add(selectedPath);
      this.mruList.Add(selectedPath);
      this.Folder = selectedPath;
    }

    private async void WriteToDB()
    {
      await this._service.WriteFilesToDBAsync(this.Folder);
    }
  }
}
