using LP.Common.Shared.Exceptions;

namespace LP.Common.Domain.Exceptions;

public class DomainLogicException(string messageCode, IReadOnlyCollection<object>? parameters = null, Exception? innerException = null)
    : BaseException(messageCode, parameters, innerException);