using System;
using Digipolis.Serilog.Enrichers;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;

namespace Digipolis.Serilog
{
    public static class AddMessageEnricherExt
    {
        public static SerilogExtensionsOptions AddMessagEnricher(this SerilogExtensionsOptions options, Action<MessageEnricherOptions> setupAction)
        {
            if ( setupAction == null ) throw new ArgumentNullException(nameof(setupAction), $"{nameof(setupAction)} can not be null.");

            options.ApplicationServices.Configure(setupAction);
            options.ApplicationServices.AddSingleton<ILogEventEnricher, MessageEnricher>();

            return options;
        }
    }
}
