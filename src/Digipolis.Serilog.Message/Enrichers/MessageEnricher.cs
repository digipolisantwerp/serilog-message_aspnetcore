using System;
using Digipolis.Serilog.Message;
using Microsoft.Extensions.Options;
using Serilog.Core;
using Serilog.Events;

namespace Digipolis.Serilog.Enrichers
{
    public class MessageEnricher : ILogEventEnricher
    {
        public MessageEnricher(IOptions<MessageEnricherOptions> options)
        {
            MessageVersion = options.Value?.MessageVersion ?? MessageDefaults.NullValue;
            _messageVersionProperty = new LogEventProperty(MessageDefaults.MessageVersionProperty, new ScalarValue(MessageVersion));
        }

        private readonly LogEventProperty _messageVersionProperty;

        public string MessageVersion { get; private set; }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(_messageVersionProperty);
        }
    }
}
