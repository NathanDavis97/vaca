using System;
using System.Collections.Generic;
using vaca.Models;
using vaca.Repositories;

namespace vaca.Services
{
    public class CruiseService
    {

    private readonly CruiseRepository _repo;

    public CruiseService(CruiseRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Cruise> Get()
    {
      return _repo.GetAll();
    }

    internal Cruise Get(int id)
    {
      Cruise Cruise = _repo.GetById(id);
      if (Cruise == null)
      {
        throw new Exception("invalid Id");
      }
      return Cruise;
    }

    internal Cruise Create(Cruise newCruise)
    {
      return _repo.Create(newCruise);
    }

    internal Cruise Edit(Cruise editCruise)
    {
      Cruise original = Get(editCruise.Id);

      original.Title = editCruise.Title != null ? editCruise.Title : original.Title;
      original.Description = editCruise.Description != null ? editCruise.Description : original.Description;
      original.Price = editCruise.Price > 0 ? editCruise.Price : original.Price;

      return _repo.Edit(original);


    }

    internal Cruise Delete(int id)
    {

      Cruise Cruise = Get(id);
      _repo.Delete(Cruise);
      return Cruise;
    }
  }
}