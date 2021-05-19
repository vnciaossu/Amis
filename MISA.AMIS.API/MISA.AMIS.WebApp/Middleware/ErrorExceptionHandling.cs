using Microsoft.AspNetCore.Http;
using MISA.AMIS.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.AMIS.WebApp.Middleware
{
    public class ErrorExceptionHandling
    {
        private readonly RequestDelegate _next;
        public ErrorExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExeptionAsync(context, ex);
            }
        }

        private Task HandleExeptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            var reponse = new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA",
                MISACode = "002",
                Data = ex.Data
            };
            context.Response.StatusCode = 500;
            if (ex is ValidateExceptions)
            {
                reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA",
                    MISACode = "001",
                    Data = ex.Data
                };
                context.Response.StatusCode = 400;
            }

            var result = JsonSerializer.Serialize(reponse);
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }
    }
}

