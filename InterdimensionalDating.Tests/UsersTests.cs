using Bogus;
using Bunit;
using FluentAssertions;
using InterdimensionalDating.Models;
using InterdimensionalDating.Pages;
using InterdimensionalDating.Shared;
using RichardSzalay.MockHttp;

namespace InterdimensionalDating.Tests;

public class UsersTests : BUnitTestContext
{
    [Test]
    public void RendersUsersComponentCorrectlyWithNoData()
    {
        var ctx = new Bunit.TestContext();
        var mock = ctx.Services.AddMockHttpClient();
        mock.When("sample-data/users.json").RespondJson("[]");
        var cut = ctx.RenderComponent<Users>();
        
        cut.Find("h3").MarkupMatches("<h3>Users</h3>");
        cut.Find("em").TextContent.Should().Be("Loading...");
    }
    
    [Test]
    public void RendersUsersComponentCorrectlyWithData()
    {
        var userFake = new Faker<User>()
            .RuleFor(u => u.Id, f => f.Random.Int(1, 100))
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Status, f => f.PickRandom("Alive", "Dead", "Unknown"))
            .RuleFor(u => u.Species, f => f.PickRandom("Human", "Alien", "Robot"))
            .RuleFor(u => u.Type, f => f.PickRandom("Superhuman", "Human with antennae", "Insect"))
            .RuleFor(u => u.Gender, f => f.PickRandom("Male", "Female"))
            .RuleFor(u => u.Origin, f => f.Address.City())
            .RuleFor(u => u.Image, f => f.Image.PicsumUrl());
        var u = userFake.Generate();

        var ctx = new Bunit.TestContext();
        var mock = ctx.Services.AddMockHttpClient();
        mock.When("/sample-data/users.json").RespondJson(new List<User>{ u });

        var cut = ctx.RenderComponent<Users>();
        
        cut.Find("h3").MarkupMatches("<h3>Users</h3>");

        var comp = cut.FindComponents<UserCardComponent>();
        comp.Should().HaveCount(1);
    }
}