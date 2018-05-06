using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Data.Models
{
  public class GuestResponseContext : DbContext
  {
    public GuestResponseContext(DbContextOptions<GuestResponseContext> options)
      : base(options)
    {
    }

    public DbSet<GuestResponse> GuestResponses { get; set; }
  }
}
