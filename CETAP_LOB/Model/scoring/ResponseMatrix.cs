// Decompiled with JetBrains decompiler
// Type: LOB.Model.scoring.ResponseMatrix
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

namespace CETAP_LOB.Model.scoring
{
  public class ResponseMatrix : ModelBase
  {
    public const string BarcodePropertyName = "Barcode";
    public const string ResponsesPropertyName = "Responses";
    private long _barcode;
    private string[] _response;

    public long Barcode
    {
      get
      {
        return this._barcode;
      }
      set
      {
        if (this._barcode == value)
          return;
        this._barcode = value;
        this.RaisePropertyChanged("Barcode");
      }
    }

    public string[] Responses
    {
      get
      {
        return this._response;
      }
      set
      {
        if (this._response == value)
          return;
        this._response = value;
        this.RaisePropertyChanged("Responses");
      }
    }
  }
}
