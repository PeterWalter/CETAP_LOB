﻿// Decompiled with JetBrains decompiler
// Type: LOB.BDO.ScoreStats
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

namespace CETAP_LOB.BDO
{
  public class ScoreStats
  {
    public string Filename { get; set; }

    public string type { get; set; }

    public int Records { get; set; }

    public int Min { get; set; }

    public int Max { get; set; }

    public double stdDev { get; set; }

    public double Mean { get; set; }

    public double FirstQuantile { get; set; }

    public double ThirdQuantile { get; set; }

    public double Median { get; set; }
  }
}
