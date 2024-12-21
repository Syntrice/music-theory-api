using System.Text;

namespace MusicTheoryAPI.Model.Component
{
    public class NoteDTO
    {
        public string Pitch { get; set; } = "C4";
        public float Duration { get; set; } = 1;

        public static NoteDTO Map(Note note)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(note.Pitch switch
            {
                0 => "C",
                1 => "C#",
                2 => "D",
                3 => "D#",
                4 => "E",
                5 => "F",
                6 => "F#",
                7 => "G",
                8 => "G#",
                9 => "A",
                10 => "A#",
                11 => "B",

                // this should never happen, but adding it satisfies the compiler
                _ => throw new ArgumentOutOfRangeException("Pitch must be >= 0 and <= 11.") 
            });

            sb.Append(note.Octave);
            NoteDTO noteDTO = new NoteDTO() { Pitch = sb.ToString(), Duration = note.Duration };
            return noteDTO;
        }
    }
}
