using System.Net;
using App.Contatos.Application.Exceptions;
using App.Contatos.Domain.Exceptions;

namespace App.Contatos.Api.Middlewares;

public class ExceptionMiddleware
{
    private  readonly RequestDelegate _next;
    
    public  ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
            
        } catch (ContatoNotFoundException e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(
                new ErrorResponse(404, e.Message));
            
        } catch (DomainException e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(
                new  ErrorResponse(400, e.Message));
            
        } catch(Exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(
                new ErrorResponse(500, "Erro interno no servidor."));
        }
    }
}