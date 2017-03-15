// Decompiled with JetBrains decompiler
// Type: LOB.Search.BatchResultsProvider
// Assembly: LOB, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3597789E-8774-4427-AE20-07195D9380BD
// Assembly location: C:\Program Files (x86)\CETAP LOB\LOB.exe

using FeserWard.Controls;
using CETAP_LOB.BDO;
using CETAP_LOB.Database;
using CETAP_LOB.Mapping;
using CETAP_LOB.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CETAP_LOB.Search
{
  public class BatchResultsProvider : IIntelliboxResultsProvider
  {
    private List<BatchBDO> _results;
    private IDataService _service;

    public BatchResultsProvider(IDataService Service)
    {
      this._service = Service;
    }

    public IEnumerable DoSearch(string searchTerm, int maxResults, object extraInfo)
    {
      this._results = new List<BatchBDO>();
      if (ApplicationSettings.Default.DBAvailable)
      {
        using (CETAPEntities cetapEntities = new CETAPEntities())
        {
          foreach (Batch batch in cetapEntities.Batches.ToList<Batch>().Where<Batch>((Func<Batch, bool>) (p =>
          {
            if (!p.BatchName.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase))
              return p.BatchedBy.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase);
            return true;
          })).Cast<object>())
          {
            BatchBDO batchBdo = new BatchBDO();
            this._results.Add(Maps.BatchDALToBatchBDO(batch));
          }
        }
      }
      return (IEnumerable) this._results;
    }
  }
}
