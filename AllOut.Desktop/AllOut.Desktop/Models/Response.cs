using AllOut.Desktop.Models.enums;

namespace AllOut.Desktop.Models
{
    public class Response
    {
        public ResponseResult Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
