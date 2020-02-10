using System;
using System.Collections.Generic;
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
      Keep exists = GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    internal Keep Create(Keep KeepData)
    {
      _repo.Create(KeepData);
      return KeepData;
    }

    internal Keep Edit(Keep Update)
    {
      var exists = _repo.GetById(Update.Id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      if (exists.UserId != Update.UserId) { throw new Exception("You cannot do that because you arent the creator!"); }
      return _repo.Edit(Update);
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