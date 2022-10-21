using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlashCardService.DbContexts;
using FlashCardService.Models;

namespace FlashCardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashCardApiController : ControllerBase
    {
        private readonly FlashCardDbContext _context;

        public FlashCardApiController(FlashCardDbContext context)
        {
            _context = context;
        }

        // GET: api/FlashCardApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlashCard>>> GetFlashCards()
        {
          if (_context.FlashCards == null)
          {
              return NotFound();
          }
          return await _context.FlashCards.ToListAsync();
        }

        // GET: api/FlashCardApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlashCard>> GetFlashCard(int id)
        {
          if (_context.FlashCards == null)
          {
              return NotFound();
          }
          var flashCard = await _context.FlashCards.FindAsync(id);

          if (flashCard == null)
          {
              return NotFound();
          }

          return flashCard;
        }

        // PUT: api/FlashCardApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashCard(int id, FlashCard flashCard)
        {
            if (id != flashCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(flashCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashCardExists(id))
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

        // POST: api/FlashCardApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlashCard>> PostFlashCard(FlashCard flashCard)
        {
          if (_context.FlashCards == null)
          {
              return Problem("Entity set 'FlashCardDbContext.FlashCards'  is null.");
          }
          _context.FlashCards.Add(flashCard);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetFlashCard", new { id = flashCard.Id }, flashCard);
        }

        // DELETE: api/FlashCardApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashCard(int id)
        {
            if (_context.FlashCards == null)
            {
                return NotFound();
            }
            var flashCard = await _context.FlashCards.FindAsync(id);
            if (flashCard == null)
            {
                return NotFound();
            }

            _context.FlashCards.Remove(flashCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlashCardExists(int id)
        {
            return (_context.FlashCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
