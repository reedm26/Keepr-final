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

    internal void Create(VaultKeep vaultKeepData)
    {
      var exists = _repo.Find(vaultKeepData.KeepId, vaultKeepData.VaultId);
      if (exists != null)
      {
        throw new Exception("You already got one of these");
      }
      _repo.Create(vaultKeepData);
    }

    internal string Delete(int vaultId, int keepId, string userId)
    {
      var exists = _repo.GetById(vaultId, keepId);
      if (exists == null) { throw new Exception("Invalid Id Delete"); }
      else if (exists.UserId != userId) { throw new Exception("This isnt yours, so you cant delete it!"); }
      _repo.Delete(exists.Id);
      return "This thing is gone!";
    }
  }
}