namespace EcommerceApp.HandelResponses
{
    public class ApiResponse
    {
        public ApiResponse(int _StatusCode, string _Message = null)
        {
            StatusCode = _StatusCode;
            Message = _Message ?? GetDefaultMessageForstatusCode(StatusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForstatusCode(int code)
        {
            return code switch
            {
                400 => "bad request",
                401 => "you are not authorized",
                404 => "Resource not found",
                500 => "internal server error",
                _ => null


            };

        }
    }
}
