namespace _01.ReturnsTheDayOfWeek
{
    using System;
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDayOfWeekService" in both code and config file together.
    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        string ReturnDayOfWeekOnBulgarian(DateTime date);
    }
}
