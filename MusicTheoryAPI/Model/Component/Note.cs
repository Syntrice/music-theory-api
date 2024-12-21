namespace MusicTheoryAPI.Model.Component
{
    public class Note
    {
        /// <summary>
        /// The pitch class set value of the note from 0 to 11.
        /// </summary>
        private int _pitch;
        public int Pitch 
        { 
            get => _pitch;
            set
            {
                if (value < 0 || value > 11)
                {
                    throw new System.ArgumentOutOfRangeException("Pitch must be > 0 and <= 11.");
                }
                _pitch = value;
            }
        }

        /// <summary>
        /// The duration of the note in beats.
        /// </summary>
        private float _duration = 1;
        public float Duration 
        { 
            get => _duration;
            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("Duration must be > 0.");
                }
                _duration = value;
            }
        }

        /// <summary>
        /// The octave of the note, where middle C is C4.
        /// </summary>
        public int Octave { get; set; } = 4;
    }
}
