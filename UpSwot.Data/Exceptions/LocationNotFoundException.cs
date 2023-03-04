namespace UpSwot.Data.Exceptions
{
    public class LocationNotFoundException: Exception
    {
        public LocationNotFoundException(): base("Location with the given name not found.") { }
    }
}
