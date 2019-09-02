namespace Emote.Api
{
    public class Emoticon
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Emoticon() { }
        public Emoticon(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}