namespace AtArchitects.Shared.Exceptions
{
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException(string id) : base($"Admin with id:[{id}] was not found.") { }
    }
}
