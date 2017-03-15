// Decompiled with JetBrains decompiler
// Type: LOB.ViewModel.scoring.MatViewModel
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using GalaSoft.MvvmLight;
using CETAP_LOB.BDO;
using CETAP_LOB.Model;
using CETAP_LOB.Model.scoring;
using System.Collections.ObjectModel;

namespace CETAP_LOB.ViewModel.scoring
{
  public class MatViewModel : ViewModelBase
  {
    public const string MATStatsPropertyName = "MATStats";
    public const string MATPropertyName = "MAT";
    private ObservableCollection<ScoreStats> _mymatstats;
    private ObservableCollection<MAT_Score> _myMAT;
    private IDataService _service;

    public ObservableCollection<ScoreStats> MATStats
    {
      get
      {
        return this._mymatstats;
      }
      set
      {
        if (this._mymatstats == value)
          return;
        this._mymatstats = value;
        this.RaisePropertyChanged("MATStats");
      }
    }

    public ObservableCollection<MAT_Score> MAT
    {
      get
      {
        return this._myMAT;
      }
      set
      {
        if (this._myMAT == value)
          return;
        this._myMAT = value;
        this.RaisePropertyChanged("MAT");
      }
    }

    public MatViewModel(IDataService Service)
    {
      this._service = Service;
      this.Refresh();
    }

    private void Refresh()
    {
      this.MAT = this._service.LoadMATScores();
      this.MATStats = this._service.GetMATStats();
    }
  }
}
