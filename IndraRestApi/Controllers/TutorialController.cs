using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndraRestApi.Data;
using IndraRestApi.Models;

namespace IndraRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {
        private readonly DataContext _context;

        public TutorialController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tutorial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutorial>>> GetTutorial(string titulo = null)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                return await _context.Tutorial.ToListAsync();
            }
            else {
                return await _context.Tutorial.Where(x=>x.Titulo.Contains(titulo)).ToListAsync();
            }
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutorial>> GetTutorial(int id)
        {
            var tutorial = await _context.Tutorial.FindAsync(id);

            if (tutorial == null)
            {
                return NotFound();
            }

            return tutorial;
        }

        // PUT: api/Tutorial/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutorial(int id, Tutorial tutorial)
        {
            if (id != tutorial.Id)
            {
                return BadRequest();
            }

            _context.Entry(tutorial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TutorialExists(id))
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

        // POST: api/Tutorial
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tutorial>> PostTutorial(Tutorial tutorial)
        {
            _context.Tutorial.Add(tutorial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTutorial", new { id = tutorial.Id }, tutorial);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tutorial>> DeleteTutorial(int id)
        {
            var tutorial = await _context.Tutorial.FindAsync(id);
            if (tutorial == null)
            {
                return NotFound();
            }

            _context.Tutorial.Remove(tutorial);
            await _context.SaveChangesAsync();

            return tutorial;
        }

        private bool TutorialExists(int id)
        {
            return _context.Tutorial.Any(e => e.Id == id);
        }
    }
}
