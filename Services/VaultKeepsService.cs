using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {

    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository vkr)
    {
      _repo = vkr;
    }
    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, string userId)
    {
      var exists = _repo.GetKeepsByVaultId(vaultId, userId);
      if (exists == null) { throw new Exception("Invalid Id for this Vault"); }
      return exists;
    }

    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      _repo.Create(vaultKeepData);
      return vaultKeepData;
    }

    internal string Delete(int vaultId, int keepId, string userId)
    {
      var exists = _repo.GetById(vaultId, keepId);
      if (exists == null) { throw new Exception("Invalid Id"); }
      else if (exists.UserId != userId) { throw new Exception("That isnt yours, so you cant delete it!"); }
      _repo.Delete(exists.Id);
      return "This thing is gone!";
    }
  }
}