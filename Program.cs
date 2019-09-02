using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using Emote.Commands;
using System.CommandLine;
using System;
using Microsoft.Extensions.DependencyInjection;
using Emote.Api;

namespace Emote
{
    class Program
    {
        public static int Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddYamlFile("appsettings.yaml", true, true)
                .Build();
            var serviceCollection = new ServiceCollection().AddTransient<IEmoticonRetriever, ConfigEmoticonRetriever>();
            serviceCollection.Add(new ServiceDescriptor(serviceType: typeof(IConfigurationRoot), instance: config));
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var emoticons = serviceProvider.GetService<IEmoticonRetriever>();

            var cmd = new CommandLineBuilder()
                .AddCommand(new ListCommandHandler(emoticons).Create())
                .AddCommand(new ShowCommandHandler(emoticons).Create())
                .UseDefaults()
                .Build();

            return cmd.Invoke(args);
        }
    }
}