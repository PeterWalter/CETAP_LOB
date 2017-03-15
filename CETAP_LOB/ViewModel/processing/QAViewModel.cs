// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.processing.QAViewModel
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
using System.Windows;

namespace CETAP_LOB.ViewModel.processing
{
  public class QAViewModel : ViewModelBase
  {
    private string Duplicatefile = "";
    public const string BatchesInQueuePropertyName = "BatchesInQueue";
    public const string BatchRecordsPropertyName = "BatchRecords";
    public const string FileCombinationPropertyName = "FileCombination";
    public const string DateofTestPropertyName = "DateofTest";
    public const string ProfilePropertyName = "Profile";
    public const string VenueCodePropertyName = "VenueCode";
    public const string SelectedQuestionPropertyName = "SelectedQuestion";
    public const string StatusPropertyName = "Status";
    public const string SelectedQARecordPropertyName = "SelectedQARecord";
    public const string QARecordsPropertyName = "QARecords";
    public const string SelectedFilePropertyName = "SelectedFile";
    public const string DirListPropertyName = "DirList";
    public const string FolderPropertyName = "Folder";

        private IDataService _service;
    private bool HasDuplicates;
    private bool HasDuplicatesQueue;
    private bool HasDuplicatesInDB;
    private ObservableCollection<ForDuplicatesBarcodesBDO> _myInQueue;
    private ObservableCollection<ForDuplicatesBarcodesBDO> _batchedRecords;
    private string _myCombination;
    private DateTime _myDOT;
    private int _myProfile;
    private int _myVenueCode;
    private char _mySelectedQuestion;
    private string _myStatus;
    private QADatRecord _myQARecord;
    private ObservableCollection<QADatRecord> _myQARecords;
    private datFileAttributes _myQAFile;
    private ObservableCollection<datFileAttributes> _myQAFiles;
    private string _myFolder;
    

    public RelayCommand GetNBTCommand { get; private set; }
    public RelayCommand DuplicatesCommand { get; private set; }
    public RelayCommand GetNamesCommand { get; private set; }
    public RelayCommand GetIDCommand { get; private set; }
    public RelayCommand GetDOBCommand { get; private set; }
    public RelayCommand AutoCleanCommand { get; private set; }
    public RelayCommand AddSurnameCommand { get; private set; }
    public RelayCommand AddNameCommand { get; private set; }
    public RelayCommand RefreshCommand { get; private set; }
    public RelayCommand SaveDatFileCommand { get; private set; }
    public RelayCommand UpdateTrackerCommand { get; private set; }
    public RelayCommand ProcessRawScoresCommand { get; private set; }

    public ObservableCollection<ForDuplicatesBarcodesBDO> BatchesInQueue
    {
      get
      {
        return _myInQueue;
      }
      set
      {
        if (_myInQueue == value)
          return;
        _myInQueue = value;
        RaisePropertyChanged("BatchesInQueue");
      }
    }

    public ObservableCollection<ForDuplicatesBarcodesBDO> BatchRecords
    {
      get
      {
        return _batchedRecords;
      }
      set
      {
        if (_batchedRecords == value)
          return;
        _batchedRecords = value;
        RaisePropertyChanged("BatchRecords");
      }
    }

    public string FileCombination
    {
      get
      {
        return _myCombination;
      }
      set
      {
        if (_myCombination == value)
          return;
        _myCombination = value;
        RaisePropertyChanged("FileCombination");
      }
    }

    public DateTime DateofTest
    {
      get
      {
        return _myDOT;
      }
      set
      {
        if (_myDOT == value)
          return;
        _myDOT = value;
        LoadTestDate(_myDOT);
        RaisePropertyChanged("DateofTest");
      }
    }

    public int Profile
    {
      get
      {
        return _myProfile;
      }
      set
      {
        if (_myProfile == value)
          return;
        _myProfile = value;
        RaisePropertyChanged("Profile");
      }
    }

    public int VenueCode
    {
      get
      {
        return _myVenueCode;
      }
      set
      {
        if (_myVenueCode == value)
          return;
        _myVenueCode = value;
        RaisePropertyChanged("VenueCode");
      }
    }

    public char SelectedQuestion
    {
      get
      {
        return _mySelectedQuestion;
      }
      set
      {
        if ((int) _mySelectedQuestion == (int) value)
          return;
        _mySelectedQuestion = value;
        RaisePropertyChanged("SelectedQuestion");
      }
    }

    public string Status
    {
      get
      {
        return _myStatus;
      }
      set
      {
        if (_myStatus == value)
          return;
        _myStatus = value;
        RaisePropertyChanged("Status");
      }
    }

    public QADatRecord SelectedQARecord
    {
      get
      {
        return _myQARecord;
      }
      set
      {
        if (_myQARecord == value)
          return;
        _myQARecord = value;
        RaisePropertyChanged("SelectedQARecord");
      }
    }

    public ObservableCollection<QADatRecord> QARecords
    {
      get
      {
        return _myQARecords;
      }
      set
      {
        if (_myQARecords == value)
          return;
        _myQARecords = value;
        RaisePropertyChanged("QARecords");
      }
    }

    public datFileAttributes SelectedFile
    {
      get
      {
        return _myQAFile;
      }
      set
      {
        if (_myQAFile == value)
          return;
        _myQAFile = value;
        if (_myQAFile != null)
          GetQAData();
        RaisePropertyChanged("SelectedFile");
      }
    }

    public ObservableCollection<datFileAttributes> DirList
    {
      get
      {
        return _myQAFiles;
      }
      set
      {
        if (_myQAFiles == value)
          return;
        _myQAFiles = value;
        RaisePropertyChanged("DirList");
      }
    }

    public string Folder
    {
      get
      {
        return _myFolder;
      }
      set
      {
        if (_myFolder == value)
          return;
        _myFolder = value;
        RaisePropertyChanged("Folder");
      }
    }

    public QAViewModel(IDataService Service)
    {
      _service = Service;
      InitializeModels();
      RegisterCommands();
    }

    private void InitializeModels()
    {
      Folder = ApplicationSettings.Default.QAFolder;
      _service.ReadEndofDatFile();
      _myDOT = DateTime.Now;
      Selectfolder();
    }

    private void RegisterCommands()
    {
      GetNBTCommand = new RelayCommand(new Action(GetNBTNumber));
      GetNamesCommand = new RelayCommand(new Action(GetNamesfromDB));
      GetDOBCommand = new RelayCommand(new Action(GetDOBfromDB));
      GetIDCommand = new RelayCommand(new Action(GetIDfromDB));
      RefreshCommand = new RelayCommand(new Action(Refresh));
      SaveDatFileCommand = new RelayCommand((Action) (() => SaveDatFile()));
      AutoCleanCommand = new RelayCommand(new Action(AutoClean));
      ProcessRawScoresCommand = new RelayCommand(new Action(ProcessRawScores));
      UpdateTrackerCommand = new RelayCommand(new Action(updateTracker));
      AddSurnameCommand = new RelayCommand((Action) (() => AddSurname()));
      AddNameCommand = new RelayCommand((Action) (() => AddName()));
      DuplicatesCommand = new RelayCommand(() => FindDuplicates(), () => IsDataClean());
    }

    private void FindDuplicates()
    {
          BatchRecords = new ObservableCollection<ForDuplicatesBarcodesBDO>();
          Duplicatefile = Path.Combine(Folder, "Duplicate QA records");
          ReadQARecs();
          DuplicatesWithinAQBatches();
          if (HasDuplicates)  return;
          BatchesInQueue = _service.GetBatchesInQueue();
          if (BatchesInQueue.Count<ForDuplicatesBarcodesBDO>() > 0)
            FindDuplicatesInQueue();
          if (HasDuplicatesQueue)
            return;
          FindDuplicatesInDB();
          if (HasDuplicatesInDB)
            return;
          if (!_service.WriteToBatchQueue(BatchRecords))
            return;
          int num = (int) MessageBox.Show("Barcodes now in Score Queue");
    }

    private void FindDuplicatesInDB()
    {
      List<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdoList = new List<ForDuplicatesBarcodesBDO>();
      List<ForDuplicatesBarcodesBDO> duplicatesFromDb = _service.FindDuplicatesFromDB(BatchRecords);
      if (duplicatesFromDb.Count<ForDuplicatesBarcodesBDO>() <= 0)
        return;
      HasDuplicatesInDB = true;
      GenerateDuplicatesReport(duplicatesFromDb);
    }

    private void FindDuplicatesInQueue()
    {
          // duplicates in Queue
          List<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdoList = new List<ForDuplicatesBarcodesBDO>();
          foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in BatchRecords.Where(x => BatchesInQueue.Any(v => v.Barcode == x.Barcode)).ToList<ForDuplicatesBarcodesBDO>())
          {
                duplicatesBarcodesBdo.Reason = "Duplicate Barcode in files being scored";
                duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
          }
          foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in BatchRecords.Where<ForDuplicatesBarcodesBDO>((Func<ForDuplicatesBarcodesBDO, bool>) (x => BatchesInQueue.Any<ForDuplicatesBarcodesBDO>((Func<ForDuplicatesBarcodesBDO, bool>) (v =>
          {
                long? said1 = v.SAID;
                long? said2 = x.SAID;
                if ((said1.GetValueOrDefault() != said2.GetValueOrDefault() ? 0 : (said1.HasValue == said2.HasValue ? 1 : 0)) != 0)
                  return v.SAID.HasValue;
                return false;
              })))).ToList<ForDuplicatesBarcodesBDO>())
          {
                duplicatesBarcodesBdo.Reason = "Duplicate SA ID in files being scored";
                duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
          }
          foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in BatchRecords.Where<ForDuplicatesBarcodesBDO>((Func<ForDuplicatesBarcodesBDO, bool>) (x => BatchesInQueue.Any<ForDuplicatesBarcodesBDO>((Func<ForDuplicatesBarcodesBDO, bool>) (v =>
          {
                if (v.FID == x.FID)
                  return v.FID != "";
                return false;
              })))).ToList<ForDuplicatesBarcodesBDO>())
          {
                duplicatesBarcodesBdo.Reason = "Duplicate ForeignID in files being scored";
                duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
          }
          if (duplicatesBarcodesBdoList.Count<ForDuplicatesBarcodesBDO>() <= 0)   return;
          HasDuplicatesQueue = true;
          GenerateDuplicatesReport(duplicatesBarcodesBdoList);
    }

    private void DuplicatesWithinAQBatches()
    {
      List<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdoList = new List<ForDuplicatesBarcodesBDO>();
      foreach (IEnumerable<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdos in BatchRecords.GroupBy<ForDuplicatesBarcodesBDO, long>((Func<ForDuplicatesBarcodesBDO, long>) (x => x.Barcode)).Where<IGrouping<long, ForDuplicatesBarcodesBDO>>((Func<IGrouping<long, ForDuplicatesBarcodesBDO>, bool>) (g => g.Count<ForDuplicatesBarcodesBDO>() > 1)).Select<IGrouping<long, ForDuplicatesBarcodesBDO>, IGrouping<long, ForDuplicatesBarcodesBDO>>((Func<IGrouping<long, ForDuplicatesBarcodesBDO>, IGrouping<long, ForDuplicatesBarcodesBDO>>) (g => g)))
      {
        foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in duplicatesBarcodesBdos)
        {
          duplicatesBarcodesBdo.Reason = "Duplicate Barcode in QA Batches";
          duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
        }
      }
      foreach (IEnumerable<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdos in BatchRecords.GroupBy<ForDuplicatesBarcodesBDO, long>((Func<ForDuplicatesBarcodesBDO, long>) (x => x.RefNo)).Where<IGrouping<long, ForDuplicatesBarcodesBDO>>((Func<IGrouping<long, ForDuplicatesBarcodesBDO>, bool>) (g => g.Count<ForDuplicatesBarcodesBDO>() > 1)).Select<IGrouping<long, ForDuplicatesBarcodesBDO>, IGrouping<long, ForDuplicatesBarcodesBDO>>((Func<IGrouping<long, ForDuplicatesBarcodesBDO>, IGrouping<long, ForDuplicatesBarcodesBDO>>) (g => g)).ToList<IGrouping<long, ForDuplicatesBarcodesBDO>>())
      {
        foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in duplicatesBarcodesBdos)
        {
          duplicatesBarcodesBdo.Reason = "Duplicate NBT numbers in AQ Batches";
          duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
        }
      }
      foreach (IEnumerable<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdos in BatchRecords.Where<ForDuplicatesBarcodesBDO>((Func<ForDuplicatesBarcodesBDO, bool>) (x => x.SAID.HasValue)).GroupBy<ForDuplicatesBarcodesBDO, long?>((Func<ForDuplicatesBarcodesBDO, long?>) (x => x.SAID)).Where<IGrouping<long?, ForDuplicatesBarcodesBDO>>((Func<IGrouping<long?, ForDuplicatesBarcodesBDO>, bool>) (g => g.Count<ForDuplicatesBarcodesBDO>() > 1)).Select<IGrouping<long?, ForDuplicatesBarcodesBDO>, IGrouping<long?, ForDuplicatesBarcodesBDO>>((Func<IGrouping<long?, ForDuplicatesBarcodesBDO>, IGrouping<long?, ForDuplicatesBarcodesBDO>>) (g => g)).ToList<IGrouping<long?, ForDuplicatesBarcodesBDO>>())
      {
        foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in duplicatesBarcodesBdos)
        {
          duplicatesBarcodesBdo.Reason = "Duplicate SA IDs in QA Batches";
          duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
        }
      }
      foreach (IEnumerable<ForDuplicatesBarcodesBDO> duplicatesBarcodesBdos in BatchRecords.Where<ForDuplicatesBarcodesBDO>((Func<ForDuplicatesBarcodesBDO, bool>) (x => x.FID.Trim() != "")).GroupBy<ForDuplicatesBarcodesBDO, string>((Func<ForDuplicatesBarcodesBDO, string>) (x => x.FID)).Where<IGrouping<string, ForDuplicatesBarcodesBDO>>((Func<IGrouping<string, ForDuplicatesBarcodesBDO>, bool>) (g => g.Count<ForDuplicatesBarcodesBDO>() > 1)).Select<IGrouping<string, ForDuplicatesBarcodesBDO>, IGrouping<string, ForDuplicatesBarcodesBDO>>((Func<IGrouping<string, ForDuplicatesBarcodesBDO>, IGrouping<string, ForDuplicatesBarcodesBDO>>) (x => x)).ToList<IGrouping<string, ForDuplicatesBarcodesBDO>>())
      {
        foreach (ForDuplicatesBarcodesBDO duplicatesBarcodesBdo in duplicatesBarcodesBdos)
        {
          duplicatesBarcodesBdo.Reason = "Duplicate Foreign IDs in QA Batches";
          duplicatesBarcodesBdoList.Add(duplicatesBarcodesBdo);
        }
      }
      if (duplicatesBarcodesBdoList.Count<ForDuplicatesBarcodesBDO>() > 0)
      {
        HasDuplicates = true;
        duplicatesBarcodesBdoList.Count<ForDuplicatesBarcodesBDO>();
        GenerateDuplicatesReport(duplicatesBarcodesBdoList);
      }
      else
        HasDuplicates = false;
    }

    private void GenerateDuplicatesReport(List<ForDuplicatesBarcodesBDO> Duplicates)
    {
      string messageBoxText = "There are " + Duplicates.Count<ForDuplicatesBarcodesBDO>().ToString() + " duplicate records in the (batches) QA folder. " + "See generated report in folder " + " Please re-run option after corrections";
      if (!_service.DuplicateReportGeneration(Duplicates, Duplicatefile))
        return;
      if (Duplicates.Count<ForDuplicatesBarcodesBDO>() == 0)
      {
        int num1 = (int) MessageBox.Show("No duplicate records!");
      }
      else
      {
        int num2 = (int) MessageBox.Show(messageBoxText);
      }
    }

    private void ReadBarcodes()
    {
      foreach (QADatRecord qaRecord in (Collection<QADatRecord>) QARecords)
        BatchRecords.Add(new ForDuplicatesBarcodesBDO()
        {
          Barcode = Convert.ToInt64(qaRecord.Barcode),
          RefNo = Convert.ToInt64(qaRecord.Reference),
          SAID = !(qaRecord.SAID.Trim() != "") ? new long?() : new long?(Convert.ToInt64(qaRecord.SAID)),
          FID = qaRecord.ForeignID.Trim(),
          Batch = qaRecord.DatFile.SName,
          RecID = new long?(-1L),
          DateModified = DateTime.Now,
          Reason = ""
        });
    }

    private void ReadQARecs()
    {
      foreach (datFileAttributes afile in (Collection<datFileAttributes>) DirList)
      {
        SelectedFile = afile;
        GetQAData();
        ReadBarcodes();
      }
    }

    private bool IsDataClean()
    {
      bool flag = true;
      foreach (datFileAttributes dir in (Collection<datFileAttributes>) DirList)
      {
        if (dir.NoOfErrors > 0)
          flag = false;
      }
      return flag;
    }

    private void AddSurname()
    {
      string surname = SelectedQARecord.Surname;
      if (!_service.AddSurnameToList(surname))
        return;
      int num = (int) ModernDialog.ShowMessage(surname + " Has been Added to Database", "Add Surname", MessageBoxButton.OK, (Window) null);
    }

    private void AddName()
    {
      string firstName = SelectedQARecord.FirstName;
      if (!_service.AddNameToList(firstName))
        return;
      int num = (int) ModernDialog.ShowMessage(firstName + " Has been Added to Database", "Add Name", MessageBoxButton.OK, (Window) null);
    }

    private void updateTracker()
    {
      foreach (datFileAttributes dir in (Collection<datFileAttributes>) DirList)
      {
        int Count = File.ReadAllLines(dir.FilePath).Length - 1;
        string sname = dir.SName;
        if (!_service.updateQAtoTracker(sname, Count))
        {
          int num = (int) ModernDialog.ShowMessage("Batch was not recorded on tracker!!!", sname, MessageBoxButton.OK, (Window) null);
        }
      }
    }

    private void ProcessRawScores()
    {
      _service.SaveRawCSXData();
    }

    private void GetDOBfromDB()
    {
      SelectedQARecord = _service.GetDOBfromDB(SelectedQARecord);
    }

    private void AutoClean()
    {
      _service.AutoClean();
    }

    private void Refresh()
    {
      Folder = ApplicationSettings.Default.QAFolder;
      Selectfolder();
    }

    private void GetIDfromDB()
    {
      if (!(SelectedQARecord.Reference.Substring(7, 1) != "9"))
        return;
      SelectedQARecord = _service.GetSAIDbyNBT(SelectedQARecord);
      SelectedQARecord = _service.GetFIDbyNBT(SelectedQARecord);
    }

    private void Selectfolder()
    {
      List<datFileAttributes> source = new List<datFileAttributes>();
      try
      {
        foreach (FileSystemInfo file in new DirectoryInfo(Folder).GetFiles("*.dat"))
        {
          datFileAttributes datFileAttributes = new datFileAttributes(file.FullName);
          SelectedFile = datFileAttributes;
          GetQAData();
          datFileAttributes.NoOfErrors = QARecords.Sum<QADatRecord>((Func<QADatRecord, int>) (x => x.errorCount));
          source.Add(datFileAttributes);
          SelectedFile = (datFileAttributes) null;
        }
        DirList = new ObservableCollection<datFileAttributes>(source.OrderByDescending(m => m.NoOfErrors));
      }
      catch (Exception ex)
      {
        int num = (int) ModernDialog.ShowMessage(ex.ToString(), "Update", MessageBoxButton.OK, (Window) null);
      }
    }

    private void GetQAData()
    {
      QARecords = new ObservableCollection<QADatRecord>(_service.GetQADataFromFile(SelectedFile).OrderByDescending(a => a.errorCount));
    }

    private void GetNBTNumber()
    {
      if (string.IsNullOrEmpty(SelectedQARecord.ForeignID))
        SelectedQARecord = _service.GetNBTNumberFromDBbySAID(SelectedQARecord);
      else
        SelectedQARecord = _service.GetNBTNumberFromDBbyFID(SelectedQARecord);
    }

    private void GetNamesfromDB()
    {
      SelectedQARecord = _service.GetNamebyNBT(SelectedQARecord);
      SelectedQARecord = _service.GetSurnamebyNBT(SelectedQARecord);
    }

    private void SaveDatFile()
    {
      string message = "";
      if (_service.SaveQADatFile(SelectedFile, ref message))
      {
        DirList.Remove(SelectedFile);
        message = "File successfully saved";
        SelectedFile = (datFileAttributes) null;
        QARecords.Clear();
      }
      else
      {
        int num = (int) ModernDialog.ShowMessage(message, "Save Error !!", MessageBoxButton.OK, (Window) null);
      }
      Status = message;
    }

    private void LoadTestDate(DateTime mydate)
    {
      _service.LoadTestDate(_myDOT);
    }
  }
}
