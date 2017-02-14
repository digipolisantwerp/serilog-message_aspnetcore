using System;
using Digipolis.Serilog.Enrichers;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Digipolis.Serilog.Message.UnitTests.Enrichers
{
    public class MessageEnricherCtorTests
    {
        [Fact]
        void MessageVersionIsSetFromOptions()
        {
            var options = new MessageEnricherOptions() { MessageVersion = "12" };
            var iOptions = new Mock<IOptions<MessageEnricherOptions>>(MockBehavior.Strict);

            iOptions.SetupGet((x) => x.Value).Returns(options);

            var enricher = new MessageEnricher(iOptions.Object);

            Assert.Equal(options.MessageVersion, enricher.MessageVersion);
        }

        [Fact]
        void OptionsNullSetsMessageVersionToNullValue()
        {
            MessageEnricherOptions nullOptions = null;
            var iOptions = new Mock<IOptions<MessageEnricherOptions>>(MockBehavior.Strict);

            iOptions.SetupGet((x) => x.Value).Returns(nullOptions);

            var enricher = new MessageEnricher(iOptions.Object);

            Assert.Equal(MessageDefaults.NullValue, MessageDefaults.NullValue);
        }

    }
}
