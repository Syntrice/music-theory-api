using MusicTheoryAPI.Model.Component;
using System.Diagnostics.CodeAnalysis;

namespace MusicTheoryAPI.Model
{
    public class RandomDataModel
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
    }
}
