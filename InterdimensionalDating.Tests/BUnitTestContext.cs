using Bunit;

namespace InterdimensionalDating.Tests;

public abstract class BUnitTestContext : TestContextWrapper
{
    [SetUp]
    public void Setup() => TestContext = new Bunit.TestContext();
    
    [TearDown]
    public void TearDown() => TestContext?.Dispose();
}