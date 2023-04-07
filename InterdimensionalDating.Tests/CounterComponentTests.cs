using Bunit;
using InterdimensionalDating.Pages;

namespace InterdimensionalDating.Tests;

public class Tests : BUnitTestContext
{
    [Test]
    public void RendersCounterComponentCorrectly()
    {
        var cut = RenderComponent<Counter>();
        cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 0</p>");
    }
    
    [Test]
    public void CounterIncrementsWhenButtonIsClicked()
    { 
        var cut = RenderComponent<Counter>();
        cut.Find("button").Click();
        cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
    }
}