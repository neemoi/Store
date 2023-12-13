using Application.CustomException;
using Application.DTOModels.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace WebAPIKurs.CustomExceptionMiddleware
{
    public class ExceptionHandlingMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "KEY_NOT_FOUND_ERROR")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound, "Key not found");
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "INVALID_INPUT_DATA")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError, "Bad Request");
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "HTTP_REQUEST_ERROR")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.BadGateway, "Error in external API request (HttpRequestException)");
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "NOT_IMPLEMENTED")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotImplemented, "Not Implemented (NotImplementedException)");
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "DATABASE_ERROR")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError, "Database error (DbUpdateException)");
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "MAPPING_ERROR_CODE")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.BadRequest, "Mapping error occurred");
            }
            catch (CustomRepositoryException ex) when (ex.ErrorCode == "NOT_FOUND_ERROR_CODE")
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError, "Internal server error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode httpStatusCode, string message)
        {
            _logger.LogError(ex, ex.Message);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode,
                Timestamp = DateTime.Now.ToString(),
                Description = ex.Message,
                StackTrace = ex.StackTrace
            };

            await response.WriteAsJsonAsync(errorDto);

            _logger.LogError($"Request Information: {context.Request.Method} {context.Request.Path}");
        }

    }
}
