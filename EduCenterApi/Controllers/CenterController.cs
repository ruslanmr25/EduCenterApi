using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Infrastructure.DatabaseContext;

namespace EduCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly BaseContext _context;

        public CenterController(BaseContext context)
        {
            _context = context;
        }

        // GET: api/Center
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Center>>> GetCenters()
        {
            return await _context.Centers.ToListAsync();
        }

        // GET: api/Center/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Center>> GetCenter(int id)
        {
            var center = await _context.Centers.FindAsync(id);

            if (center == null)
            {
                return NotFound();
            }

            return center;
        }

        // PUT: api/Center/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCenter(int id, Center center)
        {
            if (id != center.Id)
            {
                return BadRequest();
            }

            _context.Entry(center).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterExists(id))
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

        // POST: api/Center
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Center>> PostCenter(Center center)
        {
            _context.Centers.Add(center);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCenter", new { id = center.Id }, center);
        }

        // DELETE: api/Center/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }

            _context.Centers.Remove(center);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CenterExists(int id)
        {
            return _context.Centers.Any(e => e.Id == id);
        }
    }
}
