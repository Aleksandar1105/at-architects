namespace AtArchitects.Shared.Exceptions
{
    public class AdminNotFoundException(string id) : Exception($"Project with id:[{id}] was not found.") { }
}
