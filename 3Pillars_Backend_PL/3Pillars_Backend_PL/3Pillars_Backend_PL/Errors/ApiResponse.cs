using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3Pillars_Backend_PL.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        // Parameter Constructor have StatusCode and Message which can may be null
        public ApiResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        // This Function Mapping StatusCode With Message 
        private string GetDefaultMessageForStatusCode(int statusCode)
            => statusCode switch
            {
                200 => "OK,Sucessfully",
                400 => "A Bad Request ",
                401 => "UnAuthorized , Invalid Token",
                403 => "Not Allowed , Forbidden",
                404 => "Resource Was Not Found",
                409 => "Email Is already Exist",
                500 => "Server Side Error",
                _ => null
            };
    }
}
