using System.Globalization;
using System.Net;
using LP.Common.Application.Exceptions;
using LP.Common.Domain.Exceptions;
using LP.Common.Domain.Specification;
using LP.Common.Host.Utils;
using LP.Common.Shared.Exceptions;
using LP.Common.Shared.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LP.Common.Host.Middlewares;

public class ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, IMessageProvider messageProvider) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(exception,
                "Unhandled exception: {Message}. Method: {RequestMethod}, Path: {RequestPath}, StatusCode: {StatusCode}",
                exception.Message,
                context.Request.Method,
                context.Request.Path.Value,
                context.Response.StatusCode);

            await HandleErrorAsync(context, exception);
        }
    }

    private Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = exception.Message;

        switch (exception)
        {
            case SpecificationException _:
            case DomainLogicException _:
            case BusinessLogicException _:
                statusCode = HttpStatusCode.BadRequest;
                message = GetExceptionMessage((exception as BaseException)!);
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(message);
    }

    private string GetExceptionMessage(BaseException exception)
    {
        var errors = exception.Messages.Select(message =>
        {
            var dirtyMessage = messageProvider.GetMessage(message.Code);
            return new ErrorResponse(message.Code,
                string.Format(CultureInfo.InvariantCulture, dirtyMessage, args: message.Parameters ?? []));
        }).ToArray();
        return Serializer.ToJson(errors);
    }

    private sealed record ErrorResponse(string Code, string Message);
}