namespace WorkHubBackEndServices.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaulMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaulMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a Bad Request",
                401 => "You are not Authourized",
                404 => "Resource not found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}
