using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RateThisDog.Abstractions;

public class ExceptionUtility : IExceptionUtility
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ProblemDetailsFactory _problemDetailsFactory;
    private readonly ILogger<ExceptionUtility> _logger;

    public ExceptionUtility(
        IHttpContextAccessor contextAccessor,
        ProblemDetailsFactory problemDetailsFactory,
        ILogger<ExceptionUtility> logger)
    {
        _logger = logger;
        _contextAccessor = contextAccessor
            ?? throw new ArgumentNullException(nameof(contextAccessor));
        _problemDetailsFactory = problemDetailsFactory
            ?? throw new ArgumentNullException(nameof(problemDetailsFactory));
    }

    public IActionResult ProcessException(
        Exception ex,
        string detail,
        HttpStatusCode status = HttpStatusCode.InternalServerError)
    {
        string errorUrn = $"urn:uuid:{Guid.NewGuid():D}";

        HttpContext? context = _contextAccessor.HttpContext;

        string url = context?.Request?.GetDisplayUrl() ?? "Unknown URL";
        string logLine = $"Url: {url}, ID: {errorUrn} | {2}";

        _logger.LogError(ex, logLine);

        if (context == null)
        {
            // fallback if HttpContext is out of scope, which is not expected but
            // must be pre-empted to satisfy nullable
            return new ContentResult()
            {
                Content = $"Error: {detail}. Additional error reporting the error.",
                StatusCode = (int)status,
                ContentType = "text/plain"
            };
        }

        return new ObjectResult(_problemDetailsFactory.CreateProblemDetails(
            context, detail: detail, statusCode: (int)status, instance: errorUrn));
    }
}