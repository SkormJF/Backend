using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly BlockDeNotas _context;

        public NotesController(BlockDeNotas context)
        {
            _context = context;
        }

        //list note 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>> GetNotas()
        {
            return await _context.Notas.ToListAsync();
        }

        //Details 
        [HttpGet("{id}")]
        public async Task<ActionResult<Nota>> GetNota(int id )
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota == null)
            {
                return NotFound();
            }
            return nota;
        }

        //create note 
        [HttpPost]
        public async Task<IActionResult> PostNota(Nota nota)
        {
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetNota",new{id = nota.Id},nota);
        }


        //Delete Nota
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNota(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if(nota == null)
            {
                return NotFound();
            }
            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //updata NOTE
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, Nota updatedNote)
        {
            var note = await _context.Notas.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            note.Title = updatedNote.Title;
            note.Content = updatedNote.Content;
            note.Estado = updatedNote.Estado;
            
            try
            {
                await _context.SaveChangesAsync();
            }
                catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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
        private bool NoteExists(int id)
        {
        return _context.Notas.Any(e => e.Id == id);
        }
        }
}
