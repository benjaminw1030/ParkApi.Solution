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
    ///     GET /api/parks
    ///
    /// </remarks>
    /// <param name="name"></param>
    /// <returns>A specific list of parks with part or all of that name.</returns>
    /// <param name="category"></param>
    /// <returns>A specific list of parks with part or all of that category.</returns>
    /// <param name="state"></param>
    /// <returns>A specific list of parks with part or all of that state.</returns>
    /// <response code="201">Returns valid parks</response>
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

    /// <summary>
    /// Posts a new park.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/parks
    /// {
    ///     "name": "Silver Falls",
    ///     "category": "State",
    ///     "state": "Oregon",
    ///     "longitude": -122.65,
    ///     "latitude": 44.85,
    ///     "area": 36,
    ///     "visitors": 1100000,
    ///     "estDate": "1933-07-23T00:00:00"
    /// }
    ///
    /// </remarks>
    /// <response code="201">Returns created park</response>
    /// <response code="400">If there is a validation error</response>   
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    /// <summary>
    /// Gets a specific park at an ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /api/parks/1
    ///
    /// </remarks>
    /// <response code="404">If park not found</response>   
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

    /// <summary>
    /// Edits a specific park at an ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///    PUT /api/parks/1
    /// {
    ///     "parkId": 1
    ///     "name": "Silver Falls",
    ///     "category": "State",
    ///     "state": "Oregon",
    ///     "longitude": -122.65,
    ///     "latitude": 44.85,
    ///     "area": 36,
    ///     "visitors": 1100000,
    ///     "estDate": "1933-07-23T00:00:00"
    /// }
    ///
    /// </remarks>
    /// <response code="400">If there is a validation error</response>   
    /// <response code="404">If park not found</response>   
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

    /// <summary>
    /// Edits a specific park at an ID (via PATCH).
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///    PATCH /api/parks/1
    /// {
    ///     "parkId": 1
    ///     "name": "Silver Falls",
    ///     "category": "State",
    ///     "state": "Oregon",
    ///     "longitude": -122.65,
    ///     "latitude": 44.85,
    ///     "area": 36,
    ///     "visitors": 1100000,
    ///     "estDate": "1933-07-23T00:00:00"
    /// }
    ///
    /// </remarks>
    /// <response code="400">If there is a validation error</response>   
    /// <response code="404">If park not found</response>   
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

    /// <summary>
    /// Deletes a specific park at an ID.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///    DELETE /api/parks/1
    ///
    /// </remarks>
    /// <response code="204">If park is deleted</response>   
    /// <response code="404">If park not found</response> 
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

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}