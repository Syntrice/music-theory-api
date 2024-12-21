using MusicTheoryAPI.Model;
using MusicTheoryAPI.Model.Component;

namespace MusicTheoryAPI.Service
{
    public class NoteService
    {
        private RandomDataModel _randomDataModel;
        public NoteService(RandomDataModel randomDataModel)
        {
            _randomDataModel = randomDataModel;
        }

        public NoteDTO GetRandomNote()
        {
            return NoteDTO.Map(_randomDataModel.GetRandomNote());
        }

        public List<NoteDTO> GetRandomNotes(int count)
        {
            List<NoteDTO> noteDTOs = new List<NoteDTO>();
            for (int i = 0; i < count; i++)
            {
                noteDTOs.Add(NoteDTO.Map(_randomDataModel.GetRandomNote()));
            }
            return noteDTOs;
        }
    }
}
