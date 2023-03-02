using AllOut.Web.Blazor.Models.enums;

namespace AllOut.Web.Blazor.Models.Common
{
    public class Response
    {
        public ResponseResult Result { get; set; }
        public string StatusCode { get; set; }
        public string Data { get; set; }
    }
}
