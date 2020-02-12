using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository vr)
    {
      _repo = vr;
    }

    internal IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    internal Vault GetById(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    internal Vault Create(Vault vaultData)
    {
      _repo.Create(vaultData);
      return vaultData;
    }

    internal string Delete(int id)
    {
      var exists = _repo.GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
      return "Mamba Out";
    }
  }
}