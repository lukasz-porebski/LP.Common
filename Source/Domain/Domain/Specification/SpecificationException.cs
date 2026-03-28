using LP.Common.Shared.Data;
using LP.Common.Shared.Exceptions;

namespace LP.Common.Domain.Specification;

public class SpecificationException : BaseException
{
    internal SpecificationException(IReadOnlyCollection<ExceptionMessageData> messages, Exception? innerException = null)
        : base(messages, innerException)
    {
    }
}