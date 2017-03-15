// Decompiled with JetBrains decompiler
// Type: LOB.Model.scoring.MAT_Score
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

namespace CETAP_LOB.Model.scoring
{
  public class MAT_Score
  {
    private long _id;
    private int? mat;

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

    public int? MAT
    {
      get
      {
        return this.mat;
      }
      set
      {
        this.mat = value;
      }
    }
  }
}
