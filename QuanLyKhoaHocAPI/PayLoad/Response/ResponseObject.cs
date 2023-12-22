namespace QuanLyKhoaHocAPI.PayLoad.Response
{
    public class ResponseObject<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }


        public ResponseObject(int status200OK)
        {
        }

        public ResponseObject(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public ResponseObject()
        {
        }

        public ResponseObject<T> ResponseSuccess(string message, T data)
        {
            return new ResponseObject<T>(StatusCodes.Status200OK, message, data);
        }

        public ResponseObject<T> ResponseError(int statusCode, string message, T data)
        {
            return new ResponseObject<T>(statusCode, message, data);
        }
    }
}
