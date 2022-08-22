namespace BOI.BOIApplications.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
                : base($"{name} ({key}) ")
        {
        }
    }
}
