namespace InfoMgmtSys.Security
{
    public class RequestResult
    {
        public string Message { get; set; }
        public dynamic? Data { get; set; }

        public RequestResult(string message)
        {
            Message =  message;
        }

        public static RequestResult ExeResponse(string message, dynamic data)
        {
            var response = new RequestResult(message);
            response.Data = data;
            return response;

        }
    }
}
