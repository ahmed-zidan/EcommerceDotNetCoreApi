using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Errors
{
    public class ApiResponseDetail : ApiResponse
    {
        public string Detail { get; set; }
        public ApiResponseDetail(int statusCode, string mssage = null , string detail = null) : base(statusCode, mssage)
        {
            Detail = detail;
        }
    }
}
