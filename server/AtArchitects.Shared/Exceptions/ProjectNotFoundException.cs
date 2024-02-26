namespace AtArchitects.Shared.Exceptions
{
    public class ProjectNotFoundException(int id) : Exception($"Project with id:[{id}] was not found.") { }
}
