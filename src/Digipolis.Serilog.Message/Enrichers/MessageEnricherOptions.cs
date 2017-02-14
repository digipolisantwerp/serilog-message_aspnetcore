using System;
using Digipolis.Serilog.Message;

namespace Digipolis.Serilog.Enrichers
{
    public class MessageEnricherOptions
    {
        public string MessageVersion { get; set; } = MessageDefaults.DefaultMessageVersion;
    }
}
