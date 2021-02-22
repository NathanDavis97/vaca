using System.Collections.Generic;
using System.Data;
using Dapper;
using vaca.Models;

namespace vaca.Repositories
{
    public class VacationRepository
    {
    public readonly IDbConnection _db;

    public VacationRepository(IDbConnection db)
    {
      _db = db;
    }
    //NOTE dotnet add package dapper - to be able to communicate with db
    public IEnumerable<Vacation> GetAll()
    {
      string sql = "SELECT * FROM cruises, flights;";
      return _db.Query<Vacation>(sql);
    }
  }
}