using FluentAssertions;
using MusicTheoryAPI.Model.Component;

namespace MusicTheoryAPI.Tests.Model.Component;

[TestFixture]
public class NoteTests
{
    [TestCase(-1)]
    [TestCase(12)]
    public void PitchSetter_WhenInputInvalid_ThrowsArgumentOutOfRangeException(int pitchClass)
    {
        Action action = () => new Note() { Pitch = pitchClass };
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void PitchSetter_WithValidInput_SetsProperty([Range(0,11)] int pitchClass)
    {
        var note = new Note() { Pitch = pitchClass };
        note.Pitch.Should().Be(pitchClass);
    }

    [TestCase(-1)]
    public void DurationSetter_WithNegativeInput_ThrowsArgumentOutOfRangeException(float duration)
    {
        Action action = () => new Note() { Duration = duration };
        action.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Test]
    public void DurationSetter_WithPositiveInput_SetsProperty([Range(0.25, 2, 0.25)] double duration)
    {
        var note = new Note() { Duration = (float) duration };
        note.Duration.Should().Be((float) duration);
    }
}
