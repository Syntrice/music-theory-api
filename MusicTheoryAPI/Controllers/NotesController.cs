using Microsoft.AspNetCore.Mvc;
using MusicTheoryAPI.Service;

namespace MusicTheoryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly NoteService _noteService;
        public NotesController(NoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet()]
        [Route("random")]
        public IActionResult Get()
        {
            var note = _noteService.GetRandomNote();
            return Ok(note);
        }

        [HttpGet()]
        [Route("random/{count}")]
        public IActionResult Get(int count)
        {
            var notes = _noteService.GetRandomNotes(count);
            return Ok(notes);
        }
    }
}
