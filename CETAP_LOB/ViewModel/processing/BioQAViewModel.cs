// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.processing.BioQAViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.Helper;
using CETAP_LOB.Model;
using CETAP_LOB.Model.QA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace CETAP_LOB.ViewModel.processing
{
  public class BioQAViewModel : ViewModelBase
  {
    public const string BioQARecordsPropertyName = "BioQARecords";
    public const string FolderPropertyName = "Folder";
    public const string DirListPropertyName = "DirList";
    public const string DateofTestPropertyName = "DateofTest";
    public const string SelectedFilePropertyName = "SelectedFile";
    private ObservableCollection<BioQADatRecord> _myBioRec;
    private string _myFolder;
    private ObservableCollection<datFileAttributes> _myQAFiles;
    private DateTime _myDOT;
    private datFileAttributes _myQAFile;
    private IDataService _service;

    public RelayCommand GetNBTCommand { get; private set; }

    public RelayCommand GetNamesCommand { get; private set; }

    public RelayCommand GetIDCommand { get; private set; }

    public RelayCommand GetDOBCommand { get; private set; }

    public RelayCommand AutoCleanCommand { get; private set; }

    public RelayCommand AddSurnameCommand { get; private set; }

    public RelayCommand AddNameCommand { get; private set; }

    public RelayCommand RefreshCommand { get; private set; }

    public RelayCommand SaveDatFileCommand { get; private set; }

    public RelayCommand UpdateTrackerCommand { get; private set; }

    public ObservableCollection<BioQADatRecord> BioQARecords
    {
      get
      {
        return this._myBioRec;
      }
      set
      {
        if (this._myBioRec == value)
          return;
        this._myBioRec = value;
        this.RaisePropertyChanged("BioQARecords");
      }
    }

    public string Folder
    {
      get
      {
        return this._myFolder;
      }
      set
      {
        if (this._myFolder == value)
          return;
        this._myFolder = value;
        this.RaisePropertyChanged("Folder");
      }
    }

    public ObservableCollection<datFileAttributes> DirList
    {
      get
      {
        return this._myQAFiles;
      }
      set
      {
        if (this._myQAFiles == value)
          return;
        this._myQAFiles = value;
        this.RaisePropertyChanged("DirList");
      }
    }

    public DateTime DateofTest
    {
      get
      {
        return this._myDOT;
      }
      set
      {
        if (this._myDOT == value)
          return;
        this._myDOT = value;
        this.RaisePropertyChanged("DateofTest");
      }
    }

    public datFileAttributes SelectedFile
    {
      get
      {
        return this._myQAFile;
      }
      set
      {
        if (this._myQAFile == value)
          return;
        this._myQAFile = value;
        if (this._myQAFile == null)
          return;
        this.RaisePropertyChanged("SelectedFile");
      }
    }

    public BioQAViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      this.Folder = ApplicationSettings.Default.QAFolder;
      DateTime.Now.Year.ToString();
      this._service.ReadEndofDatFile();
      this._myDOT = DateTime.Now;
      this.Selectfolder();
    }

    private void RegisterCommands()
    {
      this.UpdateTrackerCommand = new RelayCommand(new Action(this.updateTracker));
      this.AddSurnameCommand = new RelayCommand((Action) (() => this.AddSurname()));
      this.AddNameCommand = new RelayCommand((Action) (() => this.AddName()));
    }

    private void Selectfolder()
    {
      List<datFileAttributes> datFileAttributesList = new List<datFileAttributes>();
      try
      {
        foreach (FileSystemInfo file in new DirectoryInfo(this.Folder).GetFiles("*.dat"))
        {
          datFileAttributes datFileAttributes = new datFileAttributes(file.FullName);
          this.SelectedFile = datFileAttributes;
          this.GetBioQAData();
          datFileAttributes.NoOfErrors = this.BioQARecords.Sum<BioQADatRecord>((Func<BioQADatRecord, int>) (x => x.ErrorCount));
          datFileAttributesList.Add(datFileAttributes);
          this.SelectedFile = (datFileAttributes) null;
        }
      }
      catch (Exception ex)
      {
        int num = (int) ModernDialog.ShowMessage(ex.ToString(), "Update", MessageBoxButton.OK, (Window) null);
      }
    }

    private void GetBioQAData()
    {
    }

    private void AddSurname()
    {
    }

    private void AddName()
    {
    }

    private void updateTracker()
    {
      foreach (datFileAttributes dir in (Collection<datFileAttributes>) this.DirList)
      {
        bool flag = false;
        File.ReadAllLines(dir.FilePath);
        string sname = dir.SName;
        if (!flag)
        {
          int num = (int) ModernDialog.ShowMessage("Batch was not recorded on tracker!!!", sname, MessageBoxButton.OK, (Window) null);
        }
      }
    }
  }
}
