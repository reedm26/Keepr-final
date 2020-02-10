using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpGet("{id}")]

    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_ks.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]

    public ActionResult<Keep> Edit([FromBody] Keep update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_ks.Edit(update));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]

    public ActionResult<Keep> Post([FromBody] Keep KeepData)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        KeepData.UserId = userId;
        return Ok(_ks.Create(KeepData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}