namespace RateThisDog.Abstractions;

using System.Net;
using Microsoft.AspNetCore.Mvc;

public interface IExceptionUtility
{
    public IActionResult ProcessException(
        Exception ex,
        string detail,
        HttpStatusCode status = HttpStatusCode.InternalServerError);
}