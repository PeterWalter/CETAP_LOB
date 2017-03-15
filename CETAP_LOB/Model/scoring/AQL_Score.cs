// Decompiled with JetBrains decompiler
// Type: LOB.Model.scoring.AQL_Score
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

namespace CETAP_LOB.Model.scoring
{
  public class AQL_Score
  {
    private long _id;
    private int? al;
    private int? ql;

    public long ID
    {
      get
      {
        return this._id;
      }
      set
      {
        this._id = value;
      }
    }

    public int? AL
    {
      get
      {
        return this.al;
      }
      set
      {
        this.al = value;
      }
    }

    public int? QL
    {
      get
      {
        return this.ql;
      }
      set
      {
        this.ql = value;
      }
    }
  }
}
