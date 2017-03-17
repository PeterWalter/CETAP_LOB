// Decompiled with JetBrains decompiler
// Type: LOB.Model.venueprep.WebWriterMap
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.Linq.Expressions;

namespace CETAP_LOB.Model.venueprep
{
  public sealed class WebWriterMap : CsvClassMap<WebWriters>
  {
    public override void CreateMap()
    {
      Map((Expression<Func<WebWriters, object>>) (m => m.Reference)).Index(0);
      Map((Expression<Func<WebWriters, object>>) (m => m.Surname)).Index(1);
      Map((Expression<Func<WebWriters, object>>) (m => m.FirstName)).Name("First Name");
      Map((Expression<Func<WebWriters, object>>) (m => m.initials)).Index(3);
      Map((Expression<Func<WebWriters, object>>) (m => m.SAID)).Index(4);
      Map((Expression<Func<WebWriters, object>>) (m => m.ForeignID)).Index(5);
      Map((Expression<Func<WebWriters, object>>) (m => (object) m.DOB)).Index(6).TypeConverterOption(DateTimeStyles.AdjustToUniversal);
      Map((Expression<Func<WebWriters, object>>) (m => m.Gender)).Index(7);
      Map((Expression<Func<WebWriters, object>>) (m => m.Classification)).Index(8);
      Map((Expression<Func<WebWriters, object>>) (m => m.Tests)).Index(9);
      Map((Expression<Func<WebWriters, object>>) (m => m.Language)).Index(10);
      Map((Expression<Func<WebWriters, object>>) (m => m.Venue)).Index(11);
      Map((Expression<Func<WebWriters, object>>) (m => (object) m.DOT)).Index(12).TypeConverterOption(DateTimeStyles.AdjustToUniversal);
      Map((Expression<Func<WebWriters, object>>) (m => m.Mobile)).Index(13);
      Map((Expression<Func<WebWriters, object>>) (m => m.HTelephone)).Index(14);
      Map((Expression<Func<WebWriters, object>>) (m => m.Email)).Index(15);
      Map((Expression<Func<WebWriters, object>>) (m => (object) m.RegDate)).Index(16);
      Map((Expression<Func<WebWriters, object>>) (m => (object) m.Paid)).Index(17);
      Map((Expression<Func<WebWriters, object>>) (m => (object) m.CreationDate)).Index(18);
    }
  }
}
