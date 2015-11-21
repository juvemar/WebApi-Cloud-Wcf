namespace ConsumingWebServicesInDotNet
{
    using Newtonsoft.Json;

    public class Article
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }
    }
}
