using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vaca.Models;
using vaca.Interfaces;
using vaca.Services;

namespace vaca.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BookableController : ControllerBase
  {
    private readonly VacationService _service;

    public BookableController(VacationService service)
    {
      _service = service;
    }
    [HttpGet("vacation")]
    public ActionResult<IEnumerable<Vacation>> GetAll()
    {
      try
      {
        var data = _service.getAll();
        return Ok(data);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<IBookable>> GetAllPurchasable()
    {
      try
      {
        var data = _service.getAll();
        return Ok(data);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}