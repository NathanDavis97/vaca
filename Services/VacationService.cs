
       using System;
using System.Collections.Generic;
using vaca.Models;
using vaca.Repositories;
namespace vaca.Services
{
    public class VacationService
  {
    private readonly VacationRepository _repo;

    public VacationService(VacationRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Vacation> getAll()
    {
      return _repo.GetAll();
    }
  }
}