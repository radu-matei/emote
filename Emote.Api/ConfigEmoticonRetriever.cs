using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Emote.Api
{
    public class ConfigEmoticonRetriever : IEmoticonRetriever
    {
        private List<Emoticon> _emoticons;
        public ConfigEmoticonRetriever() { }
        public ConfigEmoticonRetriever(IConfigurationRoot cfg)
        {
            _emoticons = new List<Emoticon>();
            var dict = cfg.GetSection("emoticons").GetChildren().ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<string, string> entry in dict)
            {
                _emoticons.Add(new Emoticon(entry.Key, entry.Value));
            }
        }
        public Emoticon Get(string name)
        {
            return _emoticons.FirstOrDefault(e => e.Name == name);
        }

        public IEnumerable<Emoticon> List()
        {
            return _emoticons;
        }
    }
}