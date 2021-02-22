using System.Collections.Generic;
using System.Data;
using Dapper;
using vaca.Models;

namespace vaca.Repositories
{
    public class CruiseRepository
    {
    public readonly IDbConnection _db;

    public CruiseRepository(IDbConnection db)
    {
      _db = db;
    }
    //NOTE dotnet add package dapper - to be able to communicate with db
    public IEnumerable<Cruise> GetAll()
    {
      string sql = "SELECT * FROM Cruises;";
      return _db.Query<Cruise>(sql);
    }

    internal Cruise GetById(int id)
    {
      string sql = "SELECT * FROM Cruises WHERE id = @id;";
      return _db.QueryFirstOrDefault<Cruise>(sql, new { id });
    }


    internal Cruise Create(Cruise newCruise)
    {
      string sql = @"
            INSERT INTO Cruises
            (title, description, price)
            VALUES
            (@Title, @Description, @Price);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newCruise);
      newCruise.Id = id;
      return newCruise;
    }



    internal void Delete(Cruise Cruise)
    {
      string sql = "DELETE FROM Cruises WHERE id = @Id";
      _db.Execute(sql, Cruise);
    }

    internal Cruise Edit(Cruise original)
    {
      string sql = @"
        UPDATE Cruises
        SET
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM Cruises WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Cruise>(sql, original);
    }
  }
}