
namespace Application.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException()
        {}
        public NotFoundEntityException(string message) : base(message)
        {}
        public NotFoundEntityException(string message, Exception inner) : base(message, inner)
        {}
    }
}
