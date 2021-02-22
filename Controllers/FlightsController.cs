using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vaca.Models;
using vaca.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace vaca.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FlightsController : ControllerBase
  {
    private readonly FlightService _service;

    public FlightsController(FlightService ins)
    {
      _service = ins;
    }

    [HttpGet("{id}")]
    public ActionResult<Flight> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Flight> Create([FromBody] Flight newIng)
    {
      try
      {
        return Ok(_service.Create(newIng));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Flight> Edit([FromBody] Flight updated, int id)
    {
      try
      {
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Flight> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}