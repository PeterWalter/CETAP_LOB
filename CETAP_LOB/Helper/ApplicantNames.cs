// Decompiled with JetBrains decompiler
// Type: LOB.Helper.ApplicantNames
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CETAP_LOB.Helper
{
  public static class ApplicantNames
  {
    private static List<string> _writernames = new List<string>();
    private static string _name;
    private static bool _found;

    public static bool IsFound
    {
      get
      {
        return ApplicantNames._found;
      }
    }

    public static string FirstName
    {
      get
      {
        return ApplicantNames._name;
      }
      set
      {
        ApplicantNames._name = value;
        ApplicantNames.isAvailable();
      }
    }

    static ApplicantNames()
    {
      using (CETAPEntities cetapEntities = new CETAPEntities())
        ApplicantNames._writernames = cetapEntities.FirstNames.Select<LOB.Database.FirstName, string>((Expression<Func<LOB.Database.FirstName, string>>) (x => x.Name)).ToList<string>();
    }

    public static void AddName(string name)
    {
      ApplicantNames._writernames.Add(name.Trim());
    }

    private static void isAvailable()
    {
      ApplicantNames._found = ApplicantNames._writernames.Any<string>((Func<string, bool>) (a => a == ApplicantNames._name));
    }
  }
}
