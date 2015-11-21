namespace WcfClient
{
    using System;
    using WcfClient.ServiceDayOfWeek;
    using ServiceStringCounter;

    public class Startup
    {
        public static void Main()
        {
            DayOfWeekServiceClient firstClient = new DayOfWeekServiceClient();

            var dayOfWeek = firstClient.ReturnDayOfWeekOnBulgarian(DateTime.Now.AddDays(-2));
            Console.WriteLine(dayOfWeek);

            StringCounterClient secondClient = new StringCounterClient();

            var searchPart = "my";
            var fullText = "My name is Myriam.";

            var countOfStrings = secondClient.CountStringAppearances(searchPart, fullText);

            Console.WriteLine("The number of appearances of \"my\" is {0}", countOfStrings);

            var strings = secondClient.CountStringAppearancesAsync(searchPart, fullText)
                .ContinueWith((clts) =>
                {

                });
        }
    }
}
