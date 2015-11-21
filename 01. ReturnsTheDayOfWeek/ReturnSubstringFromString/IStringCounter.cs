namespace ReturnSubstringFromString
{
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStringCounter" in both code and config file together.
    [ServiceContract]
    public interface IStringCounter
    {
        [OperationContract]
        int CountStringAppearances(string textPart, string fullText);
    }
}
