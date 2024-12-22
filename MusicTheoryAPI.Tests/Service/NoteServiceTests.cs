using FluentAssertions;
using Moq;
using MusicTheoryAPI.Model;
using MusicTheoryAPI.Model.Component;
using MusicTheoryAPI.Service;

namespace MusicTheoryAPI.Tests.Service
{
    [TestFixture]
    public class NoteServiceTests
    {

        private Mock<IRandomDataModel> _randomData;
        private NoteService _noteService;

        [SetUp]
        public void Setup()
        {
            _randomData = new Mock<IRandomDataModel>();
            _noteService = new NoteService(_randomData.Object);
        }

        [Test]
        public void GetRandomNote_MapsNoteCorrectly()
        {
            // Arrange
            NoteDTO expectedResult = new NoteDTO()
            {
                Pitch = "C4",
                Duration = 1.0f
            };

            _randomData.Setup(x => x.GetRandomNote()).Returns(new Note()
            {
                Pitch = 0,
                Duration = 1.0f,
                Octave = 4
            });

            // Act
            NoteDTO actualResult = _noteService.GetRandomNote();

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
            _randomData.Verify(x => x.GetRandomNote(), Times.Once);
        }

        [Test]
        public void GetRandomNotes_MapsNotesCorrectly()
        {

            List<Note> mockRandomNotes = new List<Note>()
            {
                new Note()
                {
                    Pitch = 0,
                    Duration = 1.0f,
                    Octave = 3
                },
                new Note()
                {
                    Pitch = 1,
                    Duration = 1.0f,
                    Octave = 4
                },
                new Note()
                {
                    Pitch = 2,
                    Duration = 1.0f,
                    Octave = 5
                }
            };

            List<NoteDTO> expectedResult = new List<NoteDTO>()
            {
                new NoteDTO()
                {
                    Pitch = "C3",
                    Duration = 1.0f
                },
                new NoteDTO()
                {
                    Pitch = "C#4",
                    Duration = 1.0f
                },
                new NoteDTO()
                {
                    Pitch = "D5",
                    Duration = 1.0f
                }
            };

            _randomData.Setup(x => x.GetRandomNotes(3)).Returns(mockRandomNotes);

            // Act
            List<NoteDTO> actualResult = _noteService.GetRandomNotes(3);

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
            _randomData.Verify(x => x.GetRandomNotes(3), Times.Once);
        }
    }
}
