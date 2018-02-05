namespace Airline.Common.StaticData
{
    public static class ValidationRegex
    {
        public const string Email = @"^[a-zA-Z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
        public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!_@#$%^&'])[^ ]{8,}$";
        public const string Name = @"^[A-Z][A-Za-z- ]*$";
        public const string Phone = @"^\+380[\d]{9}$";
        public const string Time = @"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$";
        public const string FlightNumber = @"^[A-Z]{2}\d{2,3}$";

        // unused
        public const string SumNumber = @"^\d+(\.\d{1,2})?$";
        public const string Recipient = @"^\d{1,10}$";
    }
}