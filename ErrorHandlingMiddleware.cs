using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Net;
using System.Text.Json;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate Next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.Next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Exception e)
        {
            await Handler(context, e);
        }
    }

    private async Task Handler(HttpContext context, Exception e)
    {
        var resposta = context.Response;
        resposta.ContentType = "application/json";
        if (e is Exception)
        {
            resposta.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        var result = JsonSerializer.Serialize(new { message = (e?.Message +"\\nErrou!!!!!!!!!!") });
        await resposta.WriteAsync(result);
    }
}

