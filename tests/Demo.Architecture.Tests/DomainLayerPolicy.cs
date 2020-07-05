using Demo.Core;
using FluentAssertions;
using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using Xunit;

namespace Demo.Architecture.Tests
{
    public class DomainLayerPolicy
    {
        [Fact]
        public void Architecture_DomainLayer_ShouldAdhereToTheOnionArchitectureDomainLayerPolicy()
        {
            PolicyDefinition domainLayerPolicy = Policy
                .Define("Onion Architecture Domain Layer Policy", "The domain layer should not have reference to any other layer within the application core.")
                .For(Types.InAssembly(typeof(ICoreModule).Assembly))
                .Add(t => t.That()
                           .ResideInNamespace("Demo.Core.Domain")
                           .ShouldNot()
                           .HaveDependencyOn("Demo.Core.Repositories"),
                     "Enforcing Domain Layer Policy", "Domain layer should not have references to the repositories layer."
                )
                .Add(t => t.That()
                           .ResideInNamespace("Demo.Core.Domain")
                           .ShouldNot()
                           .HaveDependencyOn("Demo.Core.Services"),
                     "Enforcing Domain Layer Policy", "Domain layer should not have references to the services layer."
                );

            bool actualResult = domainLayerPolicy.Evaluate().HasViolations;

            actualResult.Should().BeFalse();
        }
    }
}
