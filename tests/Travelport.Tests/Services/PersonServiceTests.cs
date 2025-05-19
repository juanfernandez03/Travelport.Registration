using Moq;
using FluentAssertions;
using Travelport.Application.DTOs;
using Travelport.Application.Interfaces;
using Travelport.Application.Services;
using Travelport.Domain.Entities;

namespace Travelport.Tests.Services;

public class PersonServiceTests
{
    [Fact]
    public async Task RegisterAsync_Should_Call_Repository_And_Return_Person()
    {
        // Arrange
        var mockRepo = new Mock<IPersonRepository>();
        var command = new CreatePersonCommand
        {
            Name = "Carlos",
            Surname = "Lopez",
            Email = "carlos@test.com",
            PassportNumber = "PA1234567",
            Phone = "+34600000000",
            AirportCode = "MAD"
        };

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Person>()))
                .ReturnsAsync((Person p) => p);

        var service = new PersonService(mockRepo.Object);

        // Act
        var result = await service.RegisterAsync(command);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(command.Name);
        result.PassportNumber.Should().Be(command.PassportNumber);
        mockRepo.Verify(r => r.AddAsync(It.IsAny<Person>()), Times.Once);
    }
}
