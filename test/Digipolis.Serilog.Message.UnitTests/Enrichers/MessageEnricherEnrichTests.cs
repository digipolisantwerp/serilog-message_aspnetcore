using System;
using System.Collections.Generic;
using Digipolis.Serilog.Enrichers;
using Microsoft.Extensions.Options;
using Moq;
using Serilog.Events;
using Serilog.Parsing;
using Xunit;

namespace Digipolis.Serilog.Message.UnitTests.Enrichers
{
    public class MessageEnricherEnrichTests
    {
        [Fact]
        void MessageVersionIsAddedToLogEvent()
        {
            var options = new MessageEnricherOptions() { MessageVersion = "2" };
            var iOptions = new Mock<IOptions<MessageEnricherOptions>>(MockBehavior.Strict);

            iOptions.SetupGet(x => x.Value).Returns(options);

            var enricher = new MessageEnricher(iOptions.Object);

            var tokens = new List<MessageTemplateToken>();
            var properties = new List<LogEventProperty>();
            var logEvent = new LogEvent(DateTime.Now, LogEventLevel.Information, null, new MessageTemplate(tokens), properties);

            enricher.Enrich(logEvent, null);

            Assert.Equal(1, logEvent.Properties.Count);
            Assert.Collection(logEvent.Properties, x => Assert.Equal(MessageDefaults.MessageVersionProperty, x.Key));
        }
    }
}
