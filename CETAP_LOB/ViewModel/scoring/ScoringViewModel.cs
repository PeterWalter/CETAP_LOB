// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.scoring.ScoringViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using CETAP_LOB.Model.scoring;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace LOB.ViewModel.scoring
{
  public class ScoringViewModel : ViewModelBase
  {
    public const string StatusPropertyName = "Status";
    public const string CompositPropertyName = "Composit";
    public const string BIOPropertyName = "BIO";
    public const string MATPropertyName = "MAT";
    public const string AQLPropertyName = "AQL";
    public const string FilesInFolderPropertyName = "FilesInFolder";
    private IDataService _service;
    private bool IsmatchScores;
    private string _myStatus;
    private ObservableCollection<CompositBDO> _composit;
    private ObservableCollection<AnswerSheetBio> _bio;
    private ObservableCollection<MAT_Score> _mat;
    private ObservableCollection<AQL_Score> _aql;
    private ObservableCollection<string> _myfiles;

    public RelayCommand SelectFolderCommand { get; private set; }

    public RelayCommand ReadFilesCommand { get; private set; }

    public RelayCommand ProcessScoresCommand { get; private set; }

    public RelayCommand GenerateCompositeCommand { get; private set; }

    public RelayCommand TrackScoresCommand { get; private set; }

    public string Status
    {
      get
      {
        return this._myStatus;
      }
      set
      {
        if (this._myStatus == value)
          return;
        this._myStatus = value;
        this.RaisePropertyChanged("Status");
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

    public ObservableCollection<AnswerSheetBio> BIO
    {
      get
      {
        return this._bio;
      }
      set
      {
        if (this._bio == value)
          return;
        this._bio = value;
        this.RaisePropertyChanged("BIO");
      }
    }

    public ObservableCollection<MAT_Score> MAT
    {
      get
      {
        return this._mat;
      }
      set
      {
        if (this._mat == value)
          return;
        this._mat = value;
        this.RaisePropertyChanged("MAT");
      }
    }

    public ObservableCollection<AQL_Score> AQL
    {
      get
      {
        return this._aql;
      }
      set
      {
        if (this._aql == value)
          return;
        this._aql = value;
        this.RaisePropertyChanged("AQL");
      }
    }

    public ObservableCollection<string> FilesInFolder
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
        this.RaisePropertyChanged("FilesInFolder");
      }
    }

    public ScoringViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      this.FilesInFolder = new ObservableCollection<string>();
      this.Composit = new ObservableCollection<CompositBDO>();
    }

    private void RegisterCommands()
    {
      this.SelectFolderCommand = new RelayCommand(new Action(this.selectFolder));
      this.ReadFilesCommand = new RelayCommand(new Action(this.readScoreFiles));
      this.ProcessScoresCommand = new RelayCommand((Action) (() => this.ProcessScores()), (Func<bool>) (() => this.CanprocessScores()));
      this.GenerateCompositeCommand = new RelayCommand((Action) (() => this.GenerateComposite()));
      this.TrackScoresCommand = new RelayCommand((Action) (() => this.TrackScores()), (Func<bool>) (() => this.canTrack()));
    }

    private void TrackScores()
    {
      foreach (var data in this.Composit.GroupBy<CompositBDO, string>((Func<CompositBDO, string>) (b => b.Batch)).Select(g => new
      {
        Batch = g.Key,
        Amount = g.Count<CompositBDO>()
      }).ToList())
      {
        int int32 = Convert.ToInt32(data.Amount);
        this._service.RecordsTrackedScores(data.Batch.ToString(), int32);
      }
    }

    private bool canTrack()
    {
      bool flag = false;
      if (this.Composit.Count > 0)
        flag = true;
      return flag;
    }

    private void GenerateComposite()
    {
      string text;
      if (this._service.GenerateComposite())
      {
        text = "Composite files have been generated !!";
        int num = (int) ModernDialog.ShowMessage(text, "Composite", MessageBoxButton.OK, (Window) null);
      }
      else
      {
        text = "Composite not created";
        int num = (int) ModernDialog.ShowMessage(text, "Composite", MessageBoxButton.OK, (Window) null);
      }
      this.Status = text;
    }

    private bool CanGenerateComposite()
    {
      return this.Composit.Count > 0;
    }

    private void ProcessScores()
    {
      this.MatchScores();
    }

    private bool CanprocessScores()
    {
      return false;
    }

    private void LoadData(string filename)
    {
    }

    private void readScoreFiles()
    {
      this.AQL = this._service.GetAQL();
      this.MAT = this._service.GetMat();
      this.BIO = this._service.GetBIO();
      this.IsmatchScores = true;
      this.MatchScores();
    }

    private void SendMessageCallback(string message)
    {
      if (!(message == "Clean BIO"))
        return;
      this.MatchScores();
    }

    private void MatchScores()
    {
      if (!this.IsmatchScores)
        return;
      this.Composit = this._service.MatchScores();
    }

    private void selectFolder()
    {
      this.FilesInFolder.Clear();
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = ApplicationSettings.Default.ScoreFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      string selectedPath = folderBrowserDialog.SelectedPath;
      this.FilesInFolder = this._service.ListScoreFiles(selectedPath);
      ApplicationSettings.Default.ScoreFolder = selectedPath;
      ApplicationSettings.Default.Save();
    }
  }
}
