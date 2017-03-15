// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.scoring.AnswerSheetBioViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using CETAP_LOB.Model;
using CETAP_LOB.Model.QA;
using CETAP_LOB.Model.scoring;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CETAP_LOB.ViewModel.scoring
{
  public class AnswerSheetBioViewModel : ViewModelBase
  {
    public const string SelectedRecordPropertyName = "SelectedRecord";
    public const string BIOPropertyName = "BIO";
    private AnswerSheetBio _myselectedrecord;
    private ObservableCollection<AnswerSheetBio> _bio;
    private IDataService _service;

    public RelayCommand GetNBTCommand { get; private set; }

    public RelayCommand GetNamesCommand { get; private set; }

    public RelayCommand GetIDCommand { get; private set; }

    public RelayCommand GetDOBCommand { get; private set; }

    public RelayCommand RefreshCommand { get; private set; }

    public RelayCommand AutoCorrectCommand { get; private set; }

    private QADatRecord QARecord { get; set; }

    public AnswerSheetBio SelectedRecord
    {
      get
      {
        return this._myselectedrecord;
      }
      set
      {
        if (this._myselectedrecord == value)
          return;
        this._myselectedrecord = value;
        this.RaisePropertyChanged("SelectedRecord");
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

    public AnswerSheetBioViewModel(IDataService Service)
    {
      this._service = Service;
      this.RegisterCommands();
      this.Refresh();
    }

    private void RegisterCommands()
    {
      this.GetNBTCommand = new RelayCommand(new Action(this.GetNBTNumber));
      this.GetNamesCommand = new RelayCommand(new Action(this.GetNamesfromDB));
      this.GetDOBCommand = new RelayCommand(new Action(this.GetDOBfromDB));
      this.GetIDCommand = new RelayCommand(new Action(this.GetIDfromDB));
      this.RefreshCommand = new RelayCommand(new Action(this.Refresh));
      this.AutoCorrectCommand = new RelayCommand(new Action(this.AutoCorrect));
    }

    private void Refresh()
    {
      this.BIO = this._service.LoadAnswerSheet();
    }

    private void AutoCorrect()
    {
      if (!ApplicationSettings.Default.DBAvailable)
        return;
      foreach (AnswerSheetBio ans in this.BIO.Where<AnswerSheetBio>((Func<AnswerSheetBio, bool>) (a => a.HasErrors)).ToList<AnswerSheetBio>())
      {
        bool flag = false;
        if (ans.NBT.ToString().Substring(7, 1) != "9")
          flag = true;
        if (flag)
        {
          List<string> list = ans._errors.Keys.ToList<string>();
          int count = list.Count;
          for (int index = 0; index < count; ++index)
          {
            switch (list[index])
            {
              case "SAID":
                if (ans.SAID != null || ans.SAID != "")
                {
                  QADatRecord qaDatRecord = new QADatRecord();
                  AnswerSheetBioViewModel.AnswersheetRecordToQARecord(ans, qaDatRecord);
                  this.QARecord = this._service.GetSAIDbyNBT(qaDatRecord);
                  AnswerSheetBioViewModel.QARecordToAnswersheetRecord(ans, this.QARecord);
                }
                if (ans.ForeignID != "")
                {
                  QADatRecord qaDatRecord = new QADatRecord();
                  AnswerSheetBioViewModel.AnswersheetRecordToQARecord(ans, qaDatRecord);
                  this.QARecord = this._service.GetFIDbyNBT(qaDatRecord);
                  AnswerSheetBioViewModel.QARecordToAnswersheetRecord(ans, this.QARecord);
                  break;
                }
                break;
            }
          }
        }
      }
    }

    private void GetDOBfromDB()
    {
      QADatRecord qaDatRecord = new QADatRecord();
      AnswerSheetBioViewModel.AnswersheetRecordToQARecord(this.SelectedRecord, qaDatRecord);
      this.QARecord = this._service.GetDOBfromDB(qaDatRecord);
      AnswerSheetBioViewModel.QARecordToAnswersheetRecord(this.SelectedRecord, this.QARecord);
    }

    private void GetIDfromDB()
    {
      if (!(this.SelectedRecord.NBT.ToString().Substring(7, 1) != "9"))
        return;
      QADatRecord qaDatRecord = new QADatRecord();
      AnswerSheetBioViewModel.AnswersheetRecordToQARecord(this.SelectedRecord, qaDatRecord);
      this.QARecord = this._service.GetSAIDbyNBT(qaDatRecord);
      this.QARecord = this._service.GetFIDbyNBT(qaDatRecord);
      AnswerSheetBioViewModel.QARecordToAnswersheetRecord(this.SelectedRecord, this.QARecord);
    }

    private void GetNBTNumber()
    {
      QADatRecord qaDatRecord = new QADatRecord();
      AnswerSheetBioViewModel.AnswersheetRecordToQARecord(this.SelectedRecord, qaDatRecord);
      this.QARecord = !string.IsNullOrEmpty(this.SelectedRecord.ForeignID) ? this._service.GetNBTNumberFromDBbyFID(qaDatRecord) : this._service.GetNBTNumberFromDBbySAID(qaDatRecord);
      AnswerSheetBioViewModel.QARecordToAnswersheetRecord(this.SelectedRecord, this.QARecord);
    }

    private void GetNamesfromDB()
    {
      QADatRecord qaDatRecord = new QADatRecord();
      AnswerSheetBioViewModel.AnswersheetRecordToQARecord(this.SelectedRecord, qaDatRecord);
      this.QARecord = this._service.GetNamebyNBT(qaDatRecord);
      this.QARecord = this._service.GetSurnamebyNBT(qaDatRecord);
      AnswerSheetBioViewModel.QARecordToAnswersheetRecord(this.SelectedRecord, this.QARecord);
    }

    private static void AnswersheetRecordToQARecord(AnswerSheetBio ans, QADatRecord QaDat)
    {
      QaDat.DOB = ans.DOB;
      QaDat.DOT = ans.DOT;
      QaDat.Reference = ans.NBT.ToString();
      QaDat.Barcode = ans.Barcode.ToString();
      QaDat.FirstName = ans.Name;
      QaDat.Surname = ans.Surname;
      QaDat.Gender = ans.Gender.ToString();
      QaDat.initials = ans.Initials;
      QaDat.ForeignID = ans.ForeignID;
      QaDat.SAID = ans.SAID;
    }

    private static void QARecordToAnswersheetRecord(AnswerSheetBio ans, QADatRecord QaDat)
    {
      ans.DOB = QaDat.DOB;
      ans.DOB = QaDat.DOB;
      ans.DOT = QaDat.DOT;
      ans.Barcode = Convert.ToInt64(QaDat.Barcode);
      ans.Name = QaDat.FirstName;
      ans.Surname = QaDat.Surname;
      ans.Gender = QaDat.Gender;
      ans.Initials = QaDat.initials;
      ans.ForeignID = QaDat.ForeignID;
      ans.NBT = Convert.ToInt64(QaDat.Reference);
      ans.SAID = QaDat.SAID;
    }
  }
}
