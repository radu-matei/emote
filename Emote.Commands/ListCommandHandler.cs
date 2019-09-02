using System.CommandLine;
using System.CommandLine.Invocation;
using Emote.Api;

namespace Emote.Commands
{
    public class ListCommandHandler
    {
        private IEmoticonRetriever _emoticons { get; set; }
        public ListCommandHandler() { }
        public ListCommandHandler(IEmoticonRetriever emoticons)
        {
            _emoticons = emoticons;
        }
        public Command Create()
        {
            var cmd = new Command("list", "lists the emoticons from configuration file");
            cmd.Handler = CommandHandler.Create(() =>
            {
                foreach (var em in _emoticons.List())
                {
                    System.Console.WriteLine("{0}: {1}", em.Name, em.Value);
                }
            });
            return cmd;
        }
    }
}