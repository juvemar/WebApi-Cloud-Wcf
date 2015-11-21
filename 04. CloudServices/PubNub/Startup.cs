namespace PubNub
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var publishKey = "pub-c-aa7e75ee-ca5f-40ef-95c9-fe28cd6830f6";
            var subscribeKey = "sub-c-9fe7c32e-8c77-11e5-84ee-0619f8945a4f";
            var secretKey = "sec-c-YmVlY2I1YTAtNzQwYi00NjI2LTg2MmMtYzhhNTRkNDViZmFk";
            var channel = "radio";
            Publisher pubnub = new Publisher(publishKey, subscribeKey, secretKey);

            while (true)
            {
                Console.WriteLine("Enter message:");
                var message = Console.ReadLine();

                pubnub.Publish(channel, message);
            }
        }
    }
}
