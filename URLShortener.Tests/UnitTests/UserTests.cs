using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using URLShortener.WebApi.Builders;
using URLShortener.WebApi.Data;
using URLShortener.WebApi.Data.Dtos;
using URLShortener.WebApi.Extensions;
using URLShortener.WebApi.Helpers;
using URLShortener.WebApi.Services;

namespace URLShortener.Tests.UnitTests;

public class UserTests
{
    private UserService _userService;
    private IMapper _mapper;
    private UrlDbContext _dbContext;

    [OneTimeSetUp]
    public async Task Init()
    {
        var dbContextOptions = new DbContextOptionsBuilder<UrlDbContext>()
            .UseInMemoryDatabase(databaseName: "URLShorterDB")
            .Options;
        
        _dbContext = new UrlDbContext(dbContextOptions);
        _userService = new UserService(_dbContext);
        _mapper = MapperResolver.InitiateMapping();
    }

    [OneTimeTearDown]
    public async Task CleanUp()
    {
        await _dbContext.Database.EnsureDeletedAsync();
    }

    [Test]
    public async Task Create_NewUser_ReturnsUserDto()
    {
        // Arrange
        var signForm = GlobalBuilders.BuildSignForm();

        // Act
        var userDto = await _userService.Create(signForm);

        // Assert
        using (new AssertionScope())
        {
            userDto.Should().NotBeNull();

            userDto.Should().BeEquivalentTo(signForm,
                o => o.Including(
                x => x.Name,
                x => x.Email));

            userDto.Role.Should().Be(AppHelper.GetRole(signForm.IsAdmin));
        }
    }
    
    [Test]
    public async Task Create_UserAlreadyExists_ReturnsNull()
    {
        // Arrange
        var signForm = GlobalBuilders.BuildSignForm();
        await _userService.Create(signForm);

        // Act
        var result = await _userService.Create(signForm);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public async Task GetUserById_UserExists_ReturnsUserDto()
    {
        // Arrange
        var user = _mapper.Map<UserDto>(GlobalBuilders.BuildSignForm());
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _userService.GetUserById(user.Id);

        // Assert
        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user, 
                o => o.Excluding(x => x.Id));
        }
    }

    [Test]
    public void GetUserById_UserDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        const int nonExistingId = -1;

        // Assert
        Assert.ThrowsAsync<ArgumentException>(() => _userService.GetUserById(nonExistingId));
    }

    [Test]
    public async Task GetUserByEmail_UserExists_ReturnsUserDto()
    {
        // Arrange
        var user = _mapper.Map<UserDto>(GlobalBuilders.BuildSignForm());
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _userService.GetUserByEmail(user.Email);

        // Assert
        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(user, 
                o => o.Excluding(x => x.Id));
        }
    }

    [Test]
    public void GetUserByEmail_UserDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        const string nonExistingEmail = "non-existing@example.com";

        // Assert
        Assert.ThrowsAsync<ArgumentException>(() => _userService.GetUserByEmail(nonExistingEmail));
    }
}