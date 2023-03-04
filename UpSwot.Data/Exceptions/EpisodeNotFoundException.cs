namespace UpSwot.Data.Exceptions
{
    public class EpisodeNotFoundException: Exception
    {
        public EpisodeNotFoundException() : base("Episode with that name not found.") { }
    }
}
