namespace EcommerceApp.HandelResponses
{
    public class ApiException : ApiResponse
    {
        public string Details { get; set; }

        public ApiException(int _StatusCode, string _Message = null, string _Details = null)
            : base(_StatusCode, _Message)
        {
            Details = _Details;
        }
    }
}
