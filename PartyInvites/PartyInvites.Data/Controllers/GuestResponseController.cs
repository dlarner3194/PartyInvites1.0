using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Data.Models;

namespace PartyInvites.Data.Controllers
{
  [Route("api/[controller]")]
  public class GuestResponseController : Controller
  {
    private readonly GuestResponseContext _context;

    public GuestResponseController(GuestResponseContext context)
    {
      _context = context;

      if (_context.GuestResponses.Count() == 0)
      {
        _context.GuestResponses.Add(new GuestResponse { Name = "Daniel" });
        _context.SaveChanges();
      }
    }

    [HttpGet(Name = "GetList")]
    public List<GuestResponse> GetAll()
    {
      return _context.GuestResponses.ToList();
    }

    [HttpGet("{id}", Name = "GetResponse")]
    public IActionResult GetById(int id)
    {
      var response = _context.GuestResponses.Find(id);
      if (response == null)
      {
        return NotFound();
      }
      return Ok(response);
    }

    [HttpPost]
    public IActionResult Create([FromBody] GuestResponse guestResponse)
    {
      if (guestResponse == null)
      {
        return BadRequest();
      }

      _context.GuestResponses.Add(guestResponse);
      _context.SaveChanges();

      return CreatedAtRoute("GetResponse", new { id = guestResponse.Id }, guestResponse);
    }
  }
}
