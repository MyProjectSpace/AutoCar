using AutoCarApp.Application.Interfaces;
using AutoCarApp.Presentation;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;

namespace AutoCarAppTest
{
    public class ConsoleUserInputTest
    {
        [Fact]
        public void When_valid_command_entered_should_return_valid_commands()
        {
            // Arrange
            var consoleInputMock = new Mock<IInput>();
            consoleInputMock.SetupSequence(c => c.ReadString())
                .Returns("FFRFF");
            var consoleOutputMock = new Mock<AutoCarApp.Application.Interfaces.IOutput>();
            var userInput = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            // Act
            var result = userInput.GetValidCommands();

            // Assert
            Assert.Equal("FFRFF", result);
            consoleOutputMock.Verify(c => c.ShowMessage("Enter commands: "), Times.Once);
        }

        [Fact]
        public void When_invalid_command_entered_should_display_error_message()
        {
            
            var consoleOutputMock = new Mock<AutoCarApp.Application.Interfaces.IOutput>();
            var consoleInputMock = new Mock<IInput>();
            var yourClassInstance = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            // Set up the console input to return an invalid command, then a valid command
            consoleInputMock.SetupSequence(c => c.ReadString())
                .Returns("ABC")
                .Returns("FF");

            // Act
            var result = yourClassInstance.GetValidCommands();

            // Assert
            consoleOutputMock.Verify(c => c.ShowNewLineMessage(It.IsAny<string>()), Times.Once);
            consoleOutputMock.Verify(c => c.ShowMessage("Enter commands: "), Times.Exactly(2));
            consoleOutputMock.Verify(c => c.ShowNewLineMessage("Invalid commands. Only allow commands are R/r/L/l/F/f. Please enter valid command"), Times.Once);
            consoleInputMock.Verify(c => c.ReadString(), Times.Exactly(2));
            Assert.Equal("FF", result);
        }
    }
}
