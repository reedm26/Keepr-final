using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    internal Keep GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    internal Keep Create(Keep KeepData)
    {
      _repo.Create(KeepData);
      return KeepData;
    }

    internal object Edit(Keep update)
    {
      throw new NotImplementedException();
    }


    internal Keep Delete(int id)
    {
      var exists = _repo.Delete(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return exists;

    }


  }
}