using Xunit;

namespace Cadmus.Cli.Plugin.Pura.Test
{
    public sealed class PuraCliRepositoryFactoryProviderTest
    {
        [Fact]
        public void CreateRepository_NotNull()
        {
            PuraCliRepositoryFactoryProvider provider = new();
            provider.ConnectionString = "mongodb://localhost:27017/{0}";
            Assert.NotNull(provider.CreateRepository("test"));
        }
    }
}