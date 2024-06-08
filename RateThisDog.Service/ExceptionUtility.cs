using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RateThisDog.Abstractions;

public class ExceptionUtility : IExceptionUtility
{
    private readonly HttpContext _context;
    private readonly ProblemDetailsFactory _problemDetailsFactory;
    private readonly ILogger _logger;

    public ExceptionUtility(
        HttpContext context,
        ProblemDetailsFactory problemDetailsFactory,
        ILogger logger)
    {
        _logger = logger;
        _context = context
            ?? throw new ArgumentNullException(nameof(context));
        _problemDetailsFactory = problemDetailsFactory
            ?? throw new ArgumentNullException(nameof(problemDetailsFactory));
    }

    public IActionResult ProcessException(
        Exception ex,
        string detail,
        HttpStatusCode status = HttpStatusCode.InternalServerError)
    {
        string errorUrn = $"urn:uuid:{Guid.NewGuid():D}";
        string url = _context?.Request?.GetDisplayUrl() ?? "Unknown URL";
        string logLine = $"Url: {url}, ID: {errorUrn} | {2}";

        _logger.LogError(ex, logLine);

        return new ObjectResult(_problemDetailsFactory.CreateProblemDetails(
            _context, detail: detail, statusCode: (int)status, instance: errorUrn));
    }
}