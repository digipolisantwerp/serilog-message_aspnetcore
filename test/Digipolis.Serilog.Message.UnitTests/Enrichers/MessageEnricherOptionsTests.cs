using System;
using Digipolis.Serilog.Enrichers;
using Xunit;

namespace Digipolis.Serilog.Message.UnitTests.Enrichers
{
    public class MessageEnricherOptionsTests
    {
        [Fact]
        void MessageVersionIsInitialized()
        {
            var options = new MessageEnricherOptions();
            Assert.Equal(MessageDefaults.DefaultMessageVersion, options.MessageVersion);
        }
    }
}
