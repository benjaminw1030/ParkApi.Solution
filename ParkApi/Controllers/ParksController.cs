using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkApi.Models;
using System.Linq;

namespace ParkApi.AddControllers
{
  [Produces("application/json")]
  [Route("api/[Controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParkApiContext _db;
    public ParksController(ParkApiContext db)
    {
      _db = db;
    }

    // GET api/parks
    /// <summary>
    /// Gets parks utilizing a query of name, category or state.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /Group
    ///     {
    ///        "id": 1,
    ///        "name": "Group1",
    ///        "messages": []
    ///     }
    ///
    /// </remarks>
    /// <param name="name"></param>
    /// <returns>A specific list of groups with that name.</returns>
    /// <response code="201">Returns the groups</response>
    /// <response code="400">If the item is null</response>   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string name, string category, string state)
    {
      var query = _db.Parks.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      if (category != null)
      {
        query = query.Where(entry => entry.Category.Contains(category));
      }
      if (state != null)
      {
        query = query.Where(entry => entry.State.Contains(state));
      }
      return await query.ToListAsync();
    }

    // POST api/parks
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      return park;
    }

    // PUT: api/parks/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Park>> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }
      _db.Entry(park).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    // PUT: api/parks/5
    [HttpPatch("{id}")]
    public async Task<ActionResult<Park>> Patch(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }
      _db.Entry(park).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    // DELETE: api/parks/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    // PATCH: api/parks/5
    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}