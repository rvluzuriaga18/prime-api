namespace Prime.Account.API.Models
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = string.Empty;
    }
}