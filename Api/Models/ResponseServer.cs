using System.Collections.Generic;
using System.Net;

namespace store_api.Models;

public class ResponseServer
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string> ErrorMessages { get; set; }
    public object Result { get; set; }

    public ResponseServer()
    {
        IsSuccess = true;
        ErrorMessages = [];
    }
}