using AutoCarApp.Application.Interfaces;
using AutoCarApp.Presentation;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;

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
            var consoleUser = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            // Set up the console input to return an invalid command, then a valid command
            consoleInputMock.SetupSequence(c => c.ReadString())
                .Returns("ABC")
                .Returns("FF");

            // Act
            var result = consoleUser.GetValidCommands();

            // Assert
            consoleOutputMock.Verify(c => c.ShowNewLineMessage(It.IsAny<string>()), Times.Once);
            consoleOutputMock.Verify(c => c.ShowMessage("Enter commands: "), Times.Exactly(2));
            consoleOutputMock.Verify(c => c.ShowNewLineMessage("Invalid commands. Only allow commands are R/r/L/l/F/f. Please enter valid command"), Times.Once);
            consoleInputMock.Verify(c => c.ReadString(), Times.Exactly(2));
            Assert.Equal("FF", result);
        }

        [Fact]
        public void When_valid_directions_entered_should_return_valid_directions()
        {
            var consoleOutputMock = new Mock<AutoCarApp.Application.Interfaces.IOutput>();
            var consoleInputMock = new Mock<IInput>();
            consoleInputMock.Setup(c => c.ReadKey()).Returns('N');
            var userInput = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            var result = userInput.GetValidDirection();

            // Assert
            Assert.Equal('N', result);
            consoleOutputMock.Verify(c => c.ShowMessage("Enter a direction: "), Times.Once);
        }

        [Fact]
        public void When_invalid_direction_entered_should_display_error_message()
        {

            var consoleOutputMock = new Mock<AutoCarApp.Application.Interfaces.IOutput>();
            var consoleInputMock = new Mock<IInput>();
            var consoleUser = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            // Set up the console input to return an invalid command, then a valid command
            consoleInputMock.SetupSequence(c => c.ReadKey())
                .Returns('A')
                .Returns('N');

            // Act
            var result = consoleUser.GetValidDirection();

            // Assert
            consoleOutputMock.Verify(c => c.ShowNewLineMessage(It.IsAny<string>()), Times.Once);
            consoleOutputMock.Verify(c => c.ShowMessage("Enter a direction: "), Times.Exactly(2));
            consoleOutputMock.Verify(c => c.ShowNewLineMessage("Invalid direction. Please enter a valid direction"), Times.Once);
            consoleInputMock.Verify(c => c.ReadKey(), Times.Exactly(2));
            Assert.Equal('N', result);
        }

        [Fact]
        public void When_valid_integer_is_entered_should_return_valid_integer_value()
        {
            var consoleOutputMock = new Mock<AutoCarApp.Application.Interfaces.IOutput>();
            var consoleInputMock = new Mock<IInput>();
            consoleInputMock.Setup(c => c.ReadString()).Returns("1");
            var userInput = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            var result = userInput.GetValidIntegerInput(string.Empty);

            Assert.Equal(1, result);
            
        }

        [Fact]
        public void When_invalid_integer_is_entered_should_return_error_message()
        {
            var consoleOutputMock = new Mock<AutoCarApp.Application.Interfaces.IOutput>();
            var consoleInputMock = new Mock<IInput>();
            consoleInputMock.SetupSequence(c => c.ReadString()).Returns("SA").Returns("1");
            var userInput = new ConsoleUserInput(consoleOutputMock.Object, consoleInputMock.Object);

            var result = userInput.GetValidIntegerInput(string.Empty);

            //Assert.Equal(1, result);
            consoleOutputMock.Verify(c => c.ShowMessage(It.IsAny<string>()), Times.Exactly(2));
            consoleInputMock.Verify(c => c.ReadString(), Times.Exactly(2));
            consoleOutputMock.Verify(c => c.ShowNewLineMessage("Invalid integer value. Please enter a valid integer."), Times.Once);
        }

    }
}
