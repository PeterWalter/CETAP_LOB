// Decompiled with JetBrains decompiler
// Type: LOB.Helper.ListSurnames
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using CETAP_LOB.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LOB.Helper
{
  public static class ListSurnames
  {
    private static List<string> _lastnames = new List<string>();
    private static string _surname;
    private static bool _found;

    public static bool IsFound
    {
      get
      {
        return ListSurnames._found;
      }
    }

    public static string surname
    {
      get
      {
        return ListSurnames._surname;
      }
      set
      {
        ListSurnames._surname = value;
        ListSurnames.isAvailable();
      }
    }

    static ListSurnames()
    {
      using (CETAPEntities cetapEntities = new CETAPEntities())
        ListSurnames._lastnames = cetapEntities.Surnames.Select<Surname, string>((Expression<Func<Surname, string>>) (x => x.Surname1)).ToList<string>();
    }

    public static void AddSurname(string name)
    {
      ListSurnames._lastnames.Add(name.Trim());
    }

    private static void isAvailable()
    {
      ListSurnames._found = ListSurnames._lastnames.Any<string>((Func<string, bool>) (a => a == ListSurnames._surname));
    }
  }
}
