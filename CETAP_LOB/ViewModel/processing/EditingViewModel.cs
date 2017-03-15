// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.processing.EditingViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace CETAP_LOB.ViewModel.processing
{
  public class EditingViewModel : ViewModelBase
  {
    public const string DirListPropertyName = "DirList";
    public const string SelectedFilePropertyName = "SelectedFile";
    public const string FolderPropertyName = "Folder";
    public const string SelectedFilesPropertyName = "SelectedFiles";
    private IDataService _service;
    private ObservableCollection<ScannedFileBDO> _myfiles;
    private ScannedFileBDO _myfile;
    private string _folder;
    private IEnumerable<ScannedFileBDO> _selectedfiles;

    public RelayCommand SaveScannedFileCommand { get; private set; }

    public RelayCommand FolderBowserCommand { get; private set; }

    public ObservableCollection<ScannedFileBDO> DirList
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
        this.RaisePropertyChanged("DirList");
      }
    }

    public ScannedFileBDO SelectedFile
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
        this.RaisePropertyChanged("SelectedFile");
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

    public IEnumerable<ScannedFileBDO> SelectedFiles
    {
      get
      {
        return this.DirList.Where<ScannedFileBDO>((Func<ScannedFileBDO, bool>) (x => x.IsSelected));
      }
      set
      {
        if (this._selectedfiles == value)
          return;
        this._selectedfiles = value;
        this.RaisePropertyChanged("SelectedFiles");
      }
    }

    public EditingViewModel(IDataService Service)
    {
      this._service = Service;
      this.InitializeModels();
      this.RegisterCommands();
      this.Refresh();
    }

    private void InitializeModels()
    {
    }

    private void RegisterCommands()
    {
      this.SaveScannedFileCommand = new RelayCommand(new Action(this.SaveDatFile));
    }

    private void LoadData(string filename)
    {
    }

    private void Selectfolder()
    {
      List<ScannedFileBDO> list = new List<ScannedFileBDO>();
      foreach (FileInfo file in new DirectoryInfo(this.Folder).GetFiles("*.dat"))
        list.Add(new ScannedFileBDO()
        {
          Filepath = file.FullName,
          Filename = file.Name.ToUpper(),
          DateScanned = file.CreationTime
        });
      this.DirList = new ObservableCollection<ScannedFileBDO>(list);
    }

    private void Refresh()
    {
      this.Folder = ApplicationSettings.Default.ScanningFolder;
      this.Selectfolder();
    }

    private void SaveDatFile()
    {
      foreach (ScannedFileBDO selectedFile in this.SelectedFiles)
      {
        string message = "";
        if (!this._service.SaveFileToDB(selectedFile, ref message))
        {
          int num = (int) ModernDialog.ShowMessage(message, "Existing File", MessageBoxButton.OK, (Window) null);
        }
        else
        {
          string destFileName = Path.Combine(ApplicationSettings.Default.EditingFolder, selectedFile.Filename);
          File.Move(selectedFile.Filepath, destFileName);
        }
      }
      this.Refresh();
    }
  }
}
