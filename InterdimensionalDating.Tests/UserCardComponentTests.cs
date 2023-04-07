using Bogus;
using Bunit;
using FluentAssertions;
using InterdimensionalDating.Models;
using InterdimensionalDating.Shared;

namespace InterdimensionalDating.Tests;

public class UserCardComponentTests : BUnitTestContext
{
    public Faker<User> userFake;

    [SetUp]
    public void SecondSetup()
    {
        userFake = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 100))
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Status, f => f.PickRandom("Alive", "Dead", "Unknown"))
            .RuleFor(u => u.Species, f => f.PickRandom("Human", "Alien", "Robot"))
            .RuleFor(u => u.Type, f => f.PickRandom("Superhuman", "Human with antennae", "Insect"))
            .RuleFor(u => u.Gender, f => f.PickRandom("Male", "Female"))
            .RuleFor(u => u.Origin, f => f.Address.City())
            .RuleFor(u => u.Image, f => f.Image.PicsumUrl());
    }
    
    
    [Test]
    public void RendersUserCardComponentCorrectly()
    {
        
        var user = userFake.Generate();
        var cut = 
            RenderComponent<UserCardComponent>(parameters => parameters
                .Add(p => p.User, user));
        cut.Find("div#user-"+ user.Id).Should().NotBeNull();
    }

    [Test]
    public void RendersMessageCardWhenNoUsers()
    {
        var cut = 
            RenderComponent<UserCardComponent>(parameters => parameters
                .Add(p => p.User, null));
        cut.Find("h5").TextContent.Should().Be("No Users Available");
    } 
    
    [Test]
    public void RendersUserCardWhenOneUserIsFound()
    {
        var user = userFake.Generate();
        
        var cut = 
            RenderComponent<UserCardComponent>(parameters => parameters
                .Add(p => p.User, user));
        cut.Find("h5").TextContent.Should().Be(user.Name);
        cut.Find("div.max-w-sm").GetAttribute("id").Should().Be($"user-{user.Id}");
        cut.Find("img").GetAttribute("src").Should().Be(user.Image);
        cut.Find("img").GetAttribute("alt").Should().Be(user.Name + " image");
    } 
}