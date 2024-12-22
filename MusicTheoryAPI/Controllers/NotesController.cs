using Microsoft.AspNetCore.Mvc;
using MusicTheoryAPI.Service;

namespace MusicTheoryAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet()]
        [Route("random")]
        public IActionResult GetRandomNote()
        {
            var note = _noteService.GetRandomNote();
            return Ok(note);
        }

        [HttpGet()]
        [Route("random/{count}")]
        public IActionResult GetRandomNotes(int count)
        {
            var notes = _noteService.GetRandomNotes(count);
            return Ok(notes);
        }
    }
}
