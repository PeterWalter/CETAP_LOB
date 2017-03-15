// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.ScanSettingsViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using CETAP_LOB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CETAP_LOB.ViewModel
{
  public class ScanSettingsViewModel : ViewModelBase
  {
    public const string PeriodsPropertyName = "Periods";
    public const string IntakeRecordPropertyName = "IntakeRecord";
    public const string IntakeYearPropertyName = "IntakeYear";
    public const string ScoreModerationFolderPropertyName = "ScoreModerationFolder";
    public const string ScoreFolderPropertyName = "ScoreFolder";
    public const string FilesForScoringFolderPropertyName = "FilesForScoringFolder";
    public const string FilesForScoringModerationFolderPropertyName = "FilesForScoringModerationFolder";
    public const string QAFolderPropertyName = "QAFolder";
    public const string EditFolderPropertyName = "EditFolder";
    public const string ScanFolderPropertyName = "ScanFolder";
    private bool IsSet;
    private List<IntakeYearsBDO> _myPeriods;
    private IntakeYearsBDO _intakerecord;
    private int _intakeYear;
    private string _myScoreModFolder;
    private string _myScoreFolder;
    private string _myFFSF;
    private string _myFFSMF;
    private string _myQAFolder;
    private string _editFolder;
    private string _scanfolder;
    private IDataService _service;

    public RelayCommand ScanFolderBowserCommand { get; private set; }

    public RelayCommand EditFolderBowserCommand { get; private set; }

    public RelayCommand QAFolderBowserCommand { get; private set; }

    public RelayCommand FilesForScoringFolderModerationCommand { get; private set; }

    public RelayCommand FilesForScoringFolderCommand { get; private set; }

    public RelayCommand ScoreFolderCommand { get; private set; }

    public RelayCommand ScoreModerationFolderCommand { get; private set; }

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
        this._intakeYear = this._intakerecord.Year;
        ApplicationSettings.Default.IntakeYear = this._intakeYear;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("IntakeYear");
      }
    }

    public int IntakeYear
    {
      get
      {
        return this._intakeYear;
      }
      set
      {
        if (this._intakeYear == value)
          return;
        this._intakeYear = value;
        ApplicationSettings.Default.IntakeYear = this._intakeYear;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("IntakeYear");
      }
    }

    public string ScoreModerationFolder
    {
      get
      {
        return this._myScoreModFolder;
      }
      set
      {
        if (this._myScoreModFolder == value)
          return;
        this._myScoreModFolder = value;
        ApplicationSettings.Default.ScoreModerationFolder = this._myScoreModFolder;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("ScoreModerationFolder");
      }
    }

    public string ScoreFolder
    {
      get
      {
        return this._myScoreFolder;
      }
      set
      {
        if (this._myScoreFolder == value)
          return;
        this._myScoreFolder = value;
        ApplicationSettings.Default.ScoreFolder = this._myScoreFolder;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("ScoreFolder");
      }
    }

    public string FilesForScoringFolder
    {
      get
      {
        return this._myFFSF;
      }
      set
      {
        if (this._myFFSF == value)
          return;
        this._myFFSF = value;
        ApplicationSettings.Default.FilesForScoring = this._myFFSF;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("FilesForScoringFolder");
      }
    }

    public string FilesForScoringModerationFolder
    {
      get
      {
        return this._myFFSMF;
      }
      set
      {
        if (this._myFFSMF == value)
          return;
        this._myFFSMF = value;
        ApplicationSettings.Default.ModerationFilesForScoring = this._myFFSMF;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("FilesForScoringModerationFolder");
      }
    }

    public string QAFolder
    {
      get
      {
        return this._myQAFolder;
      }
      set
      {
        if (this._myQAFolder == value)
          return;
        this._myQAFolder = value;
        ApplicationSettings.Default.QAFolder = this._myQAFolder;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("QAFolder");
      }
    }

    public string EditFolder
    {
      get
      {
        return this._editFolder;
      }
      set
      {
        if (this._editFolder == value)
          return;
        this._editFolder = value;
        ApplicationSettings.Default.EditingFolder = this._editFolder;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("EditFolder");
      }
    }

    public string ScanFolder
    {
      get
      {
        return this._scanfolder;
      }
      set
      {
        if (this._scanfolder == value)
          return;
        this._scanfolder = value;
        ApplicationSettings.Default.ScanningFolder = this._scanfolder;
        ApplicationSettings.Default.Save();
        this.RaisePropertyChanged("ScanFolder");
      }
    }

    public ScanSettingsViewModel()
    {
      this._service = (IDataService) new DataService();
      this.InitializeModels();
      this.RegisterCommands();
    }

    private void InitializeModels()
    {
      this.ScanFolder = ApplicationSettings.Default.ScanningFolder;
      this.EditFolder = ApplicationSettings.Default.EditingFolder;
      this.QAFolder = ApplicationSettings.Default.QAFolder;
      this.FilesForScoringFolder = ApplicationSettings.Default.FilesForScoring;
      this.FilesForScoringModerationFolder = ApplicationSettings.Default.ModerationFilesForScoring;
      this.ScoreModerationFolder = ApplicationSettings.Default.ScoreModerationFolder;
      this.ScoreFolder = ApplicationSettings.Default.ScoreFolder;
      this._intakeYear = ApplicationSettings.Default.IntakeYear;
    }

    private void RegisterCommands()
    {
      this.EditFolderBowserCommand = new RelayCommand(new Action(this.SelectEditFolder));
      this.ScanFolderBowserCommand = new RelayCommand(new Action(this.SelectScanFolder));
      this.QAFolderBowserCommand = new RelayCommand(new Action(this.SelectQAFolder));
      this.ScoreFolderCommand = new RelayCommand(new Action(this.SelectScoreFolder));
      this.FilesForScoringFolderCommand = new RelayCommand(new Action(this.SelectFilesForScoringFolder));
      this.FilesForScoringFolderModerationCommand = new RelayCommand(new Action(this.SelectFilesForScoringModerationFolder));
      this.ScoreModerationFolderCommand = new RelayCommand(new Action(this.SelectScoreModerationFolder));
      this._myPeriods = new List<IntakeYearsBDO>();
      this._myPeriods = this._service.GetAllIntakeYears();
      this._intakerecord = this._myPeriods.Where<IntakeYearsBDO>((Func<IntakeYearsBDO, bool>) (x => x.Year == this._intakeYear)).FirstOrDefault<IntakeYearsBDO>();
    }

    private void SelectScoreFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      this.ScanFolder = ApplicationSettings.Default.ScoreFolder;
      folderBrowserDialog.SelectedPath = this.ScoreFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.ScoreFolder = folderBrowserDialog.SelectedPath;
      ApplicationSettings.Default.ScoreFolder = this.ScoreFolder;
      ApplicationSettings.Default.Save();
    }

    private void SelectScoreModerationFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.ScoreModerationFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.ScoreModerationFolder = folderBrowserDialog.SelectedPath;
      ApplicationSettings.Default.ScoreModerationFolder = this.ScoreModerationFolder;
      ApplicationSettings.Default.Save();
    }

    private void SelectFilesForScoringFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.FilesForScoringFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.FilesForScoringFolder = folderBrowserDialog.SelectedPath;
      ApplicationSettings.Default.FilesForScoring = this.FilesForScoringFolder;
      ApplicationSettings.Default.Save();
    }

    private void SelectFilesForScoringModerationFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.FilesForScoringModerationFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.FilesForScoringModerationFolder = folderBrowserDialog.SelectedPath;
      ApplicationSettings.Default.ModerationFilesForScoring = this.FilesForScoringModerationFolder;
      ApplicationSettings.Default.Save();
    }

    private void SelectQAFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.QAFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.QAFolder = folderBrowserDialog.SelectedPath;
      ApplicationSettings.Default.QAFolder = this.QAFolder;
      ApplicationSettings.Default.Save();
    }

    private void SelectScanFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.ScanFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.ScanFolder = folderBrowserDialog.SelectedPath;
    }

    private void SelectEditFolder()
    {
      FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
      folderBrowserDialog.SelectedPath = this.EditFolder;
      if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.EditFolder = folderBrowserDialog.SelectedPath;
    }

    private void StoreSettings()
    {
      if (!this.IsSet)
        return;
      ApplicationSettings.Default.ScanningFolder = this.ScanFolder;
      ApplicationSettings.Default.EditingFolder = this.EditFolder;
      ApplicationSettings.Default.ScoreFolder = this.ScoreFolder;
      ApplicationSettings.Default.ScoreModerationFolder = this.ScoreModerationFolder;
      ApplicationSettings.Default.ModerationFilesForScoring = this.FilesForScoringModerationFolder;
      ApplicationSettings.Default.FilesForScoring = this.FilesForScoringFolder;
      ApplicationSettings.Default.IntakeYear = this.IntakeYear;
      ApplicationSettings.Default.Save();
    }

    public void SetScanSettings(string scanfolder, string editfolder, string Qafolder, int intakeYear)
    {
      this.ScanFolder = scanfolder;
      this.EditFolder = editfolder;
      this.QAFolder = Qafolder;
      this.IntakeYear = intakeYear;
      this.IsSet = true;
    }

    public void SetScoringSettings(string Scorefolder, string ScoreModFolder, string FFScoring, string MFFScoring)
    {
      this.ScoreFolder = Scorefolder;
      this.ScoreModerationFolder = ScoreModFolder;
      this.FilesForScoringFolder = FFScoring;
      this.FilesForScoringModerationFolder = MFFScoring;
      this.IsSet = true;
    }
  }
}
