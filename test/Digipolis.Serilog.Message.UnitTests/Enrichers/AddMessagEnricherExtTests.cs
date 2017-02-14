using System;
using System.Linq;
using Digipolis.Serilog.Enrichers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog.Core;
using Xunit;

namespace Digipolis.Serilog.Message.UnitTests.Enrichers
{
    public class AddMessagEnricherExtTests
    {
        [Fact]
        void SetupActionNullRaisesArgumentNullException()
        {
            var services = new ServiceCollection();
            var options = new SerilogExtensionsOptions(services);

            var ex = Assert.Throws<ArgumentNullException>(() => options.AddMessagEnricher(null));
            Assert.Equal("setupAction", ex.ParamName);
            Assert.Contains("setupAction can not be null.", ex.Message);
        }

        [Fact]
        void MessageEnricherOptionsAreRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddSerilogExtensions(opt => opt.AddMessagEnricher(x => x.MessageVersion = "2"));

            var registrations = services.Where(sd => sd.ServiceType == typeof(IConfigureOptions<MessageEnricherOptions>))
                                        .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }

        [Fact]
        void MessageEnricherIsRegisteredAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddSerilogExtensions(opt => opt.AddMessagEnricher(x => x.MessageVersion = "2"));

            var registrations = services.Where(sd => sd.ServiceType == typeof(ILogEventEnricher) &&
                                                     sd.ImplementationType == typeof(MessageEnricher))
                                                     .ToArray();

            Assert.Equal(1, registrations.Count());
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }
    }
}
