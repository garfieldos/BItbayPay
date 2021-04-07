using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BitBayPayClient.Model
{
    public class JsonContent : StringContent
    {
        public JsonContent(string content) : base(content)
        {
            Content = content;
        }

        public JsonContent(string content, Encoding encoding) : base(content, encoding)
        {
            Content = content;
        }

        public JsonContent(string content, Encoding encoding, string mediaType) : base(content, encoding, mediaType)
        {
            Content = content;
        }

        public JsonContent(object instance) : base(
            instance != null ? JsonSerializer.Serialize(instance) : string.Empty,
            Encoding.UTF8,
            "application/json")
        {
            Content = instance != null ? JsonSerializer.Serialize(instance) : string.Empty;
        }

        public string Content { get; }
    }
}