
using BOI.BOIApplications.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace BOI.BOIApplications.API.Middleware;
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occured");
            await ConvertException(context, ex);
        }
    }

    private static Task ConvertException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";

        var result = string.Empty;

        switch (exception)
        {
            case CustomValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                break;
            case BadRequestException badRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = badRequestException.Message;
                break;
            case NotFoundException notFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case Exception ex:
                httpStatusCode = HttpStatusCode.InternalServerError;
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;

        if (result == string.Empty)
        {
            result = JsonConvert.SerializeObject(new { error = exception.Message });
        }

        return context.Response.WriteAsync(result);
    }
}
