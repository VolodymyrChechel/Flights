namespace Airline.BLL.Infrastructure
{
    public class OperationDetails
    {
        public bool Succeded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }

        public OperationDetails(bool succeded, string message, string prop)
        {
            Succeded = succeded;
            Message = message;
            Property = prop;
        }
    }
}