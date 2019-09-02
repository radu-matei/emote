using System.CommandLine;
using System.CommandLine.Invocation;
using System.Linq;
using Emote.Api;

namespace Emote.Commands
{
    public class ShowCommandHandler
    {
        private IEmoticonRetriever _emoticons { get; set; }
        public ShowCommandHandler() { }
        public ShowCommandHandler(IEmoticonRetriever emoticons)
        {
            _emoticons = emoticons;
        }
        public Command Create()
        {
            var cmd = new Command("show", "shows an emoticon from the configuration given its name");

            cmd.AddArgument(new Argument<string>("emoticon"));
            cmd.AddOption(new Option(new string[] { "--verbose", "-v" }, "if provided, it will also print the name of the emoticon")
            {
                Argument = new Argument<bool>(() => false),
            });

            cmd.Handler = CommandHandler.Create<string, bool>((string emoticon, bool verbose) =>
            {
                var em = _emoticons.Get(emoticon);
                if (verbose)
                {
                    System.Console.WriteLine("{0}: {1}", em.Name, em.Value);
                }
                else
                {
                    System.Console.WriteLine(em.Value);
                }
            });
            return cmd;
        }
    }
}