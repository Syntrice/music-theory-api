using MusicTheoryAPI.Model;
using MusicTheoryAPI.Model.Component;

namespace MusicTheoryAPI.Service
{
    public interface INoteService
    {
        NoteDTO GetRandomNote();
        List<NoteDTO> GetRandomNotes(int count);
    }

    public class NoteService : INoteService
    {
        private IRandomDataModel _randomDataModel;
        public NoteService(IRandomDataModel randomDataModel)
        {
            _randomDataModel = randomDataModel;
        }

        public NoteDTO GetRandomNote()
        {
            return NoteDTO.Map(_randomDataModel.GetRandomNote());
        }

        public List<NoteDTO> GetRandomNotes(int count)
        {
            
            List<Note> notes = _randomDataModel.GetRandomNotes(count);
            List<NoteDTO> noteDTOs = new List<NoteDTO>();
            foreach (Note note in notes)
            {
                noteDTOs.Add(NoteDTO.Map(note));
            }

            return noteDTOs;
        }
    }
}
