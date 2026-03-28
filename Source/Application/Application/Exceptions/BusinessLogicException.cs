using LP.Common.Shared.Exceptions;

namespace LP.Common.Application.Exceptions;

public class BusinessLogicException(string messageCode, IReadOnlyCollection<object>? parameters = null, Exception? innerException = null)
    : BaseException(messageCode, parameters, innerException);