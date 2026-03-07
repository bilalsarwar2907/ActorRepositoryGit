using ActorRepositoryGit.Models;
using ActorRepositoryGit.Repositories;

namespace ActorRepositoryGit.Tests;

public class ActorRepositoryTests
{
    [Fact]
    public void Get_ReturnsAllActors()
    {
        // Arrange
        var repository = new ActorRepositoryList();

        // Act
        var result = repository.GetAll();

        // Assert
        Assert.Equal(3, result.Count());
    }
    [Fact]

    public void GetById_WithValidId_ReturnsCorrectActor()
    { // Arrange

        var repository = new ActorRepositoryList();

        var expectedActor = new Actor { Id = 1, Name = "Leonardo DiCaprio", YearOfBirth = 1974 };
        // Act
        var result = repository.GetById(1);
        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedActor.Id, result.Id);
        Assert.Equal(expectedActor.Name, result.Name);
        Assert.Equal(expectedActor.YearOfBirth, result.YearOfBirth);

    }
        [Fact]
        public void GetById_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var repository = new ActorRepositoryList();
            // Act
            var result = repository.GetById(999);
            // Assert
            Assert.Null(result);
        }
    [Fact]
    public void MethodName_Scenario_ExpectedResult()
    {
        // 1. ARRANGE - Set up the test data
        var repository = new ActorRepositoryList();
        var expectedName = "Leonardo DiCaprio";

        // 2. ACT - Perform the action you're testing
        var result = repository.GetById(1);

        // 3. ASSERT - Verify the result is what you expected
        Assert.Equal(expectedName, result.Name);
    }
    [Fact]
    public void Add_AddsActorWithCorrectId()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        var newActor = new Actor { Name = "Tom Hanks", YearOfBirth = 1956 };
        var initialCount = repository.GetAll().Count();

        // Act
        var result = repository.Add(newActor);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Id); // Next ID should be 4
        Assert.Equal(initialCount + 1, repository.GetAll().Count());
        Assert.Equal("Tom Hanks", result.Name);
        Assert.Equal(1956, result.YearOfBirth);
    }
    [Fact]
    public void NotAdd_AddsActorWithInCorrectId()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        var newActor = new Actor {Id =1, Name = "Tom Hanks", YearOfBirth = 1956 };
        var initialCount = repository.GetAll().Count();

        // Act
        var result = repository.Add(newActor);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Id); // Next ID should be 4
        Assert.Equal(initialCount + 1, repository.GetAll().Count());
        Assert.Equal("Tom Hanks", result.Name);
        Assert.Equal(1956, result.YearOfBirth);
    }
    [Fact]
    public void Add_IgnoresProvidedIdAndAssignsNewId()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        var newActor = new Actor { Id = 999, Name = "Tom Hanks", YearOfBirth = 1956 };

        // Act
        var result = repository.Add(newActor);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Id); // Should still get 4, not 999
        Assert.Equal("Tom Hanks", result.Name);
    }
    [Fact]
    public void Update_WithExistingId_UpdatesActorProperties()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        var updateData = new Actor { Name = "Updated Name", YearOfBirth = 2000 };

        // Act
        var result = repository.Update(1, updateData);
        var updatedActor = repository.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Updated Name", updatedActor.Name);
        Assert.Equal(2000, updatedActor.YearOfBirth);
    }

    [Fact]
    public void Update_WithNonExistingId_ReturnsNull()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        var updateData = new Actor { Name = "Updated Name", YearOfBirth = 2000 };

        // Act
        var result = repository.Update(999, updateData);

        // Assert
        Assert.Null(result);
    }
    [Fact]
    public void Delete_WithExistingId_RemovesActor()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        var initialCount = repository.GetAll().Count();
        // Act
        var result = repository.Delete(1);
        var afterDeleteCount = repository.GetAll().Count();
        // Assert
        Assert.NotNull(result);
        Assert.Equal(initialCount - 1, afterDeleteCount);
        Assert.Null(repository.GetById(1));
    }
        [Fact]
        public void Delete_WithNonExistingId_ReturnsNull()
        {
            // Arrange
            var repository = new ActorRepositoryList();
            // Act
            var result = repository.Delete(999);
            // Assert
            Assert.Null(result);
        }
    [Fact]
    public void Get_WithBirthYearBefore_ReturnsCorrectActors()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        // Act
        var result = repository.Get(1950);
        // Assert
        Assert.Single(result);
        Assert.Equal("Meryl Streep", result.First().Name);
    }
    [Fact]
    public void Get_WithBirthYearBefore_ReturnsEmptyList()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        // Act
        var result = repository.Get(1900);
        // Assert
        Assert.Empty(result);
    } [Fact]
    public void Get_WithBirthYearBefore_ReturnsAllActors()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        // Act
        var result = repository.Get(2000);
        // Assert
        Assert.Equal(3, result.Count());
    }
    [Fact]
    public void Get_WithNullBirthYearBefore_ReturnsAllActors()
    {
        // Arrange
        var repository = new ActorRepositoryList();
        // Act
        var result = repository.Get("");
        // Assert
        Assert.Equal(3, result.Count());
    }
   
}