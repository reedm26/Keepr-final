using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;
namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId, int keepId)
    {
      string sql = "SELECT k.* FROM vaultkeeps vk INNER JOIN keeps k ON k.Id = vk.KeepId WHERE (vk.VaultId = @vaultId AND vk.UserId = @userId);";
      return _db.Query<Keep>(sql, new { vaultId, keepId });
    }
    internal VaultKeep GetById(int vaultId, int keepId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (VaultId = @vaultId AND KeepId = @keepId);";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
    }
    internal VaultKeep Find(int vaultId, int keepId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (KeepId = @keepId AND VaultId =@vaultId);";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { keepId, vaultId });
    }
    internal VaultKeep Create(VaultKeep vaultKeepData)
    {
      string sql = @"INSERT INTO vaultkeeps (userId, keepId, vaultId) VALUES (@UserId, @KeepId, @VaultId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
      vaultKeepData.Id = id;
      return vaultKeepData;
    }


    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}