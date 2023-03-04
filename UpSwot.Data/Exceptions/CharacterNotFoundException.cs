namespace UpSwot.Data.Exceptions
{
    public class CharacterNotFoundException: Exception
    {
        public CharacterNotFoundException(): base("Character with that name not found.") { }
    }
}
