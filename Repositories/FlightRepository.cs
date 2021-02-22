using System.Collections.Generic;
using System.Data;
using Dapper;
using vaca.Models;

namespace vaca.Repositories
{
    public class FlightRepository
    {
    public readonly IDbConnection _db;

    public FlightRepository(IDbConnection db)
    {
      _db = db;
    }
    //NOTE dotnet add package dapper - to be able to communicate with db
    public IEnumerable<Flight> GetAll()
    {
      string sql = "SELECT * FROM Flights;";
      return _db.Query<Flight>(sql);
    }

    internal Flight GetById(int id)
    {
      string sql = "SELECT * FROM Flights WHERE id = @id;";
      return _db.QueryFirstOrDefault<Flight>(sql, new { id });
    }


    internal Flight Create(Flight newFlight)
    {
      string sql = @"
            INSERT INTO Flights
            (title, description, price)
            VALUES
            (@Title, @Description, @Price);
            SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newFlight);
      newFlight.Id = id;
      return newFlight;
    }



    internal void Delete(Flight Flight)
    {
      string sql = "DELETE FROM Flights WHERE id = @Id";
      _db.Execute(sql, Flight);
    }

    internal Flight Edit(Flight original)
    {
      string sql = @"
        UPDATE Flights
        SET
            description = @Description,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM Flights WHERE id = @Id;";
      return _db.QueryFirstOrDefault<Flight>(sql, original);
    }
  }
}