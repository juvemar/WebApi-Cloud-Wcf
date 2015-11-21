namespace WcfServiceHost
{
    using ReturnSubstringFromString;
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;

    public class Program
    {
        public static void Main()
        {
            var url = "http://127.0.0.1:9876";

            var behavior = new ServiceMetadataBehavior();

            ServiceHost host = new ServiceHost(typeof(StringCounter), new Uri(url));

            host.Description.Behaviors.Add(behavior);
            host.Open();

            Console.WriteLine("Service working on {0}", url);

            Console.ReadKey();

            host.Close();
        }
    }
}
