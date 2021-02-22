using System;
using System.Collections.Generic;
using vaca.Models;
using vaca.Repositories;

namespace vaca.Services
{
    public class FlightService
    {

    private readonly FlightRepository _repo;

    public FlightService(FlightRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Flight> Get()
    {
      return _repo.GetAll();
    }

    internal Flight Get(int id)
    {
      Flight Flight = _repo.GetById(id);
      if (Flight == null)
      {
        throw new Exception("invalid Id");
      }
      return Flight;
    }

    internal Flight Create(Flight newFlight)
    {
      return _repo.Create(newFlight);
    }

    internal Flight Edit(Flight editFlight)
    {
      Flight original = Get(editFlight.Id);

      original.Title = editFlight.Title != null ? editFlight.Title : original.Title;
      original.Description = editFlight.Description != null ? editFlight.Description : original.Description;
      original.Price = editFlight.Price > 0 ? editFlight.Price : original.Price;

      return _repo.Edit(original);


    }

    internal Flight Delete(int id)
    {

      Flight Flight = Get(id);
      _repo.Delete(Flight);
      return Flight;
    }
  }
}