using System.Collections.Generic;

namespace Emote.Api
{
    public interface IEmoticonRetriever
    {
        IEnumerable<Emoticon> List();
        Emoticon Get(string name);
    }
}