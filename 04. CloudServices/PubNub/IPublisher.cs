namespace PubNub
{
    public interface IPublisher
    {
        void Publish(string channel, string message);
    }
}
