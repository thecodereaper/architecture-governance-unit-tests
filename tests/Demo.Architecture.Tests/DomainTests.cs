using Demo.Core;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Demo.Architecture.Tests
{
    public class DomainTests
    {
        [Fact]
        public void Architecture_DomainLayer_ShouldNotHaveReferenceToRepositoriesLayer()
        {
            Types types = Types.InAssembly(typeof(ICoreModule).Assembly);

            bool actualResult = types
                .That()
                .ResideInNamespace("Demo.Core.Domain")
                .ShouldNot()
                .HaveDependencyOn("Demo.Core.Repositories")
                .GetResult()
                .IsSuccessful;

            actualResult.Should().BeTrue();
        }

        [Fact]
        public void Architecture_DomainLayer_ShouldNotHaveReferenceToServicesLayer()
        {
            Types types = Types.InAssembly(typeof(ICoreModule).Assembly);

            bool actualResult = types
                                .That()
                                .ResideInNamespace("Demo.Core.Domain")
                                .ShouldNot()
                                .HaveDependencyOn("Demo.Core.Services")
                                .GetResult()
                                .IsSuccessful;

            actualResult.Should().BeTrue();
        }
    }
}
