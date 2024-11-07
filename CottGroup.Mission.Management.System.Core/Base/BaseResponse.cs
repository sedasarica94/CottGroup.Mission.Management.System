using System.Collections.Generic;

namespace CottGroup.Mission.Management.System.Core.Base
{
    public class BaseResponse<T> where T : class,new()
    {
        public BaseResponse(string errorCode, string errorMessage)
        {
            IsSuccess = false;
            Errors = new List<ErrorModel>() {
                new ErrorModel() {
                    Code = errorCode, Message = errorMessage
                }
            };
        }

        public BaseResponse(T data)
        {
            if(data is null)
            {
                Data = null;
                Errors = new List<ErrorModel>();
                IsSuccess = false;
            }

            IsSuccess = true;
            Data = data;
        }

        public BaseResponse()
        {
            Data = null;
            Errors = new List<ErrorModel>();
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<ErrorModel> Errors { get; set; }

    }
    public class ErrorModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
