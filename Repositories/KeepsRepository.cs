using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal object GetById(int id)
    {
      string sql = "SELECT * FROM students";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }



    internal void Edit(Keep update)
    {
      string sql = @"
        UPDATE keeps 
        SET
        name =@Name,
        WHERE id = @Id;
        ";
      _db.Execute(sql, update);
    }
    internal Keep Create(Keep KeepData)
    {
      string sql = @"
     INSERT INTO Keeps 
     (name)
     VALUES
     (@Name);
     SELECT LAST_INSERT_ID();
     ";
      int id = _db.ExecuteScalar<int>(sql, KeepData);
      KeepData.Id = id;
      return KeepData;
    }


    internal void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}