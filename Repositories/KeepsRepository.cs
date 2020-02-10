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
      string sql = "SELECT * FROM keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }


    internal object GetById(int id)
    {
      string sql = "SELECT * FROM keeps";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }



    // internal void Edit(Keep Update)
    // {
    //   string sql = @"
    //     UPDATE keeps 
    //     SET
    //     name =@Name,
    //     WHERE id = @Id;
    //     ";
    //   _db.Execute(sql, Update);
    // }
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

    internal void Edit(Keep Update)
    {
      string sql = @"
        UPDATE keeps 
        SET
        name =@Name,
         WHERE id = @Id;
         ";
      _db.Execute(sql, Update);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM Keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}