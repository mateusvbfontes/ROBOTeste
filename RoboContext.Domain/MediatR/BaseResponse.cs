namespace RoboContext.Application.Commands
{
    public class BaseResponse<T>
    {
        public BaseResponse(bool isSuccesful, string message, List<string> errors = null, T data = default)
        {
            IsSuccesful = isSuccesful;
            Message = message;
            Errors = errors;
            Data = data;
        }
        public bool IsSuccesful { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}