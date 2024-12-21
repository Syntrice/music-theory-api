using FluentAssertions;
using MusicTheoryAPI.Model.Component;

namespace MusicTheoryAPI.Tests.Model.Component
{
    [TestFixture]
    public class NoteDTOTests
    {
        [TestCase(0, "C4")]
        [TestCase(1, "C#4")]
        [TestCase(2, "D4")]
        [TestCase(3, "D#4")]
        [TestCase(4, "E4")]
        [TestCase(5, "F4")]
        [TestCase(6, "F#4")]
        [TestCase(7, "G4")]
        [TestCase(8, "G#4")]
        [TestCase(9, "A4")]
        [TestCase(10, "A#4")]
        [TestCase(11, "B4")]
        public void Map_WithDifferentPitchClass_MapsPitchCorrectly(int pitchClass, string expectedPitch)
        {
            // Arrange
            var note = new Note() { Pitch = pitchClass, Octave = 4, Duration = 1};

            // Act
            var noteDTO = NoteDTO.Map(note);

            // Assert
            noteDTO.Pitch.Should().Be(expectedPitch);
        }

        [TestCase(-1, "C-1")]
        [TestCase(0, "C0")]
        [TestCase(3, "C3")]
        [TestCase(4, "C4")]
        [TestCase(5, "C5")]
        [TestCase(7, "C7")]
        [TestCase(11, "C11")]
        public void Map_WithDifferentOctave_MapsPitchCorrectly(int octave, string expectedPitch)
        {
            // Arrange
            var note = new Note() { Pitch = 0, Octave = octave, Duration = 1 };

            // Act
            var noteDTO = NoteDTO.Map(note);

            // Assert
            noteDTO.Pitch.Should().Be(expectedPitch);
        }

    }
}
