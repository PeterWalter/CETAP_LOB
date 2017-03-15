// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.composite.EditCompositeViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.BDO;
using CETAP_LOB.Helper;
using CETAP_LOB.Model;
using CETAP_LOB.Model.QA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CETAP_LOB.ViewModel.composite
{
  public class EditCompositeViewModel : ViewModelBase
  {
    public const string RecInListPropertyName = "RecInList";
    public const string RecordsPropertyName = "Records";
    public const string QADataPropertyName = "QAData";
    public const string TrialSectPropertyName = "TrialSect";
    public const string NoOfFilesPropertyName = "NoOfFiles";
    public const string DatFilesPropertyName = "DatFiles";
    public const string FileNamePropertyName = "FileName";
    public const string CompositPropertyName = "Composit";
    private int _mylist;
    private int _myRecords;
    private ObservableCollection<QADatRecord> _myQAData;
    private ObservableCollection<Section7> _myTrials;
    private int _myCount;
    private ObservableCollection<string> _myfiles;
    private string _myfile;
    private ObservableCollection<CompositBDO> _composit;
    private IDataService _service;

    public RelayCommand NoMatchCommand { get; private set; }

    public RelayCommand GenerateCompositeCommand { get; private set; }

    public RelayCommand ReadFilesCommand { get; private set; }

    public RelayCommand SavetoCSVCommand { get; private set; }

    public int RecInList
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
        this.RaisePropertyChanged("RecInList");
      }
    }

    public int Records
    {
      get
      {
        return this._myRecords;
      }
      set
      {
        if (this._myRecords == value)
          return;
        this._myRecords = value;
        this.RaisePropertyChanged("Records");
      }
    }

    public ObservableCollection<QADatRecord> QAData
    {
      get
      {
        return this._myQAData;
      }
      set
      {
        if (this._myQAData == value)
          return;
        this._myQAData = value;
        this.RaisePropertyChanged("QAData");
      }
    }

    public ObservableCollection<Section7> TrialSect
    {
      get
      {
        return this._myTrials;
      }
      set
      {
        if (this._myTrials == value)
          return;
        this._myTrials = value;
        this.RaisePropertyChanged("TrialSect");
      }
    }

    public int NoOfFiles
    {
      get
      {
        return this._myCount;
      }
      set
      {
        if (this._myCount == value)
          return;
        this._myCount = value;
        this.RaisePropertyChanged("NoOfFiles");
      }
    }

    public ObservableCollection<string> DatFiles
    {
      get
      {
        return this._myfiles;
      }
      set
      {
        if (this._myfiles == value)
          return;
        this._myfiles = value;
        this.RaisePropertyChanged("DatFiles");
      }
    }

    public string FileName
    {
      get
      {
        return this._myfile;
      }
      set
      {
        if (this._myfile == value)
          return;
        this._myfile = value;
        this.RaisePropertyChanged("FileName");
      }
    }

    public ObservableCollection<CompositBDO> Composit
    {
      get
      {
        return this._composit;
      }
      set
      {
        if (this._composit == value)
          return;
        this._composit = value;
        this.RaisePropertyChanged("Composit");
      }
    }

    public EditCompositeViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
      this.TrialSect = new ObservableCollection<Section7>();
    }

    private void InitializeModels()
    {
    }

    private void RegisterCommands()
    {
      this.NoMatchCommand = new RelayCommand(new Action(this.NoMatchFile));
      this.GenerateCompositeCommand = new RelayCommand((Action) (() => this.GenerateComposite()), (Func<bool>) (() => this.HasSelection()));
      this.ReadFilesCommand = new RelayCommand(new Action(this.ReadFiles));
      this.SavetoCSVCommand = new RelayCommand(new Action(this.SaveToCSVFile));
    }

    private void SaveToCSVFile()
    {
      Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
      saveFileDialog.DefaultExt = ".xlsx";
      saveFileDialog.Filter = "CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = saveFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this.GenerateCSVFile(saveFileDialog.FileName);
    }

    private void GenerateCSVFile(string filename)
    {
      using (StreamWriter streamWriter = new StreamWriter(filename))
      {
        foreach (Section7 section7 in (Collection<Section7>) this.TrialSect)
          streamWriter.WriteLine((object) section7);
      }
      int num = (int) ModernDialog.ShowMessage("Excel File has been saved to folder", "Save File!!", MessageBoxButton.OK, (Window) null);
    }

    private async void ReadFiles()
    {
      await this.ReadFilesAsync();
      await this.WriteRecords();
      this.RecInList = this.TrialSect.Count<Section7>();
    }

    private async Task WriteRecords()
    {
      foreach (string datFile in (Collection<string>) this.DatFiles)
      {
        datFileAttributes thefile = new datFileAttributes(datFile);
        this.Records += thefile.RecordCount;
        ObservableCollection<Section7> data = new ObservableCollection<Section7>();
        data = this._service.getSec7DatFile(thefile);
        await this.AddAsync(data);
      }
    }

    private async Task ReadFilesAsync()
    {
            // select folder

            string path = "";
            var dialog = new FolderBrowserDialog();
            DatFiles = new ObservableCollection<string>();
            string[] files;
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                path = dialog.SelectedPath;
                files = Directory.GetFiles(path, "01*.dat", SearchOption.AllDirectories);
                DatFiles = new ObservableCollection<string>(files);
                NoOfFiles = DatFiles.Count;


            }
        }

    private async Task AddAsync(ObservableCollection<Section7> Data)
    {
      foreach (Section7 section7 in  Data) TrialSect.Add(section7);
    }

    private void GenerateComposite()
    {
    }

    public bool HasSelection()
    {
            bool isSelected = false;
            if (Composit.Count > 0) isSelected = true;
            return isSelected;
    }

    private void NoMatchFile()
    {
      Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
      openFileDialog.DefaultExt = ".csv";
      openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV FilesinFolder (*.csv)|*.csv|Data files (*.dat)|*.dat|Text files (*.txt|*.txt";
      bool? nullable = openFileDialog.ShowDialog();
      if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
        return;
      this.FileName = openFileDialog.FileName;
      this.GetFile();
    }

    public void GetFile()
    {
      this._service.GetNoMatchFile(this.FileName);
    }
  }
}
