namespace games_ecommerce.Domain.Services.Communication
{
    public abstract class BaseResponse
    {
        public string Message { get; protected set; }
        public bool Success { get; protected set; }

        public BaseResponse(string message, bool sucess)
        {
            Message = message;
            Success = sucess;
        }
    }
}
