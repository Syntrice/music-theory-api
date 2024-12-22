using MusicTheoryAPI.Model.Component;
using System.Diagnostics.CodeAnalysis;

namespace MusicTheoryAPI.Model
{
    public interface IRandomDataModel
    {
        // EXPERIMENTAL
        Note GetRandomNote();
        List<Note> GetRandomNotes(int count);
    }

    public class RandomDataModel : IRandomDataModel
    {

        // EXPERIMENTAL
        public Note GetRandomNote()
        {
            var random = new Random();
            return new Note()
            {
                Pitch = random.Next(0, 12),
                Duration = random.Next(1, 16) * 0.25f,
                Octave = random.Next(2, 7)
            };
        }

        // EXPERIMENTAL 
        public List<Note> GetRandomNotes(int count)
        {
            List<Note> notes = new List<Note>();
            for (int i = 0; i < count; i++)
            {
                notes.Add(GetRandomNote());
            }
            return notes;
        }
    }
}
