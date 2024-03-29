﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.Merchandise.Infrastructure.Middlewares
{
    public class ReadyMiddleware
    {
        public ReadyMiddleware(RequestDelegate next)   
        {
 
        }

        public async Task InvokeAsync(HttpContext context)
        {
             context.Response.StatusCode = StatusCodes.Status200OK;
             await context.Response.WriteAsync("");
        }
    }
}