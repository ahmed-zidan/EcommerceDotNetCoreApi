using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode  , string mssage = null)
        {
            this.StatusCode = statusCode;
            this.Message = Message ?? getDefaultMessageForStatusCode(statusCode);
        }

        private string getDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorize, you are not",
                404 => "Resourse is not found",
                500 => "Internal server error",
                _ => null

            };
        }
    }
}
