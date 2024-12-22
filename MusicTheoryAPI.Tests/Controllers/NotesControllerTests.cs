using NUnit.Framework;
using MusicTheoryAPI.Controllers;
using MusicTheoryAPI.Service;
using Moq;
using MusicTheoryAPI.Model.Component;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace MusicTheoryAPI.Tests.Controllers
{
    [TestFixture()]
    public class NotesControllerTests
    {

        private Mock<INoteService> _noteServiceMock;
        private NotesController _notesController;

        [SetUp]
        public void Setup()
        {
            _noteServiceMock = new Mock<INoteService>();
            _notesController = new NotesController(_noteServiceMock.Object);
        }

        [Test()]
        public void GetRandomNote_ReturnsValueAndOkObjectResult()
        {
            // Arrange
            NoteDTO randomNote = new NoteDTO()
            {
                Pitch = "C4",
                Duration = 1.0f
            };
            _noteServiceMock.Setup(x => x.GetRandomNote()).Returns(randomNote);

            // Act
            var result = _notesController.GetRandomNote();

            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeEquivalentTo(randomNote);

        }

        [Test()]
        public void GetRandomNotes_ReturnsValueAndOkObjectResult()
        {
            // Arrange
            List<NoteDTO> randomNotes = new List<NoteDTO>()
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
            _noteServiceMock.Setup(x => x.GetRandomNotes(3)).Returns(randomNotes);

            // Act
            var result = _notesController.GetRandomNotes(3);

            result.Should().BeOfType<OkObjectResult>();
            result.As<OkObjectResult>().Value.Should().BeEquivalentTo(randomNotes);

        }

        [TearDown]
        public void TearDown()
        {
            _notesController.Dispose();
        }
    }
}
