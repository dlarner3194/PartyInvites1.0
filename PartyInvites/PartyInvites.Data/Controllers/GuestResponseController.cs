using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyInvites.Data.Controllers
{
  [Route("api/[controller]")]
  //[ApiController]
  public class GuestResponseController : ControllerBase
  {
    private readonly GuestResponseContext _context;

    public GuestResponseController(GuestResponseContext context)
    {
      _context = context;

      if(_context.GuestResponses.Count() == 0)
      {
        _context.GuestResponses.Add(new GuestResponse { Name = "Daniel" });
        _context.SaveChanges();
      }
    }

    // GET: api/<controller>
    //[HttpGet]
    //public ActionResult<List<GuestResponse>> GetAll()
    //{
    //  return _context.GuestResponses.ToList();
    //}
  }
}
