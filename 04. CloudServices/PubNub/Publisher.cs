using System.Net;
using System.Web.Script.Serialization;

namespace PubNub
{
    public class Publisher : IPublisher
    {
        private const string RequestFormatUrl = "http://pubsub.pubnub.com/publish/{0}/{1}/0/{2}/0/{3}";

        private readonly string publishKey;
        private readonly string subscribeKey;
        private readonly string secretKey;

        public Publisher(string publishKey, string subscribeKey, string secretKey)
        {
            this.publishKey = publishKey;
            this.secretKey = subscribeKey;
            this.secretKey = secretKey;
        }

        public void Publish(string channel, string message)
        {
            var serializer = new JavaScriptSerializer();
            var url = string.Format(RequestFormatUrl, publishKey, subscribeKey, secretKey, serializer.Serialize(message));

            HttpWebRequest.Create(url).GetResponse();
        }
    }
}
