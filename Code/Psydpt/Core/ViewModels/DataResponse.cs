using Psydpt.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Psydpt.Core.ViewModels
{
    public class DataResponse<T>
    {
        public T Data {get; set;}
        public ResponseStatus Status{get; set;}
        public string Message { get; set; }
        public Exception Log { get; set; }



        public DataResponse(T data, ResponseStatus status, string message, Exception log)
        {
            this.Data = data;
            this.Status = status;
            this.Message = message;
            this.Log = log;
        }

        public DataResponse(ResponseStatus status = ResponseStatus.Success)
            :this(default(T), status, "", null)
        { }

    }
}