using Moq;
using FluentAssertions;
using Travelport.Application.DTOs;
using Travelport.Application.Interfaces;
using Travelport.Application.Services;
using Travelport.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Travelport.Tests.Services;

public class PersonServiceTests
{
    [Fact]
    public async Task RegisterAsync_Should_Call_Repository_And_Return_Person()
    {
        // Arrange
        var mockRepo = new Mock<IPersonRepository>();
        var mockLogger = new Mock<ILogger<PersonService>>(); // Mock the ILogger
        var command = new CreatePersonCommand
        {
            Name = "Carlos",
            Surname = "Lopez",
            Email = "carlos@test.com",
            PassportNumber = "PA1234567",
            Phone = "+34600000000",
            AirportCode = "MAD"
        };

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Person p, CancellationToken _) => p);

        var service = new PersonService(mockRepo.Object, mockLogger.Object); // Pass the mockLogger

        // Act
        var result = await service.RegisterAsync(command);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(command.Name);
        result.PassportNumber.ToString().Should().Be("PA1234567");
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Person>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
