namespace AtArchitects.Shared.Exceptions
{
    public class ArchitectNotFoundException : Exception
    {
        public ArchitectNotFoundException(int id) : base($"Admin with id:[{id}] was not found.") { }
    }
}
